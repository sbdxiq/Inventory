using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace InventoryManagement.DataBase
{
    public enum DbType
    {
        Oracle, SqlServer, MySql, Access, SqlLite,
        NONE,
        ORACLE,
        SQLSERVER,
        MYSQL,
        ACCESS,
        SQLLITE
    }

    public class DBFactory
    {
        public static IDbConnection CreateDbConnection(DbType type, string connectionString)
        {
            IDbConnection conn = null;
            switch (type)
            {

                case DbType.ACCESS:
                    conn = new OleDbConnection(connectionString);
                    break;
                case DbType.SQLLITE:
                    conn = new SQLiteConnection(connectionString);
                    break;
                case DbType.NONE:
                    throw new Exception("未设置数据库类型");
                default:
                    throw new Exception("不支持该数据库类型");
            }
            return conn;
        }


        public static IDbCommand CreateDbCommand(DbType type)
        {
            IDbCommand cmd = null;
            switch (type)
            {


                case DbType.SQLLITE:
                    cmd = new SQLiteCommand();
                    break;
                case DbType.NONE:
                    throw new Exception("未设置数据库类型");
                default:
                    throw new Exception("不支持该数据库类型");
            }
            return cmd;
        }
        public static IDbCommand CreateDbCommand(string sql, IDbConnection conn)
        {
            DbType type = DbType.NONE;

            if (conn is SQLiteConnection)
                type = DbType.SQLLITE;

            IDbCommand cmd = null;
            switch (type)
            {

                case DbType.ACCESS:
                    cmd = new OleDbCommand(sql, (OleDbConnection)conn);
                    break;
                case DbType.SQLLITE:
                    cmd = new SQLiteCommand(sql, (SQLiteConnection)conn);
                    break;
                case DbType.NONE:
                    throw new Exception("未设置数据库类型");
                default:
                    throw new Exception("不支持该数据库类型");
            }
            return cmd;
        }


    }
}