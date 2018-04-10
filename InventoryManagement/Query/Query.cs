using InventoryManagement.DataBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace InventoryManagement.Query
{


    public class Query
    {
        public SqlHelper SqlHelper
        {
            get
            {
                return new SqlHelper();
            }
        }

        protected List<T> ConvertDataTableToList<T>(Func<DataRow, T> convert, DataTable dt)
        {
            List<T> list = new List<T>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(convert(dr));
            }

            return list;
        }
    }
}
