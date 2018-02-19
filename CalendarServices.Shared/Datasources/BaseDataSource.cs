using System;
using System.Threading.Tasks;

namespace CalendarServices.Datasources
{
    public abstract class BaseDataSource
    {
        public BaseDataSource()
        {
        }

        public abstract void Load();
    }
}
