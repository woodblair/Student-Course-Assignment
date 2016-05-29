using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentCourseLib;


namespace StudentCourse
{
    public partial class MainForm : Form
    {
        CourseCSV courseCsv = null;
        StudentCSV studCsv = null;
        bool isCoursesPath = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void studentButton_Click(object sender, EventArgs e)
        {
            isCoursesPath = false;
            openFileDialog1.ShowDialog();
        }

        private void courseButton_Click(object sender, EventArgs e)
        {
            isCoursesPath = true;
            openFileDialog1.ShowDialog();
        }

        private void studentText_TextChanged(object sender, EventArgs e)
        {
            if (this.studentText.Text.Length > 0)
            {
                studentMsg.Text = "Start Processing...";
                try
                {
                    this.studCsv.ProcessCSV(studentText.Text);
                    studentMsg.Text = "Update Students Completed.";
                }
                catch (Exception ex)
                {
                    studentMsg.Text = ex.Message;
                }
            }
        }

        private void courseText_TextChanged(object sender, EventArgs e)
        {
            if (this.courseText.Text.Length > 0)
            {
                courseMsg.Text = "Start Processing...";
                try
                {
                    this.courseCsv.ProcessCSV(courseText.Text);
                    courseMsg.Text = "Update Courses Completed.";
                }
                catch (Exception ex)
                {
                    courseMsg.Text = ex.Message;
                }
            } 
            
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            if (!isCoursesPath)
                studentText.Text = openFileDialog1.FileName;
            else
                courseText.Text = openFileDialog1.FileName; 
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            courseCsv = CourseCSV.Initialize();
            studCsv = StudentCSV.Initialize();
            Task t = studCsv.LoadDataAsync();
            t.Wait();
        }

        private void SaveCourseDataToStorage()
        {
            Task t = this.courseCsv.SaveToCSVStorage();
            t.Wait();
        }

        private void SaveStudentDataToStorage()
        {
            Task t = this.studCsv.SaveToCSVStorage();
            t.Wait();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveCourseDataToStorage();
            courseMsg.Text = "Course Data Saved.";

            SaveStudentDataToStorage();
            studentMsg.Text = "Student Data Saved.";
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            try
            {
                SaveCourseDataToStorage();
                SaveStudentDataToStorage();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception Message: " + ex.Message);
            }
            Application.Exit();
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            string[] row = new string[6];
            var em = studCsv.CourseStudent.GetEnumerator();

            // clean up existing list
            if (courseDataGridView.Rows.Count >= 1)
            {
                courseDataGridView.AllowUserToAddRows = false;
                while (courseDataGridView.Rows.Count > 1)
                    courseDataGridView.Rows.RemoveAt(1);

                courseDataGridView.AllowUserToAddRows = true;
            }

            while (em.MoveNext())
            {
                string course_id = em.Key as string;
                string[] student_ids = (em.Value as string).Split(',');

                string courseInfo = this.courseCsv.GetCourseData(course_id);
                if (courseInfo == null || courseInfo.Length == 0)
                {
                    courseMsg.Text = "Error! Course ID: " + course_id + " - No course information found!";
                    continue;
                }
                
                string[] courseData = courseInfo.Split(',');
                if (courseData.Length < 2)
                {
                    courseMsg.Text = "Invalid! Course Data: " + courseData + " - course_id or state information not found!";
                    continue;
                }

                // skip deleted courses
                if (courseData[1] == "deleted") continue;

                for (int i = 0; i < student_ids.Length; i++)
                {
                    var studentInfo = this.studCsv.GetStudentData(student_ids[i]);
                    if (studentInfo == null || studentInfo.Length == 0)
                    {
                        studentMsg.Text = "Error! Student ID: " + student_ids[i] + " - No student information found!";
                        continue;
                    }

                    string[] studentData = studentInfo.Split(',');
                    if (studentData.Length < 3)
                    {
                        studentMsg.Text = "Invalid! Student Data: " + studentData + " - student information not complete!";
                        continue;
                    }
                    // skip deleted student.
                    if (studentData[2] == "deleted") continue;

                    row[0] = course_id;
                    row[1] = courseData[0];
                    row[2] = studentData[0];
                    row[3] = student_ids[i];
                    row[4] = studentData[2];
                    row[5] = courseData[1];
                    courseDataGridView.Rows.Add(row);
                }
            }
        }
    }
}
