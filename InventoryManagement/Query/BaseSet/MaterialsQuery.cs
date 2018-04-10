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
    public class MaterialsQuery : Query
    {

        private Func<DataRow, MaterialItems> ConvertMaterialItems = Row =>
        {

            return new MaterialItems()
            {
                ObjectID = Row.Field<string>("ObjectID"),
                MaterialName = Row.Field<string>("MaterialName"),
                UnitID = Row.Field<string>("MaterialUnit"),
                UnitName = Row.Field<string>("UnitName"),
                IsEnable = Row.Field<string>("IsEnable"),
            };
        };

        /// <summary>
        /// 新增物品
        /// </summary>
        /// <param name="units"></param>
        /// <returns></returns>
        public bool InsertMaterials(MaterialItems material)
        {
            string sql = "INSERT into table_materials (ObjectID,MaterialName,MaterialUnit,IsEnable,IsDelete) VALUES(@ObjectID,@MaterialName,@MaterialUnit,@IsEnable,@IsDelete)";

            SQLiteParameter[] sqlparamter = new SQLiteParameter[]
             {
                new SQLiteParameter("@ObjectID", material.ObjectID),
                new SQLiteParameter("@MaterialName",material.MaterialName),
                new SQLiteParameter("@MaterialUnit",material.UnitID),
                new SQLiteParameter("@IsEnable", material.IsEnable),
                new SQLiteParameter("@IsDelete","N")
             };

            return SqlHelper.ExecuteNonQuery(sql, sqlparamter) == 1;

        }
        /// <summary>
        /// 修改物品
        /// </summary>
        /// <param name="units"></param>
        /// <returns></returns>
        public bool UpdateMaterial(MaterialItems material)
        {
            string sql = "Update table_materials  set  MaterialName=@MaterialName,MaterialUnit=@MaterialUnit,IsEnable=@IsEnable where ObjectID=@ObjectID";

            SQLiteParameter[] sqlparamter = new SQLiteParameter[]
             {
                new SQLiteParameter("@ObjectID", material.ObjectID),
                new SQLiteParameter("@MaterialName",material.MaterialName),
                new SQLiteParameter("@MaterialUnit",material.UnitID),
                new SQLiteParameter("@IsEnable", material.IsEnable),
             };

            return SqlHelper.ExecuteNonQuery(sql, sqlparamter) == 1;

        }
        /// <summary>
        /// 删除物品
        /// </summary>
        /// <param name="units"></param>
        /// <returns></returns>
        public bool DeleteMaterials(string objectID)
        {
            string sql = "Update table_materials  set  IsDelete=@IsDelete where ObjectID=@ObjectID";

            SQLiteParameter[] sqlparamter = new SQLiteParameter[]
             {
                new SQLiteParameter("@ObjectID", objectID),
                new SQLiteParameter("@IsDelete","Y"),

             };

            return SqlHelper.ExecuteNonQuery(sql, sqlparamter) == 1;

        }
        /// <summary>
        /// 获取所有物品信息
        /// </summary>
        /// <param name="restaurantID"></param>
        /// <returns></returns>
        public List<MaterialItems> GetMaterials()
        {
            string sql = @"select tm.ObjectID,  tm.MaterialName,tm.MaterialUnit,tu.UnitName, (case when tm.IsEnable='Y' then '可用' else'停用' end  ) as IsEnable
                          from table_materials as tm left join table_units as tu on tm.materialUnit=tu.objectID  
                          where tm.isdelete='N'";

            var table = SqlHelper.ExecuteReader(sql);

            return ConvertDataTableToList<MaterialItems>(ConvertMaterialItems, table);

        }
        /// <summary>
        /// 获取单个计量单位
        /// </summary>
        /// <param name="UnitsID"></param>
        /// <returns></returns>
        public MaterialItems GetMatrerial(string MaterialID)
        {
            string sql = @"select tm.*,tu.UnitName 
                           from table_materials as tm  left join table_units as tu on tm.materialUnit=tu.objectID  
                           where tm.ObjectId=@MaterialID";

            SQLiteParameter[] sqlparamter = new SQLiteParameter[]
           {  new SQLiteParameter("@MaterialID", MaterialID) };

            DataTable dt_Units = SqlHelper.ExecuteReader(sql, sqlparamter);

            if (dt_Units.Rows.Count > 0)
            {
                return ConvertMaterialItems(dt_Units.Rows[0]);
            }
            else
            {
                return null;
            }
        }
    }
}
