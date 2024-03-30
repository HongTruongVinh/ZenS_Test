using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZenS_Fontend_Test.Models
{
    public class DataProvider
    {
        private static DataProvider _ins;
        public static DataProvider Ins
        {
            get
            {
                if (_ins == null)
                    _ins = new DataProvider();
                return _ins;
            }
            set
            {
                _ins = value;
            }
        }

        public ZenSDBEntities DB { get; set; }

        private DataProvider()
        {
            DB = new ZenSDBEntities();
        }
    }
}