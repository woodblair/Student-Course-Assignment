using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

namespace StudentCourse
{
    sealed class CourseCSV
    {
        CSVAccess csv = null;
        string storage;
        // Course columns
        const string COURSERECORD = "course_id, course_name, state";
        // Hashtable for quick search courses.
        Hashtable courseIdName = new Hashtable();
        // singleton
        static CourseCSV instance = null;
        static Object obj = new object();

        CourseCSV()
        {
            csv = new CSVAccess("Course");
            storage = csv.Storage;
        }

        /// <summary>
        /// Initialize CourseCSV instance and load course data from storage, if any.
        /// </summary>
        /// <returns></returns>
        static internal CourseCSV Initialize()
        {
            if (instance == null)
            {
                lock (obj)
                {
                    instance = new CourseCSV();
                    Task t = instance.LoadCourseData();
                    t.Wait();
                }
            }
            return instance;
        }

        internal async Task LoadDataAsync()
        {
            await LoadCourseData();
        }

        /// <summary>
        /// Loading existing Course data, if any.
        /// </summary>
        /// <returns></returns>
        async Task LoadCourseData()
        {
            TextFieldParser parser = null;
            try
            {
                parser = csv.GetCSVParser(storage);

                // skip over header line.
                parser.ReadLine();

                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    try
                    {
                        courseIdName.Add(fields[0], fields[1] + ',' + fields[2]);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Invalid data encountered when initializing in Course records: " + ex.Message);
                    }
                }
            }
            finally
            {
                if (parser != null)
                    parser.Dispose();
            }
        }

        internal IEnumerable CourseIds
        {
            get
            {
                var em = courseIdName.GetEnumerator();
                while (em.MoveNext())
                {
                    var entry = (DictionaryEntry)em.Current;
                    yield return entry.Key;
                }
            }
        }

        internal string GetCourseData(string id)
        {
            if (courseIdName.ContainsKey(id))
            {
                return (string)courseIdName[id];
            }
            return null;
        }

        internal void AddCourse(string id, string name, State state)
        {
            courseIdName.Add(id, name + ',' + state.ToString());
        }

        internal void UpdateCourse(string id, string name, State state)
        {
            if (courseIdName.ContainsKey(id))
            {
                courseIdName[id] = name + ',' + state.ToString();
            }
            else
            {
                AddCourse(id, name, state);
            }
        }

        internal async Task SaveToCSVStorage()
        {
            string coursesData = COURSERECORD + Environment.NewLine;
            var ie = courseIdName.GetEnumerator();
            while (ie.MoveNext())
            {
                var entry = (DictionaryEntry)ie.Current;
                coursesData += entry.Key as string + "," + entry.Value + Environment.NewLine;
            }

            using (StreamWriter writer = File.CreateText(storage))
            {
                await writer.WriteAsync(coursesData);
            }
        }

        public void ProcessCSV(string path)
        {
            if (!File.Exists(path))
                return;

            TextFieldParser parser = null;

            // course_id:0; course_name:1; state: 2
            int[] maps = { 0, 0, 0 };
            try
            {
                parser = csv.GetCSVParser(path);
                string[] fields = parser.ReadFields();
                if (fields.Length < 3)
                    throw new Exception("Invalid Student CSV file! four columns are required: course_id, course_name, state");
                for (int i = 0; i < 3; i++)
                {
                    switch (fields[i].ToLower())
                    {
                        case "course_id":
                            maps[i] = 0;
                            break;
                        case "course_name":
                            maps[i] = 1;
                            break;
                        case "state":
                            maps[i] = 2;
                            break;
                        default:
                            throw new Exception(string.Format("Invalid Course CSV file: header value:{0} is not recognized!", fields[i]));
                    }
                }
                while (!parser.EndOfData)
                {
                    fields = parser.ReadFields();
                    string[] f = { "", "", "" };
                    for (int i = 0; i < 3; i++)
                        f[maps[i]] = fields[i];

                    Course course = new Course(f[0], f[1], (State)Enum.Parse(typeof(State), f[2]));
                }
            }
            finally
            {
                if (parser != null)
                    parser.Dispose();
            }
        }
    }
}

