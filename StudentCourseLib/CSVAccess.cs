using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

namespace StudentCourseLib
{
    public class CSVAccess : IDataSource
    {
        string storege = string.Empty;

        /// <summary>
        /// Default constructor
        /// </summary>
        public CSVAccess()
        {
        }
        /// <summary>
        /// Constructor instance CSVAccess object and set default path to existing CSV file.
        /// </summary>
        /// <param name="name">value: Student or Course</param>
        public CSVAccess(string name)
        {
            if (name == null || name.Length == 0)
                throw new ArgumentNullException();

            storege = Path.Combine(Environment.CurrentDirectory, name + ".csv");
        }

        public string Storage
        {
            get { return storege; }
            set
            {
                if (value != null && value.Length > 0)
                    storege = Path.Combine(Environment.CurrentDirectory, value + ".csv");
            }
        }

        public StorageType Type
        {
            get { return StorageType.CSV; }
        }
        /// <summary>
        /// Instance a TextFieldParser object and return it to the caller. Caller need to release the instance.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public TextFieldParser GetCSVParser(string path)
        {
            if (!File.Exists(path))
                throw new ArgumentException(string.Format("Path not found: {0}", path));

            TextFieldParser parser = new TextFieldParser(path);
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(new string[] { "," });
            parser.HasFieldsEnclosedInQuotes = true;
            parser.CommentTokens = new string[] { "#" };
            return parser;
        }
    }
}