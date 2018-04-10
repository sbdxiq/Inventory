using InventoryManagement.Query.Origination;
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
    public partial class Department : Form
    {
        public Department()
        {
            InitializeComponent();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
            this.skinEngine1.SkinFile = Application.StartupPath + "//DiamondBlue.ssk";

            Sunisoft.IrisSkin.SkinEngine se = null;
            se = new Sunisoft.IrisSkin.SkinEngine();
            se.SkinAllForm = true;
        }
        public bool IsEdit { get; set; }
        public string DepartmentID { get; set; }


        private void Department_Load(object sender, EventArgs e)
        {

            if (!IsEdit)
            {
                var departmentId = Guid.NewGuid().ToString();

                while (new DepartmentQuery().GetDepartment(departmentId) != null)
                {
                    departmentId = Guid.NewGuid().ToString();
                }

                Txt_DepartmentID.Text = departmentId;
            }
            else
            {
                var items = new DepartmentQuery().GetDepartment(DepartmentID);
                if (items != null)
                {
                    Txt_DepartmentID.Text = items.ObjectID;
                    Txt_DepartmentName.Text = items.DepartmentName;
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
            if (String.IsNullOrEmpty(Txt_DepartmentName.Text))
            {
                MessageBox.Show("请输入部门名称");
                return;
            }
            try
            {
                var item = new DepartmentItems()
                {
                    ObjectID = Txt_DepartmentID.Text,
                    DepartmentName = Txt_DepartmentName.Text,
                    IsEnable = Rbtn_Yes.Checked ? "Y" : "N"
                };

                var result = IsEdit ? new DepartmentQuery().UpdateDepartment(item) : new DepartmentQuery().InsertDepartment(item);

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

                        while (new DepartmentQuery().GetDepartment(unitId) != null)
                        {
                            unitId = Guid.NewGuid().ToString();
                        }

                        Txt_DepartmentID.Text = unitId;
                        Txt_DepartmentName.Text = String.Empty;
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
