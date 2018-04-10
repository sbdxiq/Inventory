﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;
using System.Threading;
using NPOI.HSSF.UserModel;
namespace InventoryManagement.DataBase
{
    public static class ExcelHelper
    {

        /// <summary>
        /// Datable导出成Excel
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="file">导出路径(包括文件名与扩展名)</param>
        public static bool ExportToExcel(DataTable dt, string file)
        {
            var success = false;
            try
            {
                IWorkbook workbook;
                string fileExt = Path.GetExtension(file).ToLower();
                if (fileExt == ".xlsx") { workbook = new XSSFWorkbook(); } else if (fileExt == ".xls") { workbook = new HSSFWorkbook(); } else { workbook = null; }
                if (workbook == null) { return false; }
                ISheet sheet = string.IsNullOrEmpty(dt.TableName) ? workbook.CreateSheet("Sheet1") : workbook.CreateSheet(dt.TableName);

                //表头  
                IRow row = sheet.CreateRow(0);
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    ICell cell = row.CreateCell(i);
                    cell.SetCellValue(dt.Columns[i].ColumnName);
                }

                //数据  
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    IRow row1 = sheet.CreateRow(i + 1);
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        ICell cell = row1.CreateCell(j);
                        cell.SetCellValue(dt.Rows[i][j].ToString());
                    }
                }

                //转为字节数组  
                MemoryStream stream = new MemoryStream();
                workbook.Write(stream);
                var buf = stream.ToArray();

                //保存为Excel文件  
                using (FileStream fs = new FileStream(file, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(buf, 0, buf.Length);
                    fs.Flush();
                }

                success = true;
            }
            catch (Exception exp)
            {
                throw exp;
            }
            return success;
        }


        public static DataTable ConvertGridViewToDataTable(DataGridView gridview)
        {


            var table = new DataTable();

            for (int index = 0; index < gridview.Columns.Count; index++)
            {
                if (gridview.Columns[index].Visible)
                {
                    table.Columns.Add(gridview.Columns[index].HeaderText);
                }

            }

            for (int i = 0; i < gridview.Rows.Count; i++)
            {
                var columnIndex = 0;
                DataRow dr = table.NewRow();

                for (int j = 0; j < gridview.Columns.Count; j++)
                {
                    if (gridview.Columns[j].Visible)
                    {
                        dr[columnIndex] = gridview.Rows[i].Cells[j].Value.ToString();
                        columnIndex++;
                    }
                }
                table.Rows.Add(dr);
            }

            return table;



        }
    }
}