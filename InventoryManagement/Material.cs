using InventoryManagement.Query.BaseSet;
using InventoryManagement.QueryModel.BaseSet;
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
    public partial class Material : Form
    {
        public Material()
        {
            InitializeComponent();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
            this.skinEngine1.SkinFile = Application.StartupPath + "//DiamondBlue.ssk";

            Sunisoft.IrisSkin.SkinEngine se = null;
            se = new Sunisoft.IrisSkin.SkinEngine();
            se.SkinAllForm = true;
        }

        public bool IsEdit { get; set; }
        public string MaterialID { get; set; }
        private void Material_Load(object sender, EventArgs e)
        {
            Com_MaterialUnit.Items.Clear();
            var unitItem = new UnitsQuery().GetUnitsList();


            Com_MaterialUnit.ValueMember = "ObjectID";
            Com_MaterialUnit.DisplayMember = "UnitsName";
            Com_MaterialUnit.DataSource = unitItem;

            if (!IsEdit)
            {
                var materialId = Guid.NewGuid().ToString();

                while (unitItem.Any(t => materialId == t.ObjectID))
                {
                    materialId = Guid.NewGuid().ToString();
                }

                Txt_MaterialID.Text = materialId;
            }
            else
            {
                MaterialItems items = new MaterialsQuery().GetMatrerial(MaterialID);
                if (items != null)
                {
                    Txt_MaterialID.Text = items.ObjectID;
                    Txt_MaterialName.Text = items.MaterialName;
                    Com_MaterialUnit.SelectedValue = items.UnitID;

                    if (items.IsEnable == "Y")
                    {
                        Rbtn_Yes.Checked = true;
                    }
                    else
                    {
                        Rbtn_No.Checked = true;
                    }

                }
            }
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(Txt_MaterialName.Text))
            {
                MessageBox.Show("请输入物品名称");
                return;
            }
            else if (Com_MaterialUnit.SelectedIndex < 0)
            {
                MessageBox.Show("请选择计量单位");
                return;
            }


            try
            {
                var item = new MaterialItems()
                {
                    ObjectID = Txt_MaterialID.Text,
                    MaterialName = Txt_MaterialName.Text,
                    UnitID = Com_MaterialUnit.SelectedValue.ToString(),
                    IsEnable = Rbtn_Yes.Checked ? "Y" : "N"
                };

                var result = IsEdit ? new MaterialsQuery().UpdateMaterial(item) : new MaterialsQuery().InsertMaterials(item);

                if (result)
                {
                    MessageBox.Show("保存成功");

                    if (IsEdit)
                    {
                        this.Close();
                    }
                    else
                    {
                        var unitId = Guid.NewGuid().ToString();

                        while (new MaterialsQuery().GetMatrerial(unitId) != null)
                        {
                            unitId = Guid.NewGuid().ToString();
                        }

                        Txt_MaterialID.Text = unitId;

                        Txt_MaterialName.Text = String.Empty;
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("保存失败," + exp.Message);
            }
        }
    }
}
