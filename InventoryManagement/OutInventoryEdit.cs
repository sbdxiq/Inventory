using InventoryManagement.Query.BaseSet;
using InventoryManagement.Query.Inventory;
using InventoryManagement.Query.Origination;
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
    public partial class OutInventoryEdit : Form
    {
        public string ObjectID { get; set; }
        private double OldNumber { set; get; }
        public OutInventoryEdit()
        {
            InitializeComponent();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
            this.skinEngine1.SkinFile = Application.StartupPath + "//DiamondBlue.ssk";

            Sunisoft.IrisSkin.SkinEngine se = null;
            se = new Sunisoft.IrisSkin.SkinEngine();
            se.SkinAllForm = true;
        }

        private void OutventoryEdit_Load(object sender, EventArgs e)
        {
            var data = new OutInventroyQuery().GetInventoryOutData(ObjectID);
            if (data != null)
            {
                Com_Material_OutPut.Items.Clear();
                var items = new MaterialsQuery().GetMaterials();
                var lists = items.Where(t => t.ObjectID == data.MaterialID);

                Com_Material_OutPut.DataSource = lists.ToList();
                Com_Material_OutPut.DisplayMember = "MaterialName";
                Com_Material_OutPut.ValueMember = "ObjectID";

                Com_Material_OutPut.SelectedIndexChanged += new EventHandler(Com_Material_OutPut_SelectedIndexChanged);
                Com_Material_OutPut.SelectedValue = data.MaterialID;
                Com_Material_OutPut_SelectedIndexChanged(sender, e);


                Num_Number_OutPut.Value = (decimal)data.Number;
                OldNumber = data.Number;
                Time_OutPutTime_Output.Value = DateTime.FromFileTimeUtc((long)data.CreatedTime);
                Txt_Mark_OutPut.Text = data.Mark;


                var users = new UserQuery().GetUsers().Where(t => t.IsEnable.Equals("可用"));
                Com_UsingUser.DataSource = users.ToList();
                Com_UsingUser.DisplayMember = "UserName";
                Com_UsingUser.ValueMember = "ObjectID";
                Com_UsingUser.SelectedValue = data.UserID;


            }
            else
            {
                MessageBox.Show("未能获取到出库记录");

            }
        }

        private void Com_Material_OutPut_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Com_Material_OutPut.SelectedIndex == -1)
                return;

            var materialID = Com_Material_OutPut.SelectedValue.ToString();
            var material = new MaterialsQuery().GetMatrerial(materialID);

            Txt_Unit_OutPut.Text = material.UnitName;

        }

        private void Btn_Reset_OutPut_Click(object sender, EventArgs e)
        {
            this.Close();
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

            try
            {
                var item = new InventoryItems
                {
                    ObjectID = ObjectID,
                    MaterialID = Com_Material_OutPut.SelectedValue.ToString(),
                    UserID = Com_UsingUser.SelectedValue.ToString(),
                    Number = (double)Num_Number_OutPut.Value,
                    CreatedTime = Time_OutPutTime_Output.Value.ToFileTimeUtc(),
                    Mark = Txt_Mark_OutPut.Text

                };

                var isOSuccess = new OutInventroyQuery().DoInventoryUpdate(item);

                if (isOSuccess)
                {
                    var isCSuccess = new CurrentInventoryQuery().DoUpdateCurrentInventory(item.MaterialID, -(item.Number - OldNumber));
                    if (isCSuccess)
                    {
                        MessageBox.Show("修改成功");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("出库记录修改成功，但库存修改失败，请联系管理员进行库存盘点。");
                    }
                }
                else
                {
                    MessageBox.Show("修改失败，请关闭窗口重试。");
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("保存失败，" + exp.Message);
            }
        }
    }
}
