using InventoryManagement.DataBase;
using InventoryManagement.QueryModel.Inventory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace InventoryManagement.Query.Inventory
{
    public class OutInventroyQuery : Query
    {

        public bool DoInventoryOut(InventoryItems items)
        {
            var sql = "insert into table_InventoryOut (ObjectID,MaterialID,UserID,Number,CreatedTime,Mark)values(@ObjectID,@MaterialID,@UserID,@Number,@CreatedTime,@Mark)";
            SQLiteParameter[] parameter = new SQLiteParameter[]
            {
                 new SQLiteParameter("@ObjectID", items.ObjectID),
                 new SQLiteParameter("@MaterialID", items.MaterialID),
                 new SQLiteParameter("@UserID", items.UserID),
                 new SQLiteParameter("@Number", items.Number),
                 new SQLiteParameter("@CreatedTime", items.CreatedTime),
                 new SQLiteParameter("@Mark", items.Mark)
            };

            return SqlHelper.ExecuteNonQuery(sql, parameter) == 1;
        }

        public bool DoInventoryUpdate(InventoryItems items)
        {
            var sql = "update table_InventoryOut set  UserID=@UserID,Number=@Number,CreatedTime=@CreatedTime,Mark=@Mark where ObjectID=@ObjectID ";
            SQLiteParameter[] parameter = new SQLiteParameter[]
            {
                 new SQLiteParameter("@ObjectID", items.ObjectID),
                 new SQLiteParameter("@MaterialID", items.MaterialID),
                 new SQLiteParameter("@UserID", items.UserID),
                 new SQLiteParameter("@Number", items.Number),
                 new SQLiteParameter("@CreatedTime", items.CreatedTime),
                 new SQLiteParameter("@Mark", items.Mark)
            };

            return SqlHelper.ExecuteNonQuery(sql, parameter) == 1;
        }
        public DataTable GetInventoryOutData(string materialName, double startTime, double finishTime)
        {
            var parameters = new List<SQLiteParameter>();

            var sql = @"select out.ObjectID,out.MaterialID,tm.MaterialName,tm.MaterialUnit,tu.UnitName,out.userID,user.UserName,user.DepartmentID,td.DepartmentName,out.Number,out.CreatedTime,out.Mark
                        from table_InventoryOut as out
                        LEFT JOIN table_Materials as tm on out.MaterialID=tm.ObjectID
                        LEFT JOIN table_Units as tu on tm.MaterialUnit=tu.ObjectID
                        LEFT JOIN table_User as user on out.UserID=user.ObjectID
                        LEFT JOIN table_Department as td on user.departmentID=td.ObjectID
                        where out.CreatedTime between @StartTime and @FinishTime";

            parameters.Add(new SQLiteParameter("@StartTime", startTime));
            parameters.Add(new SQLiteParameter("@FinishTime", finishTime));
            if (!String.IsNullOrEmpty(materialName))
            {
                sql += " and  tm.MaterialName like '%" + materialName + "%'";
            }
            return SqlHelper.ExecuteReader(sql, parameters.ToArray());
        }

        public InventoryItems GetInventoryOutData(string objectID)
        {
            var sql = "select * from table_InventoryOut where ObjectID=@ObjectID";
            SQLiteParameter[] parameter = new SQLiteParameter[]
            {
                 new SQLiteParameter("@ObjectID", objectID)
            };
            var table = SqlHelper.ExecuteReader(sql, parameter);

            if (table.Rows.Count > 0)
            {
                return new InventoryItems
                {
                    ObjectID = table.Rows[0]["ObjectID"].ToString(),
                    MaterialID = table.Rows[0]["MaterialID"].ToString(),
                    UserID = table.Rows[0]["UserID"].ToString(),
                    Number = double.Parse(table.Rows[0]["Number"].ToString()),
                    CreatedTime = Int64.Parse(table.Rows[0]["CreatedTime"].ToString()),
                    Mark = table.Rows[0]["Mark"].ToString()

                };
            }
            else
            {
                return null;
            }
        }
    }
}
