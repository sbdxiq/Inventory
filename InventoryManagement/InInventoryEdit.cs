using InventoryManagement.DataBase;
using InventoryManagement.Query.BaseSet;
using InventoryManagement.Query.Inventory;
using InventoryManagement.QueryModel.BaseSet;
using InventoryManagement.QueryModel.Inventory;
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
    public partial class InInventoryEdit : Form
    {
        public string ObjectID { get; set; }
        private double OldNumber { get; set; }
        public InInventoryEdit()
        {
            InitializeComponent();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
            this.skinEngine1.SkinFile = Application.StartupPath + "//DiamondBlue.ssk";

            Sunisoft.IrisSkin.SkinEngine se = null;
            se = new Sunisoft.IrisSkin.SkinEngine();
            se.SkinAllForm = true;
        }

        private void InventoryEdit_Load(object sender, EventArgs e)
        {

            var data = new InInventoryQuery().GetInventoryData(ObjectID);
            if (data != null)
            {
                Com_Material_Input.Items.Clear();
                var items = new MaterialsQuery().GetMaterials();
                var lists = items.Where(t => t.ObjectID == data.MaterialID);

                Com_Material_Input.DataSource = lists.ToList();
                Com_Material_Input.DisplayMember = "MaterialName";
                Com_Material_Input.ValueMember = "ObjectID";


                Com_Material_Input.SelectedIndexChanged += new EventHandler(Com_Material_Input_SelectedIndexChanged);
                Com_Material_Input.SelectedValue = data.MaterialID;
                Com_Material_Input_SelectedIndexChanged(sender, e);

                Num_Number_Input.Value = (decimal)data.Number;
                OldNumber = data.Number;
                Num_Price_InPut.Value = (decimal)data.Price;
                Time_InPutTime_Input.Value = DateTime.FromFileTimeUtc((long)data.CreatedTime);
                Txt_Mark_Input.Text = data.Mark;
            }
            else
            {
                MessageBox.Show("未获取到入库记录信息");
            }
        }

        private void Com_Material_Input_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Com_Material_Input.SelectedIndex == -1)
                return;

            var materialID = Com_Material_Input.SelectedValue.ToString();
            var material = new MaterialsQuery().GetMatrerial(materialID);

            Txt_Unit_Input.Text = material.UnitName;
        }

        private void Btn_Reset_Input_Click(object sender, EventArgs e)
        {
            this.Close();
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
                ObjectID = ObjectID,
                MaterialID = Com_Material_Input.SelectedValue.ToString(),
                Price = (double)Num_Price_InPut.Value,
                Number = (double)Num_Number_Input.Value,
                CreatedTime = Time_InPutTime_Input.Value.ToFileTimeUtc(),
                Mark = Txt_Mark_Input.Text

            };

            try
            {
                var isISuccess = new InInventoryQuery().DoUpdateInventory(item);


                if (isISuccess)
                {
                    var IsCSuccess = new CurrentInventoryQuery().DoUpdateCurrentInventory(item.MaterialID, -(OldNumber - item.Number));
                    if (IsCSuccess)
                    {
                        MessageBox.Show("修改成功");
                        this.Close();
                    }

                    else
                    {
                        MessageBox.Show("记录修改成功，但当前库存更新失败，请联系管理员进行库存盘点。");
                    }
                }
                else
                {
                    MessageBox.Show("记录修改失败，请关闭窗口重试。");
                }

            }
            catch (Exception exp)
            {
                MessageBox.Show("保存失败，" + exp.Message);
            }
        }
    }
}
