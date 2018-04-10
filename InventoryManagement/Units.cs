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
    public partial class Units : Form
    {
        public bool IsEdit { get; set; }
        public string ObjectID { get; set; }

        public Units()
        {
            InitializeComponent();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
            this.skinEngine1.SkinFile = Application.StartupPath + "//DiamondBlue.ssk";

            Sunisoft.IrisSkin.SkinEngine se = null;
            se = new Sunisoft.IrisSkin.SkinEngine();
            se.SkinAllForm = true;
        }

        private void Units_Load(object sender, EventArgs e)
        {
            if (!IsEdit)
            {
                var unitId = Guid.NewGuid().ToString();

                while (new UnitsQuery().GetUnit(unitId) != null)
                {
                    unitId = Guid.NewGuid().ToString();
                }

                Txt_UnitID.Text = unitId;
            }
            else
            {
                UnitsItems items = new UnitsQuery().GetUnit(ObjectID);
                if (items != null)
                {
                    Txt_UnitID.Text = items.ObjectID;
                    Txt_UnitName.Text = items.UnitsName;
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
            if (String.IsNullOrEmpty(Txt_UnitName.Text))
            {
                MessageBox.Show("请输入计量单位名称");
                return;
            }
            try
            {
                var item = new UnitsItems()
                {
                    ObjectID = Txt_UnitID.Text,
                    UnitsName = Txt_UnitName.Text,
                    IsEnable = Rbtn_Yes.Checked ? "Y" : "N"
                };

                var result = IsEdit ? new UnitsQuery().UpdateUnits(item) : new UnitsQuery().InsertUnits(item);

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

                        while (new UnitsQuery().GetUnit(unitId) != null)
                        {
                            unitId = Guid.NewGuid().ToString();
                        }

                        Txt_UnitID.Text = unitId;
                        Txt_UnitName.Text = String.Empty;
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
