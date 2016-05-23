using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourse
{
    enum StorageType
    {
        CSV = 0,
        Excel
    }
    interface IDataSource
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
