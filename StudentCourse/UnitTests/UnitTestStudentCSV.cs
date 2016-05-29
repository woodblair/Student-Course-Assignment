using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualBasic.FileIO;
using StudentCourseLib;

namespace UnitTests
{
    /// <summary>
    /// Summary description for UnitTestStudentCSV
    /// </summary>
    [TestClass]
    public class UnitTestStudentCSV
    {
        StudentCSV studentCsv;
        string studentTestFile;
        Dictionary<string, string[]> studentData = new Dictionary<string,string[]>();
        
        public UnitTestStudentCSV()
        {
            studentCsv = StudentCSV.Initialize();
            Assert.IsNotNull(studentCsv, "Failed: Initialize StudentCSV object returns null!");

            studentTestFile = Path.Combine(Environment.CurrentDirectory, @"TestCSVs\Student.csv");
            if (!File.Exists(studentTestFile))
                throw new Exception("Can't find test file at: " + studentTestFile);
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
        public void StudentTestInitialize() 
        {
            studentData.Clear();
            var tmpPath = Path.Combine(Environment.CurrentDirectory, "Student.csv");
            if (File.Exists(tmpPath))
                File.Delete(tmpPath);

            File.Copy(studentTestFile, tmpPath);

            Task t = studentCsv.LoadDataAsync();
            t.Wait();

            CSVAccess acc = new CSVAccess();
            TextFieldParser parser = acc.GetCSVParser(studentTestFile);

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
                    if (!studentData.ContainsKey(fields[0]))
                        studentData.Add(fields[0], v);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            parser.Dispose();
        }

        [TestMethod]
        public void LoadStudentDataTest()
        { 
            foreach (var s in studentData)
            {
                string[] value = studentCsv.GetStudentData(s.Key).Split(',');
                Assert.AreEqual(s.Value[0], value[0], true, "Student Name: " + s.Value[0] + " Not match with Id: " + s.Key);
            }
        }

        [TestMethod]
        public void CourseStudentTest()
        {
            Hashtable cs = studentCsv.CourseStudent;
            foreach (var s in studentData)
            {
                Assert.IsTrue(cs.Contains(s.Value[1]), "CourseStudent Hashtable: Not find Course Id: " + s.Value[1]);
                Assert.IsTrue(((string)cs[s.Value[1]]).Contains(s.Key), s.Key + " is not found register course id: " + s.Value[1]);
            }
        }

        [TestMethod]
        public void GetStudentsForCourseTest()
        {
            foreach (var s in studentData)
            {
                string result = studentCsv.GetStudentsForCourse(s.Value[1]);
                Assert.IsNotNull(result, "Course Id: " + s.Value[1] + " Not found in system!");
                Assert.IsTrue(result.Contains(s.Key), "Student: " + s.Value[0] + "Id: " + s.Key + " should have register course id:" + s.Value[1]);
            }
        }

        [TestMethod]
        public void CreateNewStudentTest()
        {
            Student student = new Student("9999", "John Ulta", "2", State.active);
            Assert.IsNotNull(student, "Faild to create a new student!");
            var id = student.StudentId;
            var name = student.StudentName;
            var courseId = student.CourseId;
            Assert.AreEqual(id, "9999", "New student Id is not expected!");
            Assert.AreEqual(name, "John Ulta", "New student name is not expected!");
            Assert.AreEqual(courseId, "2", "New student course Id is not expected!");
            Assert.AreEqual(student.State, State.active, "New student state is not expected!"); 
        }

        [TestMethod]
        public void UpdateStudentTest()
        {
            var s1 = new Student("8888", "Blair Good", "4", State.active);
            Assert.IsNotNull(s1, "Failed to create a new student!");

            var s2 = new Student("8888", "Frank Good", "4", State.active);
            Assert.IsNotNull(s2, "Failed to update student!");

            var s3 = s2.FindStudent("8888");
            Assert.AreEqual(s2, s3, "Student.FindStudent() returns different student object then itself!");
        }

        [TestMethod]
        public void ProcessStudentCsvTest()
        {
            // process a CSV that contains user_id:1099, user-name:"Bryan Walker", course_id:3, State: active
            studentCsv.ProcessCSV(Path.Combine(Environment.CurrentDirectory, @"TestCSVs\NewStudent.csv"));
            var s = studentCsv.GetStudentData("1099");
            Assert.IsNotNull(s, "Failed to process student CSV - student record lost!");
        }

        [TestMethod]
        public void ProcessStudentCsvReorderedTest()
        {
            // process a CSV that has columns are reordered: name: "Nancy Peylin", course_id: 5, State: active, student_id: 1999
            studentCsv.ProcessCSV(Path.Combine(Environment.CurrentDirectory, @"TestCSVs\NewStudentReordered.csv"));
            var s = studentCsv.GetStudentData("1999");
            Assert.IsNotNull(s, "Failed to process reordered column student CSV - student record lost!");
        }

        [TestMethod]
        public void SaveStudentToCSVStorageTest()
        {
            var s = new Student("1010", "Blabla Goody", "2", State.active);
            Assert.IsNotNull(s, "Failed to create a new student!");

            Task t = studentCsv.SaveToCSVStorage();
            t.Wait();

            var tmpPath = Path.Combine(Environment.CurrentDirectory, "Student.csv");
            studentCsv.ProcessCSV(tmpPath);
            var s2 = studentCsv.GetStudentData("1010");
            Assert.IsNotNull(s2, "Failed to find the student after saving to storage!");
            Assert.AreEqual(s2.Split(',')[0], "Blabla Goody", "Student name doesn't match after saving to storage!");
        }

        // Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup() 
        {
            var tmpPath = Path.Combine(Environment.CurrentDirectory, "Student.csv");
            if (File.Exists(tmpPath))
                File.Delete(tmpPath);

            studentData.Clear();
        }
    }
}
