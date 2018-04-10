using InventoryManagement.DataBase;
using InventoryManagement.QueryModel.BaseSet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace InventoryManagement.Query.BaseSet
{
    public class UnitsQuery : Query
    {
        private Func<DataRow, UnitsItems> ConvertUnitsItems = Row =>
        {
            return new UnitsItems
            {
                ObjectID = Row.Field<string>("ObjectID"),
                UnitsName = Row.Field<string>("UnitName"),
                IsEnable = Row.Field<string>("IsEnable")
            };
        };



        /// <summary>
        /// 新增计量单位
        /// </summary>
        /// <param name="units"></param>
        /// <returns></returns>
        public bool InsertUnits(UnitsItems units)
        {
            string sql = "INSERT into table_units (ObjectID,UnitName,IsEnable,IsDelete) VALUES(@ObjectID,@UnitName,@IsEnable,@IsDelete)";

            SQLiteParameter[] sqlparamter = new SQLiteParameter[]
             {
                new SQLiteParameter("@ObjectID", units.ObjectID),
                new SQLiteParameter("@UnitName",units.UnitsName),
                new SQLiteParameter("@IsEnable", units.IsEnable),
                new SQLiteParameter("@IsDelete","N")
             };

            return SqlHelper.ExecuteNonQuery(sql, sqlparamter) == 1;

        }
        /// <summary>
        /// 修改计量单位
        /// </summary>
        /// <param name="units"></param>
        /// <returns></returns>
        public bool UpdateUnits(UnitsItems units)
        {
            string sql = "Update table_units  set  UnitName=@UnitName,IsEnable=@IsEnable where ObjectID=@ObjectID";

            SQLiteParameter[] sqlparamter = new SQLiteParameter[]
             {
                new SQLiteParameter("@ObjectID", units.ObjectID),
                new SQLiteParameter("@UnitName",units.UnitsName),
                new SQLiteParameter("@IsEnable", units.IsEnable),
             };

            return SqlHelper.ExecuteNonQuery(sql, sqlparamter) == 1;

        }
        /// <summary>
        /// 删除计量单位
        /// </summary>
        /// <param name="units"></param>
        /// <returns></returns>
        public bool DeleteUnits(string objectID)
        {
            string sql = "Update table_units  set  IsDelete=@IsDelete where ObjectID=@ObjectID";

            SQLiteParameter[] sqlparamter = new SQLiteParameter[]
             {
                new SQLiteParameter("@ObjectID", objectID),
                new SQLiteParameter("@IsDelete","Y"),

             };

            return SqlHelper.ExecuteNonQuery(sql, sqlparamter) == 1;

        }


        public List<UnitsItems> GetUnitsList()
        {
            string sql = @"select objectID, UnitName , (case when IsEnable='Y' then '可用' else '停用' end ) as IsEnable 
                           from table_units 
                           where isdelete='N' and IsEnable='Y'";

            var table = SqlHelper.ExecuteReader(sql);

            return ConvertDataTableToList<UnitsItems>(ConvertUnitsItems, table);

        }





        /// <summary>
        /// 获取单个计量单位
        /// </summary>
        /// <param name="UnitsID"></param>
        /// <returns></returns>
        public UnitsItems GetUnit(string UnitsID)
        {
            string sql = @"select * from table_units where ObjectId=@Units";
            SQLiteParameter[] sqlparamter = new SQLiteParameter[]
           {  new SQLiteParameter("@Units", UnitsID) };

            DataTable dt_Units = SqlHelper.ExecuteReader(sql, sqlparamter);

            if (dt_Units.Rows.Count > 0)
            {
                return ConvertUnitsItems(dt_Units.Rows[0]);
            }
            else
            {
                return null;
            }
        }
    }
}
