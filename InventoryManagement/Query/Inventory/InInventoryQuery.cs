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
    public class InInventoryQuery : Query
    {
        public bool DoInventoryIn(InventoryItems items)
        {
            var sql = "insert into table_InventoryIn (ObjectID,MaterialID,Price,Number,CreatedTime,Mark)values(@ObjectID,@MaterialID,@Price,@Number,@CreatedTime,@Mark)";
            SQLiteParameter[] parameter = new SQLiteParameter[]
            {
                 new SQLiteParameter("@ObjectID", items.ObjectID),
                 new SQLiteParameter("@MaterialID", items.MaterialID),
                 new SQLiteParameter("@Price", items.Price),
                 new SQLiteParameter("@Number", items.Number),
                 new SQLiteParameter("@CreatedTime", items.CreatedTime),
                 new SQLiteParameter("@Mark", items.Mark)
            };

            return SqlHelper.ExecuteNonQuery(sql, parameter) == 1;
        }

        public bool DoUpdateInventory(InventoryItems items)
        {
            var sql = @"update table_InventoryIn set price=@Price,number=@Number,createdtime=@CreatedTime,mark=@Mark where ObjectID=@ObjectID";
            SQLiteParameter[] parameter = new SQLiteParameter[]
           {
                 new SQLiteParameter("@ObjectID", items.ObjectID),
                 new SQLiteParameter("@MaterialID", items.MaterialID),
                 new SQLiteParameter("@Price", items.Price),
                 new SQLiteParameter("@Number", items.Number),
                 new SQLiteParameter("@CreatedTime", items.CreatedTime),
                 new SQLiteParameter("@Mark", items.Mark)
           };

            return SqlHelper.ExecuteNonQuery(sql, parameter) == 1;
        }

        public DataTable GetInventoryInData(string materialName, double startTime, double finishTime)
        {
            var parameters = new List<SQLiteParameter>();

            var sql = @"select ti.ObjectID,ti.MaterialID,tm.MaterialName,tu.UnitName,ti.Price,ti.Number,ti.CreatedTime,ti.Mark
                        from table_InventoryIn as ti
                        LEFT JOIN table_Materials as tm on ti.MaterialID=tm.ObjectID
                        LEFT JOIN table_Units as tu on tm.MaterialUnit=tu.ObjectID
                        where  CreatedTime between @StartTime and @FinishTime ";

            parameters.Add(new SQLiteParameter("@StartTime", startTime));
            parameters.Add(new SQLiteParameter("@FinishTime", finishTime));
            if (!String.IsNullOrEmpty(materialName))
            {
                sql += " and   tm.MaterialName like '%" + materialName + "%'";
            }
            return SqlHelper.ExecuteReader(sql, parameters.ToArray());
        }

        public InventoryItems GetInventoryData(string objectID)
        {
            var sql = @"select * from table_InventoryIn as ti where ti.objectID=@ObjectID";
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
                    Number = double.Parse(table.Rows[0]["Number"].ToString()),
                    Price = double.Parse(table.Rows[0]["Price"].ToString()),
                    CreatedTime = Int64.Parse(table.Rows[0]["CreatedTime"].ToString()),
                    Mark = table.Rows[0]["Mark"].ToString()
                };
            }
            else
            { return null; }
        }
    }
}
