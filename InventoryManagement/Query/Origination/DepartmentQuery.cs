using InventoryManagement.DataBase;
using InventoryManagement.QueryModel.Origination;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace InventoryManagement.Query.Origination
{
    public class DepartmentQuery
    {   /// <summary>
        /// 新增部门
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public bool InsertDepartment(DepartmentItems items)
        {
            string sql = "INSERT into table_Department (ObjectID,DepartmentName,IsEnable,IsDelete) VALUES(@ObjectID,@DepartmentName,@IsEnable,@IsDelete)";

            SQLiteParameter[] sqlparamter = new SQLiteParameter[]
             {
                new SQLiteParameter("@ObjectID", items.ObjectID),
                new SQLiteParameter("@DepartmentName",items.DepartmentName),
                new SQLiteParameter("@IsEnable", items.IsEnable),
                new SQLiteParameter("@IsDelete","N")
             };

            return new SqlHelper().ExecuteNonQuery(sql, sqlparamter) == 1;

        }
        /// <summary>
        /// 修改部门
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public bool UpdateDepartment(DepartmentItems items)
        {
            string sql = "Update table_Department  set  DepartmentName=@DepartmentName,IsEnable=@IsEnable where ObjectID=@ObjectID";

            SQLiteParameter[] sqlparamter = new SQLiteParameter[]
             {
                new SQLiteParameter("@ObjectID", items.ObjectID),
                new SQLiteParameter("@DepartmentName",items.DepartmentName),
                new SQLiteParameter("@IsEnable", items.IsEnable),
             };

            return new SqlHelper().ExecuteNonQuery(sql, sqlparamter) == 1;

        }
        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="units"></param>
        /// <returns></returns>
        public bool DeleteDepartment(string objectID)
        {
            string sql = "Update table_Department  set  IsDelete=@IsDelete where ObjectID=@ObjectID";

            SQLiteParameter[] sqlparamter = new SQLiteParameter[]
             {
                new SQLiteParameter("@ObjectID", objectID),
                new SQLiteParameter("@IsDelete","Y"),

             };

            return new SqlHelper().ExecuteNonQuery(sql, sqlparamter) == 1;

        }
        /// <summary>
        /// 获取所有部门
        /// </summary>
        /// <param name="restaurantID"></param>
        /// <returns></returns>
        public DataTable GetDepartments()
        {
            string sql = @"select ObjectID,DepartmentName ,(case when IsEnable='Y' then '可用' else '停用' end ) as IsEnable from table_Department where isdelete='N'";

            return new SqlHelper().ExecuteReader(sql);

        }
        /// <summary>
        /// 获取部门
        /// </summary>
        /// <param name="objectID"></param>
        /// <returns></returns>
        public DepartmentItems GetDepartment(string objectID)
        {
            string sql = @"select * from table_Department where ObjectId=@DepartmentID";
            SQLiteParameter[] sqlparamter = new SQLiteParameter[]
           {  new SQLiteParameter("@DepartmentID", objectID) };

            DataTable dt_Units = new SqlHelper().ExecuteReader(sql, sqlparamter);

            if (dt_Units.Rows.Count > 0)
            {
                return new DepartmentItems
                {
                    ObjectID = dt_Units.Rows[0]["ObjectID"].ToString(),
                    DepartmentName = dt_Units.Rows[0]["DepartmentName"].ToString(),
                    IsEnable = dt_Units.Rows[0]["IsEnable"].ToString(),
                };
            }
            else
            {
                return null;
            }
        }
    }
}
