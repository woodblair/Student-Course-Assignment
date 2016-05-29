using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualBasic.FileIO;
using StudentCourseLib;

namespace UnitTests
{
    /// <summary>
    /// Summary description for UnitTestCSVAccess
    /// </summary>
    [TestClass]
    public class UnitTestCSVAccess
    {
        const string Courses = "Courses";
        string courseTestFile;

        public UnitTestCSVAccess()
        {
            courseTestFile = Path.Combine(Environment.CurrentDirectory, @"TestCSVs\Course.csv");
            if (!File.Exists(courseTestFile))
                throw new Exception("Can't find test file at: " + courseTestFile);
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

        [TestMethod]
        public void InstanceCSVAccessNoParameterTest()
        {
            CSVAccess acc = new CSVAccess();
            Assert.IsNotNull(acc);
            Assert.AreEqual(string.Empty, acc.Storage);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InstanceCSVAccessInvalidParameterTest()
        {
            CSVAccess acc;
            acc = new CSVAccess(string.Empty);
            acc = new CSVAccess(null);
        }

        [TestMethod]
        public void InstanceCSVAccessParameterTest()
        {
            var s = "NewStudents";
            CSVAccess acc = new CSVAccess(s);
            Assert.IsNotNull(acc);
            StringAssert.Contains(acc.Storage, s, "CSVAccess storage path not contains expected string: " + s);
            StringAssert.EndsWith(acc.Storage, s + ".csv", "CSVAccess storage path not end with expected: " + s + ".csv");
        }

        [TestInitialize()]
        public void InstanceTextFieldParserTestInitialize() 
        {
            if(!File.Exists(Path.Combine(Environment.CurrentDirectory, "Temp.csv")))
                File.Copy(courseTestFile, Path.Combine(Environment.CurrentDirectory, "Temp.csv"));
        }

        [TestMethod]
        public void InstanceTextFieldParserInvalidPathTest()
        {
            CSVAccess acc = new CSVAccess(Courses);
            Assert.IsNotNull(acc);

            TextFieldParser paser;
            try{
                paser = acc.GetCSVParser("notexist.csv");
            }
            catch(ArgumentException ex)
            {
                StringAssert.Contains(ex.Message, "Path not found:");
                return;
            }

            throw new Exception ("Invalid CSV file path not being catch!");
        }

        [TestMethod]
        public void InstanceTextFieldParserTest()
        {
            CSVAccess acc = new CSVAccess(courseTestFile);
            Assert.IsNotNull(acc);

            TextFieldParser parser;
            try{
                parser = acc.GetCSVParser(Path.Combine(Environment.CurrentDirectory, "Temp.csv"));
                Assert.IsNotNull(parser);

                parser.Close();
            }
            catch(Exception ex)
            {
                throw new Exception("Failed to instance TestFileParser from CSVAccess! Exception: " + ex.Message);
            }
        }

        [TestCleanup()]
        public void MyTestCleanup()
        { 
            File.Delete(Path.Combine(Environment.CurrentDirectory, "Temp.csv"));
        }

    }
}
