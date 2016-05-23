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
    /// <summary>
    ///  Student data class used as an unique store by all student instances.
    /// </summary>
    sealed class StudentCSV
    {
        CSVAccess csv = null;
        string storege;
        // Student columns
        const string STUDENTRECORD = "user_id, user_name, course_id, state";
        // Hashtable for quick search student info.
        Hashtable studentIdName = new Hashtable();
        // Hashtable for quich search course/student info.
        Hashtable courseStudents = new Hashtable();
        // singleton
        static StudentCSV instance = null;
        static Object obj = new object();

        StudentCSV()
        {
            csv = new CSVAccess("Student");
            storege = csv.Storage;
        }

        /// <summary>
        /// Initialize StudentCSV instance
        /// </summary>
        /// <returns></returns>
        static internal StudentCSV Initialize()
        {
            if (instance == null)
            {
                lock (obj)
                {
                    instance = new StudentCSV(); 
                }
            }
            return instance;
        }

        internal async Task LoadDataAsync()
        {
            await LoadStudentsFromCSV();
        }

        /// <summary>
        /// Load existing Student data from stored CSV, if any.
        /// </summary>
        /// <returns></returns>
        async Task LoadStudentsFromCSV()
        {
            //Task t = Task.Run(() =>
            //{
            TextFieldParser parser = null;
            try
            {
                parser = csv.GetCSVParser(storege);

                // skip over header line.
                parser.ReadLine();

                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    try
                    {
                        // key= id; fields: 1: name; 2: course_id; 3: state.
                        studentIdName.Add(fields[0], fields[1] + ',' + fields[2] + ',' + fields[3]);

                        // mapping the course_id to all student_id that selected the course.
                        if (courseStudents.ContainsKey(fields[2]))
                            courseStudents[fields[2]] += ',' + fields[0];
                        else
                            courseStudents.Add(fields[2], fields[0]);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Invalid data encountered when initializing in Student records: " + ex.Message);
                    }
                }
            }
            finally
            {
                if (parser != null)
                    parser.Dispose();
            }
            //});
            //return t;
        }

        /// <summary>
        /// Course/Student maps
        /// </summary>
        internal Hashtable CourseStudent
        {
            get
            {
                return courseStudents;
            }
        }

        /// <summary>
        /// Save Student data to storage.
        /// </summary>
        /// <returns></returns>
        internal async Task SaveToCSVStorage()
        {
            string studentData = STUDENTRECORD + Environment.NewLine;
            var ie = studentIdName.GetEnumerator();
            while (ie.MoveNext())
            {
                var entry = (DictionaryEntry)ie.Current;
                studentData += entry.Key + "," + entry.Value + Environment.NewLine;
            }

            using (StreamWriter writer = File.CreateText(storege))
            {
                await writer.WriteAsync(studentData);
            }
        }

        internal string GetStudentData(string id)
        {
            if (studentIdName.ContainsKey(id))
            {
                return studentIdName[id] as string;
            }
            return null;
        }

        internal void AddStudent(string id, string name, string course, State state)
        {
            studentIdName.Add(id, name + ',' + course + ',' + state.ToString());
        }

        internal void UpdateStudent(string id, string name, string course, State state)
        {
            if (studentIdName.ContainsKey(id))
            {
                studentIdName[id] = name + ',' + course + ',' + state.ToString();
            }
            else
            {
                AddStudent(id, name, course, state);
            }
        }

        /// <summary>
        /// Processing Student CSV and update current student data accordingly.
        /// </summary>
        /// <param name="path"></param>
        public void ProcessCSV(string path)
        {
            if (!File.Exists(path))
                return;

            TextFieldParser parser = null;

            // user_id:0; name:1; course_id: 2; state: 3
            int[] maps = { 0, 0, 0, 0 };
            try
            {
                parser = csv.GetCSVParser(path);
                if (parser == null)
                    return;

                string[] fields = parser.ReadFields();
                if (fields.Length < 4)
                    throw new Exception("Invalid Student CSV file! four columns are required: user_id, user_name, course_id, state");
                for (int i = 0; i <= 3; i++)
                {
                    switch (fields[i].ToLower())
                    {
                        case "user_id":
                            maps[i] = 0;
                            break;
                        case "user_name":
                            maps[i] = 1;
                            break;
                        case "course_id":
                            maps[i] = 2;
                            break;
                        case "state":
                            maps[i] = 3;
                            break;
                        default:
                            throw new Exception(string.Format("Invalid Student CSV file {0}: header value:{1} is not recognized!", path, fields[i]));
                    }
                }
                while (!parser.EndOfData)
                {
                    fields = parser.ReadFields();
                    string[] f = { "", "", "", "" };
                    for (int i = 0; i <= 3; i++)
                        f[maps[i]] = fields[i];

                    Student student = new Student(f[0], f[1], f[2], (State)Enum.Parse(typeof(State), f[3]));
                    if (student != null)
                    {
                        // update course_id to student_id maps, if needed.
                        if (courseStudents.ContainsKey(student.CourseId))
                        {
                            if (((string)courseStudents[student.CourseId]).IndexOf(student.StudentId) < 0)
                                courseStudents[student.CourseId] += ',' + student.StudentId;
                        }
                        else
                        {
                            courseStudents.Add(student.CourseId, student.StudentId);
                        }
                    }
                }
            }
            finally
            {
                if (parser != null)
                    parser.Dispose();
            }
        }

        /// <summary>
        /// For a given course id, return student id's in a form of comma separated string.
        /// If the course id is not found, return null.
        /// </summary>
        /// <param name="course_id"></param>
        /// <returns></returns>
        public string GetStudentsForCourse(string course_id)
        {
            if (courseStudents.ContainsKey(course_id))
                return courseStudents[course_id] as string;
            else
                return null;
        } 
    }
}
