using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Base
{
    class TableInfoSingleton
    {
        private static TableInfoSingleton instance = new TableInfoSingleton();
        public string  DataBaseName { get; set; }
        public string TableName { get;set; }


        private TableInfoSingleton() { }

        public static TableInfoSingleton getInstance()
        {
            return instance;
        }
    }
}
