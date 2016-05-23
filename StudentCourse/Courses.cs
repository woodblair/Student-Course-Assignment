using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourse
{
    class Course
    {
        string course_id;
        string course_name;
        State state;
        CourseCSV common = null;

        string GetData(string id)
        {
            if (common == null)
                common = CourseCSV.Initialize();

            return common.GetCourseData(id);
        }

        void UpdateCourse()
        {
            var sInfo = GetData(course_id);
            if (sInfo == null)
            {
                common.UpdateCourse(course_id, course_name, state);
                return;
            }
            string[] entries = sInfo.Split(',');
            if (string.Compare(course_name, entries[0], true) != 0 ||
                this.state != (State)Enum.Parse(typeof(State), entries[1]))
            {
                common.UpdateCourse(course_id, course_name, state);
            }
        }

        public Course(string id, string name, State state)
        {
            course_id = id;
            course_name = name;
            this.state = state;

            // Update Course data.
            UpdateCourse();
        }

        public string CourseId
        {
            get { return course_id; }
        }

        public string CourseName
        {
            get { return course_name; }
            set
            {
                if (value != null && value.Length > 0 && value != course_name)
                {
                    common.UpdateCourse(course_id, value, this.state);
                    course_name = value;
                }
            }
        }

        public State State
        {
            get { return state; }
            set
            {
                if (value != this.state)
                {
                    common.UpdateCourse(course_id, course_name, value);
                    this.state = value;
                }
            }
        }

        public Course FindCourse(string id)
        {
            var sInfo = GetData(id);
            if (sInfo == null) return null;

            string[] entries = sInfo.Split(',');
            this.course_name = entries[0];
            this.state = (State)Enum.Parse(typeof(State), entries[2]);
            return this;
        }
    }
}

