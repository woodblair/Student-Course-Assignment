using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseLib
{
    public enum StorageType
    {
        CSV = 0,
        Excel
    }
    /// <summary>
    /// Data source interface.
    /// </summary>
    public interface IDataSource
    {
        StorageType Type
        {
            get;
        }

        string Storage
        {
            get;
            set;
        }
    }
}
