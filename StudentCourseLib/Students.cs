using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseLib
{
    public enum State
    {
        active = 0,
        deleted
    }

    /// <summary>
    /// Student class that maintains student id, name, course selected, and state.
    /// </summary>
    public class Student
    {
        string user_id;
        string user_name;
        string course_id;
        State state;
        StudentCSV common = null;

        string GetData(string id)
        {
            if (common == null)
                common = StudentCSV.Initialize();

            return common.GetStudentData(id);
        }

        void UpdateStudent()
        {
            var sInfo = GetData(user_id);
            if (sInfo == null)
            {
                common.UpdateStudent(user_id, user_name, course_id, state);
                return;
            }
            string[] entries = sInfo.Split(',');
            if (string.Compare(user_name, entries[0], true) != 0 ||
                string.Compare(course_id, entries[1], true) != 0 ||
                this.state != (State)Enum.Parse(typeof(State), entries[2]))
            {
                common.UpdateStudent(user_id, user_name, course_id, state);
            }
        }

        public Student(string id, string name, string course, State state)
        {
            user_id = id;
            user_name = name;
            course_id = course;
            this.state = state;

            // Update Student data accordingly.
            UpdateStudent();
        }

        public string StudentId
        {
            get { return user_id; }
        }

        public string StudentName
        {
            get { return user_name; }
            set
            {
                if (value != null && value.Length > 0 && value != user_name)
                {
                    common.UpdateStudent(user_id, value, course_id, state);
                    user_name = value;
                }
            }
        }

        public string CourseId
        {
            get { return course_id; }
            set
            {
                if (value != null && value.Length > 0 && value != course_id)
                {
                    common.UpdateStudent(user_id, user_name, value, state);
                    course_id = value;
                }
            }
        }

        public State State
        {
            get { return this.state; }
            set { this.state = value; }
        }
        /// <summary>
        /// Search for the student for a given user_id. If not found, return null.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Student FindStudent(string id)
        {
            var sInfo = GetData(id);
            if (sInfo == null)
                return null;

            string[] entries = sInfo.Split(',');
            this.user_name = entries[0];
            this.course_id = entries[1];
            this.state = (State)Enum.Parse(typeof(State), entries[2]);
            return this;
        }
    }
}
