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
    public class UserQuery : Query
    {
        private Func<DataRow, UserItems> ConvertUserItems = Row =>
           {
               return new UserItems
               {
                   ObjectID = Row.Field<string>("ObjectID"),
                   UserName = Row.Field<string>("UserName"),
                   UserDepartmentID = Row.Field<string>("departmentID"),
                   UserDepartmentName = Row.Field<string>("departmentname"),
                   IsEnable = Row.Field<string>("IsEnable")
               };
           };

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool InsertUser(UserItems user)
        {
            string sql = "INSERT into table_user (ObjectID,DepartmentID,UserName,IsEnable,IsDelete) VALUES(@ObjectID,@DepartmentID,@UserName,@IsEnable,@IsDelete)";

            SQLiteParameter[] sqlparamter = new SQLiteParameter[]
             {
                new SQLiteParameter("@ObjectID", user.ObjectID),
                new SQLiteParameter("@DepartmentID",user.UserDepartmentID),
                new SQLiteParameter("@UserName",user.UserName),
                new SQLiteParameter("@IsEnable", user.IsEnable),
                new SQLiteParameter("@IsDelete","N")
             };

            return SqlHelper.ExecuteNonQuery(sql, sqlparamter) == 1;

        }
        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool UpdateUser(UserItems user)
        {
            string sql = "Update table_user  set UserName=@UserName, DepartmentID=@DepartmentID,IsEnable=@IsEnable where ObjectID=@ObjectID";

            SQLiteParameter[] sqlparamter = new SQLiteParameter[]
             {
                new SQLiteParameter("@ObjectID", user.ObjectID),
                 new SQLiteParameter("@DepartmentID",user.UserDepartmentID),
                new SQLiteParameter("@UserName",user.UserName),
                new SQLiteParameter("@IsEnable", user.IsEnable),
             };

            return SqlHelper.ExecuteNonQuery(sql, sqlparamter) == 1;

        } /// <summary>
          /// 删除用户
          /// </summary>
          /// <param name="units"></param>
          /// <returns></returns>
        public bool DeleteUser(string objectID)
        {
            string sql = "Update table_user  set  IsDelete=@IsDelete where ObjectID=@ObjectID";

            SQLiteParameter[] sqlparamter = new SQLiteParameter[]
             {
                new SQLiteParameter("@ObjectID", objectID),
                new SQLiteParameter("@IsDelete","Y"),

             };

            return SqlHelper.ExecuteNonQuery(sql, sqlparamter) == 1;

        }

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <param name="restaurantID"></param>
        /// <returns></returns>
        public List<UserItems> GetUsers()
        {
            string sql = @"select user.ObjectID,  user.departmentID,td.departmentname,user.UserName,(case when user.IsEnable='Y' then '可用' else '停用' end ) as IsEnable
                           from table_user as user left join table_department as td on user.departmentid=td.objectid  
                           where user.isdelete='N'";

            var table = SqlHelper.ExecuteReader(sql);

            return ConvertDataTableToList<UserItems>(ConvertUserItems, table);
        }

        /// <summary>
        /// 获取单个用户
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public UserItems GetUser(string userID)
        {
            string sql = @"select user.ObjectID,  user.departmentID,td.departmentname,user.UserName,(case when user.IsEnable='Y' then '可用' else '停用' end ) as IsEnable
                           from table_user as user left join table_department as td on user.departmentid=td.objectid  
                           where    user.ObjectId=@UserID";
            SQLiteParameter[] sqlparamter = new SQLiteParameter[]
           {  new SQLiteParameter("@UserID", userID) };

            DataTable dt_Units = new SqlHelper().ExecuteReader(sql, sqlparamter);

            if (dt_Units.Rows.Count > 0)
            {
                return ConvertUserItems(dt_Units.Rows[0]);
            }
            else
            {
                return null;
            }
        }
    }
}
