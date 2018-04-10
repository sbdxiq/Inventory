using InventoryManagement.DataBase;
using InventoryManagement.QueryModel.Inventory;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace InventoryManagement.Query.Inventory
{
    public class CurrentInventoryQuery : Query
    {

        private Func<DataRow, CurrentInventoryItems> ConvertCurrentInventoryItems = Row =>
          {
              return new CurrentInventoryItems
              {

                  ObjectID = Row.Field<string>("ObjectID"),
                  MaterialID = Row.Field<string>("MaterialID"),
                  MaterialName = Row.Field<string>("MaterialName"),
                  UnitName = Row.Field<string>("UnitName"),
                  CurrentCount = int.Parse( Row.Field<Int64>("CurrentCount").ToString())
              };
          };

        /// <summary>
        /// 获取库存信息
        /// </summary>
        /// <param name="materialID"></param>
        /// <param name="objectID"></param>
        /// <returns></returns>
        public List<CurrentInventoryItems> GetCurrentInventory(string materialID = "", string objectID = "")
        {
            var table = new DataTable();

            var sql = @"select cy.ObjectID,cy.MaterialID, tm.materialName  ,tu.UnitName ,cy.CurrentCount 
                        from table_CurentInventory as cy 
                        left join table_Materials  as tm on cy.materialID=tm.ObjectID 
                        left join  table_Units as tu on tm.Materialunit=tu.ObjectID
                        where 1=1";

            if (!String.IsNullOrEmpty(materialID) || !String.IsNullOrEmpty(objectID))
            {
                List<SQLiteParameter> list = new List<SQLiteParameter>();

                if (!String.IsNullOrEmpty(materialID))
                {
                    sql += " and cy.MaterialID=@MaterialID";
                    list.Add(new SQLiteParameter("@MaterialID", materialID));

                }
                if (!String.IsNullOrEmpty(objectID))
                {
                    sql += " and cy.ObjectID=@ObjectID";
                    list.Add(new SQLiteParameter("@ObjectID", objectID));
                }

                table = SqlHelper.ExecuteReader(sql, list.ToArray());
            }
            else
            {
                table = SqlHelper.ExecuteReader(sql);
            }

            return ConvertDataTableToList<CurrentInventoryItems>(ConvertCurrentInventoryItems, table);
        }
        /// <summary>
        /// 增加新物资库存
        /// </summary>
        /// <param name="objectID"></param>
        /// <param name="materialID"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public bool InsertInventory(string objectID, string materialID, double count)
        {
            var sql = "insert into  table_CurentInventory  (ObjectID,currentcount,materialID) values(@ObjectID,@currentcount,@materialID)";

            SQLiteParameter[] parameter = new SQLiteParameter[]
            {
                new SQLiteParameter("@ObjectID", objectID),
                new SQLiteParameter("@currentcount",count),
                new SQLiteParameter("@materialID",materialID)
            };

            return new SqlHelper().ExecuteNonQuery(sql, parameter) == 1;

        }



        /// <summary>
        /// 更新库存数量
        /// </summary>
        /// <param name="materialID"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public bool DoUpdateCurrentInventory(string materialID, double count)
        {
            var sql = "update table_CurentInventory set currentcount=currentcount+@currentcount where materialID=@materialID";

            SQLiteParameter[] parameter = new SQLiteParameter[]
            {
                new SQLiteParameter("@materialID",materialID),
                new SQLiteParameter("@currentcount",count),
            };

            return new SqlHelper().ExecuteNonQuery(sql, parameter) == 1;
        }
    }
}
