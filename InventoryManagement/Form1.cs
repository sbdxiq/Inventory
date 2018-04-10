using InventoryManagement;
using InventoryManagement.DataBase;
using InventoryManagement.Query.BaseSet;
using InventoryManagement.Query.Inventory;
using InventoryManagement.Query.Origination;
using InventoryManagement.QueryModel.BaseSet;
using InventoryManagement.QueryModel.Inventory;
using InventoryManagement.QueryModel.Origination;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InventoryManagement
{
    public partial class Index : Form
    {
        public Index()
        {
            InitializeComponent();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
            this.skinEngine1.SkinFile = Application.StartupPath + "//DiamondBlue.ssk";

            Sunisoft.IrisSkin.SkinEngine se = null;
            se = new Sunisoft.IrisSkin.SkinEngine();
            se.SkinAllForm = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Tbtn_Inventory_Click(sender, e);
        }

        private void Tbtn_Inventory_Click(object sender, EventArgs e)
        {
            Tab_Inventory.Parent = tabControl1;
            Tab_Organization.Parent = null;
            Tab_BaseSet.Parent = null;
            bingCurrent();
        }

        private void Tbtn_Organization_Click(object sender, EventArgs e)
        {
            Tab_Inventory.Parent = null;
            Tab_Organization.Parent = tabControl1;
            Tab_BaseSet.Parent = null;
            BingDepartment();
        }

        private void Tbtn_BaseSet_Click(object sender, EventArgs e)
        {
            Tab_Inventory.Parent = null;
            Tab_Organization.Parent = null;
            Tab_BaseSet.Parent = tabControl1;
            BingMaterial();
        }

        private void Btn_Material_Add_Click(object sender, EventArgs e)
        {
            Material material = new Material();
            material.ShowDialog();
            BingMaterial();
        }

        private void Btn_Unit_Add_Click(object sender, EventArgs e)
        {
            Units units = new Units();
            units.ShowDialog();
            BingUnit();
        }

        private void Btn_Unit_Query_Click(object sender, EventArgs e)
        {
            BingUnit();
        }

        void BingUnit()
        {
            GridView_Unit.DataSource = new UnitsQuery().GetUnitsList();
            GridView_Unit.Columns["ObjectID"].Visible = false;
            GridView_Unit.Columns["IsDelete"].Visible = false;
        }
        private void Btn_Unit_Edit_Click(object sender, EventArgs e)
        {
            var selectRow = GridView_Unit.CurrentRow;
            if (selectRow == null)
            {
                MessageBox.Show("请选择要编辑的行");
                return;
            }

            var objectID = GridView_Unit.CurrentRow.Cells["ObjectID"].Value.ToString();
            Units units = new Units();
            units.IsEdit = true;
            units.ObjectID = objectID;
            units.ShowDialog();

            BingUnit();
        }

        private void Btn_Unit_Delete_Click(object sender, EventArgs e)
        {
            var selectIndex = GridView_Unit.CurrentRow.Index;
            if (selectIndex == -1)
            {
                MessageBox.Show("请选择要删除的行");
                return;
            }

            if (MessageBox.Show("确认删除选中内容？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var objectID = GridView_Unit.CurrentRow.Cells["ObjectID"].Value.ToString();
                new UnitsQuery().DeleteUnits(objectID);
                BingUnit();
            }
        }

        private void btn_Material_Query_Click(object sender, EventArgs e)
        {
            BingMaterial();
        }
        void BingMaterial()
        {
            GridView_Material.DataSource = new MaterialsQuery().GetMaterials();
            GridView_Material.Columns["ObjectID"].Visible = false;
            GridView_Material.Columns["UnitID"].Visible = false;
            GridView_Material.Columns["IsDelete"].Visible = false;
        }

        private void Btn_Material_Edit_Click(object sender, EventArgs e)
        {
            var selectRow = GridView_Material.CurrentRow;
            if (selectRow == null)
            {
                MessageBox.Show("请选择要编辑的行");
                return;
            }

            var objectID = GridView_Material.CurrentRow.Cells["ObjectID"].Value.ToString();
            Material material = new Material();
            material.IsEdit = true;
            material.MaterialID = objectID;
            material.ShowDialog();
            BingMaterial();
        }

        private void Btn_Material_Delete_Click(object sender, EventArgs e)
        {
            var selectIndex = GridView_Material.CurrentRow.Index;
            if (selectIndex == -1)
            {
                MessageBox.Show("请选择要删除的行");
                return;
            }

            if (MessageBox.Show("确认删除选中内容？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var objectID = GridView_Material.CurrentRow.Cells["ObjectID"].Value.ToString();
                new MaterialsQuery().DeleteMaterials(objectID);
                BingMaterial();
            }
        }

        private void Btn_Department_Query_Click(object sender, EventArgs e)
        {
            BingDepartment();
        }

        void BingDepartment()
        {

            GridView_Department.DataSource = new DepartmentQuery().GetDepartments();
            GridView_Department.Columns["ObjectID"].Visible = false;
        }

        private void Btn_Department_Add_Click(object sender, EventArgs e)
        {
            Department department = new Department();
            department.ShowDialog();
            BingDepartment();
        }

        private void Btn_Department_Edit_Click(object sender, EventArgs e)
        {
            var selectIndex = GridView_Department.CurrentRow.Index;
            if (selectIndex == -1)
            {
                MessageBox.Show("请选择要编辑的行");
                return;
            }

            var objectID = GridView_Department.CurrentRow.Cells["ObjectID"].Value.ToString();
            Department department = new Department();
            department.IsEdit = true;
            department.DepartmentID = objectID;
            department.ShowDialog();
            BingDepartment();
        }

        private void Btn_Department_Delete_Click(object sender, EventArgs e)
        {
            var selectIndex = GridView_Department.CurrentRow.Index;
            if (selectIndex == -1)
            {
                MessageBox.Show("请选择要删除的行");
                return;
            }

            if (MessageBox.Show("确认删除选中内容？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var objectID = GridView_Department.CurrentRow.Cells["ObjectID"].Value.ToString();
                new DepartmentQuery().DeleteDepartment(objectID);
                BingDepartment();
            }

        }

        private void Btn_User_Add_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.ShowDialog();
            BingUser();
        }

        private void Btn_User_Query_Click(object sender, EventArgs e)
        {
            BingUser();
        }
        void BingUser()
        {
            var source = new UserQuery().GetUsers().Where(t => t.IsEnable.Equals("可用")).ToList();
            GridView_User.DataSource = source;
            GridView_User.Columns["ObjectID"].Visible = false;
            GridView_User.Columns["UserDepartmentID"].Visible = false;
            GridView_User.Columns["IsDelete"].Visible = false;
        }

        private void Btn_User_Edit_Click(object sender, EventArgs e)
        {
            var selectIndex = GridView_User.CurrentRow.Index;
            if (selectIndex == -1)
            {
                MessageBox.Show("请选择要编辑的行");
                return;
            }

            var objectID = GridView_User.CurrentRow.Cells["ObjectID"].Value.ToString();
            User user = new User();
            user.IsEdit = true;
            user.UserID = objectID;
            user.ShowDialog();
            BingUser();
        }

        private void Btn_User_Delete_Click(object sender, EventArgs e)
        {
            var selectIndex = GridView_User.CurrentRow.Index;
            if (selectIndex == -1)
            {
                MessageBox.Show("请选择要删除的行");
                return;
            }
            if (MessageBox.Show("确认删除选中内容？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var objectID = GridView_Department.CurrentRow.Cells["ObjectID"].Value.ToString();
                new UserQuery().DeleteUser(objectID);
                BingUser();
            }

        }



        private void Tab_Inventory_In_Enter(object sender, EventArgs e)
        {
            BingInvertory(new MaterialsQuery().GetMaterials());
        }

        void BingInvertory(List<MaterialItems> items)
        {
            Com_Material_Input.Items.Clear();

            var lists = items.Where(t => t.IsEnable.Equals("可用"));
            foreach (var list in lists)
            {
                var item = new ComboboxItems(list.MaterialName, list.ObjectID);
                Com_Material_Input.Items.Add(item);
            }
        }


        private void Tab_Inventory_Out_Enter(object sender, EventArgs e)
        {
            bingMaterialOut(new CurrentInventoryQuery().GetCurrentInventory());

            BingComUser(new UserQuery().GetUsers());

        }

        void bingMaterialOut(List<CurrentInventoryItems> items)
        {
            Com_Material_OutPut.Items.Clear();

            foreach (var item in items)
            {
                Com_Material_OutPut.Items.Add(new ComboboxItems(item.MaterialName, item.MaterialID));
            }


            Txt_Unit_OutPut.Text = String.Empty;
        }
        void BingComUser(List<UserItems> items)
        {
            Com_UsingUser.Items.Clear();
            var users = items.Where(t => t.IsEnable.Equals("可用"));

            foreach (var user in users)
            {
                Com_UsingUser.Items.Add(new ComboboxItems(user.UserName, user.ObjectID));
            }


        }
        private void Com_Material_OutPut_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Com_Material_OutPut.SelectedIndex == -1)
                return;

            var materialID = ((ComboboxItems)Com_Material_OutPut.SelectedItem).Value.ToString();
            var material = new MaterialsQuery().GetMatrerial(materialID);
            Txt_Unit_OutPut.Text = material.UnitName;
        }

        private void Btn_Reset_Input_Click(object sender, EventArgs e)
        {
            Com_Material_Input.SelectedIndex = -1;
            Txt_Unit_Input.Text = String.Empty;
            Num_Number_Input.Value = 0;
            Num_Price_InPut.Value = 0;
            Time_InPutTime_Input.Value = DateTime.Now;
            Txt_Mark_Input.Text = string.Empty;
        }

        private void Btn_Save_Input_Click(object sender, EventArgs e)
        {
            if (Com_Material_Input.SelectedIndex == -1)
            {
                MessageBox.Show("请选择入库物品");
                return;
            }
            else if (Num_Number_Input.Value == 0)
            {
                MessageBox.Show("入库数量不得为0");
                return;
            }


            var item = new InventoryItems()
            {
                ObjectID = Guid.NewGuid().ToString(),
                MaterialID = ((ComboboxItems)Com_Material_Input.SelectedItem).Value.ToString(),
                Price = (double)Num_Price_InPut.Value,
                Number = (double)Num_Number_Input.Value,
                CreatedTime = Time_InPutTime_Input.Value.ToFileTimeUtc(),
                Mark = Txt_Mark_Input.Text

            };

            try
            {
                new InInventoryQuery().DoInventoryIn(item);


                var currentInventory = new CurrentInventoryQuery().GetCurrentInventory(item.MaterialID, "");
                if (currentInventory.Any())
                {
                    new CurrentInventoryQuery().DoUpdateCurrentInventory(item.MaterialID, item.Number);
                }
                else
                {

                    while (currentInventory.Any(t => t.ObjectID.Equals(item.ObjectID)))
                    {
                        item.ObjectID = Guid.NewGuid().ToString();
                    }
                    new CurrentInventoryQuery().InsertInventory(item.ObjectID, item.MaterialID, item.Number);
                }
                MessageBox.Show("保存成功");
                Btn_Reset_Input_Click(sender, e);
            }
            catch (Exception exp)
            {
                MessageBox.Show("保存失败，" + exp.Message);
            }
        }

        private void Btn_Search_CurrentInventory_Click(object sender, EventArgs e)
        {
            bingCurrent();
        }

        void bingCurrent()
        {
            GridView_CurrentInventory.AutoGenerateColumns = false;
            GridView_CurrentInventory.DataSource = new CurrentInventoryQuery().GetCurrentInventory();
        }

        private void GridView_Material_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            for (int i = 0; i < GridView_Material.Rows.Count; i++)
            {
                GridView_Material.Rows[i].Cells[0].Value = (i + 1);
            }
        }

        private void GridView_Unit_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            for (int i = 0; i < GridView_Unit.Rows.Count; i++)
            {
                GridView_Unit.Rows[i].Cells[0].Value = (i + 1);
            }
        }

        private void GridView_Department_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            for (int i = 0; i < GridView_Department.Rows.Count; i++)
            {
                GridView_Department.Rows[i].Cells[0].Value = (i + 1);
            }
        }

        private void GridView_User_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            for (int i = 0; i < GridView_User.Rows.Count; i++)
            {
                GridView_User.Rows[i].Cells[0].Value = (i + 1);
            }
        }

        private void GridView_CurrentInventory_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            for (int i = 0; i < GridView_CurrentInventory.Rows.Count; i++)
            {
                GridView_CurrentInventory.Rows[i].Cells[0].Value = (i + 1);
                var currentNum = double.Parse(GridView_CurrentInventory.Rows[i].Cells["CurrentNumber"].Value.ToString());
                if (currentNum <= 3)
                {
                    GridView_CurrentInventory.Rows[i].DefaultCellStyle.BackColor = Color.Pink;

                }
            }
        }

        private void Num_Price_InPut_Click(object sender, EventArgs e)
        {
            UpDownBase updbText = (UpDownBase)Num_Price_InPut;
            Num_Price_InPut.Select(0, updbText.Text.Length);
            
        }

        private void Num_Number_Input_Click(object sender, EventArgs e)
        {
            Num_Number_Input.Select(0, Num_Number_Input.Value.ToString().Length);
        }

        private void Btn_Query_InPut_Click(object sender, EventArgs e)
        {
            BingInPutQuery();
        }
        void BingInPutQuery()
        {

            // GridView_InPut.AutoGenerateColumns = false;

            var pMaterial = txt_InventoeyIn_MaterialName.Text;
            var pStartTime = Time_Start_Input.Value.Date.ToFileTimeUtc();
            var pFinishTime = Time_Finish_Input.Value.AddDays(1).Date.AddMilliseconds(-1).ToFileTimeUtc();

            var tableItem = new InInventoryQuery().GetInventoryInData(pMaterial, pStartTime, pFinishTime);

            var newTable = tableItem.Clone();
            newTable.Columns[6].DataType = typeof(string);
            foreach (DataRow dr in tableItem.Rows)
            {
                newTable.LoadDataRow(new object[] { dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], DateTime.FromFileTimeUtc(long.Parse(dr["Createdtime"].ToString())).ToShortDateString(), dr[7] }, true);
            }
            GridView_InPut.DataSource = newTable;

            GridView_InPut.Columns["ObjectID"].Visible = false;
            GridView_InPut.Columns["MaterialID"].Visible = false;
        }

        private void GridView_InPut_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            for (int i = 0; i < GridView_InPut.Rows.Count; i++)
            {
                GridView_InPut.Rows[i].Cells["InPutOrderNum"].Value = (i + 1);
                var price = double.Parse(GridView_InPut.Rows[i].Cells["InputPrice"].Value.ToString());
                var number = double.Parse(GridView_InPut.Rows[i].Cells["InputCount"].Value.ToString());
                GridView_InPut.Rows[i].Cells["TotalPrice"].Value = price * number;

            }
        }

        private void Btn_Reset_OutPut_Click(object sender, EventArgs e)
        {
            Com_Material_OutPut.SelectedIndex = -1;
            Txt_Unit_OutPut.Text = String.Empty;
            Com_UsingUser.SelectedIndex = -1;
            Num_Number_OutPut.Value = 0;
            Time_OutPutTime_Output.Value = DateTime.Now;
            Txt_Mark_OutPut.Text = String.Empty;
        }

        private void Btn_Save_OutPut_Click(object sender, EventArgs e)
        {
            if (Com_Material_OutPut.SelectedIndex < 0)
            {
                MessageBox.Show("请选择出库物品");
                return;
            }
            else if (Com_UsingUser.SelectedIndex < 0)
            {
                MessageBox.Show("请选择领用人");
                return;
            }
            else if (Num_Number_OutPut.Value <= 0)
            {
                MessageBox.Show("请输入领用数量");
                return;
            }


            var item = new InventoryItems()
            {
                ObjectID = Guid.NewGuid().ToString(),
                MaterialID = ((ComboboxItems)Com_Material_OutPut.SelectedItem).Value.ToString(),
                UserID = ((ComboboxItems)Com_UsingUser.SelectedItem).Value.ToString(),
                Number = (double)Num_Number_OutPut.Value,
                CreatedTime = Time_OutPutTime_Output.Value.ToFileTimeUtc(),
                Mark = Txt_Mark_OutPut.Text

            };

            var currentInventory = new CurrentInventoryQuery().GetCurrentInventory(item.MaterialID, "");

            if (currentInventory.Any())
            {
                var currentNum = currentInventory[0].CurrentCount;
                if (currentNum < item.Number)
                {
                    MessageBox.Show("当前库存量不能满足出库要求，剩余库存" + currentNum);
                    return;
                }
                else
                {
                    new OutInventroyQuery().DoInventoryOut(item);
                    new CurrentInventoryQuery().DoUpdateCurrentInventory(item.MaterialID, item.Number - (item.Number * 2));
                    MessageBox.Show("保存成功");
                    Btn_Reset_OutPut_Click(sender, e);

                }
            }
            else
            {
                MessageBox.Show("未能找到当前物品的库存信息，请确认。");
                return;
            }
        }

        private void Btn_Query_OutPut_Click(object sender, EventArgs e)
        {
            BingOutPutQuery();
        }

        void BingOutPutQuery()
        {
            GridView_OutPut.AutoGenerateColumns = false;

            var pMaterial = Txt_Material_OutPut.Text;
            var pStartTime = Time_Start_OutPut.Value.Date.ToFileTimeUtc();
            var pFinishTime = Time_Finish_OutPut.Value.AddDays(1).Date.AddMilliseconds(-1).ToFileTimeUtc();

            var tableItem = new OutInventroyQuery().GetInventoryOutData(pMaterial, pStartTime, pFinishTime);

            var newTable = tableItem.Clone();
            newTable.Columns[10].DataType = typeof(string);
            foreach (DataRow dr in tableItem.Rows)
            {
                newTable.LoadDataRow(new object[] { dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], dr[7], dr[8], dr[9], DateTime.FromFileTimeUtc(long.Parse(dr["Createdtime"].ToString())).ToShortDateString(), dr[11] }, true);
            }
            GridView_OutPut.DataSource = newTable;

            GridView_OutPut.Columns[12].Visible = false;
        }
        private void GridView_OutPut_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            for (int i = 0; i < GridView_OutPut.Rows.Count; i++)
            {
                GridView_OutPut.Rows[i].Cells[0].Value = (i + 1);
            }

        }

        private void Tab_Unit_Enter(object sender, EventArgs e)
        {
            BingUnit();
        }

        private void Tab_Material_Enter(object sender, EventArgs e)
        {
            BingMaterial();
        }

        private void Tab_Department_Enter(object sender, EventArgs e)
        {
            BingDepartment();
        }

        private void Tab_User_Enter(object sender, EventArgs e)
        {
            BingUser();
        }

        private void Tab_Quyery_Input_Enter(object sender, EventArgs e)
        {
            Time_Start_Input.Value = DateTime.Now.AddDays(-DateTime.Now.Day + 1).Date;
            BingInPutQuery();
        }

        private void Tab_Query_Output_Enter(object sender, EventArgs e)
        {
            Time_Start_OutPut.Value = DateTime.Now.AddDays(-DateTime.Now.Day + 1).Date;
            BingOutPutQuery();
        }

        private void Btn_Export_InPut_Click(object sender, EventArgs e)
        {

            var InInventoryTable = ExcelHelper.ConvertGridViewToDataTable(GridView_InPut);
            InInventoryTable.Columns["序号"].SetOrdinal(0);
            InInventoryTable.Columns["物品名称"].SetOrdinal(1);
            InInventoryTable.Columns["计量单位"].SetOrdinal(2);
            InInventoryTable.Columns["单价"].SetOrdinal(3);
            InInventoryTable.Columns["数量"].SetOrdinal(4);
            InInventoryTable.Columns["总价"].SetOrdinal(5);
            InInventoryTable.Columns["入库日期"].SetOrdinal(6);
            InInventoryTable.Columns["备注"].SetOrdinal(7);

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel 工作簿（*.xlsx）|*.xlsx|Excel 启动宏的工作簿（*.xlsm）|*.xlsm|Excel 97-2003工作簿（*.xls）|*.xls";
            if (save.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            else
            {
                try
                {
                    if (ExcelHelper.ExportToExcel(InInventoryTable, save.FileName))
                    {
                        MessageBox.Show("保存成功");
                    }
                    else
                    {
                        MessageBox.Show("保存失败原因未知，请重试");
                    }
                }
                catch (Exception exp)
                {
                    MessageBox.Show("导出失败，" + exp.Message);
                }

            }
        }

        private void Btn_Exprot_OutPut_Click(object sender, EventArgs e)
        {
            var OutInventoryTable = ExcelHelper.ConvertGridViewToDataTable(GridView_OutPut);
            OutInventoryTable.Columns["序号"].SetOrdinal(0);
            OutInventoryTable.Columns["物品名称"].SetOrdinal(1);
            OutInventoryTable.Columns["领用人"].SetOrdinal(2);
            OutInventoryTable.Columns["所属部门"].SetOrdinal(3);
            OutInventoryTable.Columns["领用数量"].SetOrdinal(4);
            OutInventoryTable.Columns["计量单位"].SetOrdinal(5);
            OutInventoryTable.Columns["领用日期"].SetOrdinal(6);
            OutInventoryTable.Columns["备注"].SetOrdinal(7);


            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel 工作簿（*.xlsx）|*.xlsx|Excel 启动宏的工作簿（*.xlsm）|*.xlsm|Excel 97-2003工作簿（*.xls）|*.xls";
            if (save.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            else
            {

                try
                {
                    if (ExcelHelper.ExportToExcel(OutInventoryTable, save.FileName))
                    {
                        MessageBox.Show("保存成功");
                    }
                    else
                    {
                        MessageBox.Show("保存失败原因未知，请重试");
                    }
                }
                catch (Exception exp)
                {
                    MessageBox.Show("导出失败，" + exp.Message);
                }
            }
        }

        private void Btn_Export_CurrentInventory_Click(object sender, EventArgs e)
        {
            var CurrentInventoryTable = ExcelHelper.ConvertGridViewToDataTable(GridView_CurrentInventory);
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel 工作簿（*.xlsx）|*.xlsx|Excel 启动宏的工作簿（*.xlsm）|*.xlsm|Excel 97-2003工作簿（*.xls）|*.xls";
            if (save.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            else
            {
                try
                {
                    if (ExcelHelper.ExportToExcel(CurrentInventoryTable, save.FileName))
                    {
                        MessageBox.Show("保存成功");
                    }
                    else
                    {
                        MessageBox.Show("保存失败原因未知，请重试");
                    }
                }
                catch (Exception exp)
                {
                    MessageBox.Show("导出失败，" + exp.Message);
                }
            }
        }

        private void Com_Material_Input_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Com_Material_Input.SelectedIndex == -1)
                return;

            var materialID = ((ComboboxItems)Com_Material_Input.SelectedItem).Value.ToString();
            var material = new MaterialsQuery().GetMatrerial(materialID);

            Txt_Unit_Input.Text = material.UnitName;
        }

        private void Com_Material_Input_TextUpdate(object sender, EventArgs e)
        {
            var items = new MaterialsQuery().GetMaterials();
            if (!String.IsNullOrEmpty(Com_Material_Input.Text))
            {
                var list = items.Where(t => t.MaterialName.Contains(Com_Material_Input.Text));

                BingInvertory(list.ToList());

                Com_Material_Input.SelectionStart = Com_Material_Input.Text.Length;
                Com_Material_Input.DroppedDown = true;
                Cursor = Cursors.Default;
            }
            else
            {
                BingInvertory(items);
            }

        }

        private void Com_Material_OutPut_TextUpdate(object sender, EventArgs e)
        {
            var items = new CurrentInventoryQuery().GetCurrentInventory();

            if (!String.IsNullOrEmpty(Com_Material_OutPut.Text))
            {
                var list = items.Where(t => t.MaterialName.Contains(Com_Material_OutPut.Text));
                bingMaterialOut(list.ToList());

                Com_Material_OutPut.SelectionStart = Com_Material_OutPut.Text.Length;
                Com_Material_OutPut.DroppedDown = true;
                Cursor = Cursors.Default;

            }
            else
            {
                bingMaterialOut(items);
            }

        }

        private void Com_UsingUser_TextUpdate(object sender, EventArgs e)
        {
            var items = new UserQuery().GetUsers();

            if (!String.IsNullOrEmpty(Com_UsingUser.Text))
            {
                var list = items.Where(t => t.UserName.Contains(Com_UsingUser.Text));
                BingComUser(list.ToList());

                Com_UsingUser.SelectionStart = Com_UsingUser.Text.Length;
                Com_UsingUser.DroppedDown = true;
                Cursor = Cursors.Default;
            }
            else
            {

                BingComUser(items);
            }
        }

        private void Btn_Edit_InPut_Click(object sender, EventArgs e)
        {
            var objectID = GridView_InPut.CurrentRow.Cells["ObjectID"].Value.ToString();
            var oldNumber = GridView_InPut.CurrentRow.Cells["InputCount"].Value.ToString();
            InInventoryEdit edit = new InInventoryEdit();
            edit.ObjectID = objectID;
            edit.ShowDialog();
            BingInPutQuery();
        }

        private void Tab_Query_CurrentInventory_Enter(object sender, EventArgs e)
        {
            bingCurrent();
        }

        private void Btn_Edit_OutPut_Click(object sender, EventArgs e)
        {
            var objectID = GridView_OutPut.CurrentRow.Cells[12].Value.ToString();
            OutInventoryEdit edit = new OutInventoryEdit();
            edit.ObjectID = objectID;
            edit.ShowDialog();
            BingOutPutQuery();
        }

        
    }
}
