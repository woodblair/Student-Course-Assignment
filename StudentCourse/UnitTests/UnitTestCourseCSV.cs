using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualBasic.FileIO;
using StudentCourseLib;

namespace UnitTests
{
    /// <summary>
    /// Summary description for UnitTestCourseCSV
    /// </summary>
    [TestClass]
    public class UnitTestCourseCSV
    {
        CourseCSV courseCsv;
        string courseTestFile;
        Dictionary<string, string[]> courseData = new Dictionary<string, string[]>();

        public UnitTestCourseCSV()
        { 
            courseTestFile = Path.Combine(Environment.CurrentDirectory, @"TestCSVs\Course.csv");
            if (!File.Exists(courseTestFile))
                throw new Exception("Can't find test csv file at: " + courseTestFile);
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        // Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void CourseCsvTestInitialize()
        {
            courseData.Clear();
            var tmpPath = Path.Combine(Environment.CurrentDirectory, "Course.csv");
            if (File.Exists(tmpPath))
                File.Delete(tmpPath);

            File.Copy(courseTestFile, tmpPath);

            courseCsv = CourseCSV.Initialize();
            Assert.IsNotNull(courseCsv, "Failed: Initialize CourseCSV object returns null!");

            CSVAccess acc = new CSVAccess();
            TextFieldParser parser = acc.GetCSVParser(courseTestFile);

            // skip over header line.
            parser.ReadLine();

            while (!parser.EndOfData)
            {
                string[] v = new string[2];
                string[] fields = parser.ReadFields();
                v[0] = fields[1];
                v[1] = fields[2];
                try
                {
                    if (!courseData.ContainsKey(fields[0]))
                        courseData.Add(fields[0], v);
                }
                catch (Exception ex)
                {
                    throw new Exception("Initializing unit test got exception: " + ex.Message);
                }
            }

            parser.Dispose();
        }

        [TestMethod]
        public void LoadCourseDataTest()
        {
            foreach (var s in courseData)
            {
                string values = courseCsv.GetCourseData(s.Key);
                Assert.IsNotNull(values, "Course data not find for course Id: " + s.Key);

                string[] v = values.Split(',');
                Assert.AreEqual(s.Value[0], v[0], true, "Course Name: " + v[0] + " Not match with Id: " + s.Key);
                Assert.AreEqual(s.Value[1], v[1], true, "Course State: " + v[1] + " Not match with Id: " + s.Key);
            }
        }

        [TestMethod]
        public void CreateNewCourseTest()
        {
            Course course = new Course("100", "Data Science", State.active);
            Assert.IsNotNull(course, "Failed to create a new course!");

            var id = course.CourseId;
            var name = course.CourseName;
            Assert.AreEqual(id, "100", "New course Id is not expected!");
            Assert.AreEqual(name, "Data Science", "New course name is not expected!");
            Assert.AreEqual(course.State, State.active, "New student state is not expected!");   
        }

        [TestMethod]
        public void UpdateCourseTest()
        {
            var c1 = new Course("188", "Active Directory", State.active);
            Assert.IsNotNull(c1, "Failed to create a new course!");

            var c2 = new Course("188", "SQL Server 2012", State.active);
            Assert.IsNotNull(c2, "Failed to update course!");

            var c3 = c2.FindCourse("188");
            Assert.IsNotNull(c3, "Course.FindCourse(id) return null!");
            Assert.AreEqual(c2, c3, "Course.FindStudent() returns different course object then itself!");
        }

        [TestMethod]
        public void ProcessCourseCsvTest()
        {
            // process a CSV that contains course_id:199, course_name:"C Programming Language", State: active
            courseCsv.ProcessCSV(Path.Combine(Environment.CurrentDirectory, @"TestCSVs\NewCourse.csv"));
            var c = courseCsv.GetCourseData("199");
            Assert.IsNotNull(c, "Failed to process course CSV - course record lost!");
            string[] values = c.Split(',');
            Assert.AreEqual(values[0], "C Programming Language", "Course Id 199: name: " + values[0] + " is not expected. Processing course CSV file failed!");
            Assert.AreEqual(values[1], State.active.ToString(), "Course Id 199: state: " + values[1].ToString() + " is not expected. Processing course CSV file failed!");
        }

        [TestMethod]
        public void ProcessCourseCsvReorderedTest()
        {
            // process a CSV that has columns reordered: state: active, name: "C Programming Language Advanced", course_id: 188
            courseCsv.ProcessCSV(Path.Combine(Environment.CurrentDirectory, @"TestCSVs\NewCourseReordered.csv"));
            var c = courseCsv.GetCourseData("188");
            Assert.IsNotNull(c, "Failed to process reordered column course CSV - course record lost!");
            string[] values = c.Split(',');
            Assert.AreEqual(values[0], "C Programming Language Advanced", true, "Course Id 188: name: " + values[0] + " is not expected. Processing course CSV file failed!");
            Assert.AreEqual(values[1], State.active.ToString(), true, "Course Id 188: state: " + values[1].ToString() + " is not expected. Processing course CSV file failed!");
        }

        [TestMethod]
        public void SaveCourseToStorageTest()
        {
            var c = new Course("101", "Database Introduction", State.active);
            Assert.IsNotNull(c, "Failed to create a new course!");

            Task t = courseCsv.SaveToCSVStorage();
            t.Wait();

            // load course data from the temp storage
            var tmpPath = Path.Combine(Environment.CurrentDirectory, "Course.csv");
            courseCsv.ProcessCSV(tmpPath);

            var c2 = courseCsv.GetCourseData("101");
            Assert.IsNotNull(c2, "Failed to find the course after saving to storage!");
            string[] values = c2.Split(',');
            Assert.AreEqual(values[0], "Database Introduction", "Course name doesn't match after saving to storage!");
            Assert.AreEqual(values[1], State.active.ToString(), "Course state doesn't match after saving to storage!");
        }

        // Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void CourseCsvTestCleanup()
        {
            var tmpPath = Path.Combine(Environment.CurrentDirectory, "Course.csv");
            if (File.Exists(tmpPath))
                File.Delete(tmpPath);

            courseData.Clear();
        }
    }
}
