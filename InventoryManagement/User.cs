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
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
            this.skinEngine1.SkinFile = Application.StartupPath + "//DiamondBlue.ssk";

            Sunisoft.IrisSkin.SkinEngine se = null;
            se = new Sunisoft.IrisSkin.SkinEngine();
            se.SkinAllForm = true;
        }
        public bool IsEdit { get; set; }
        public string UserID { get; set; }
        private void User_Load(object sender, EventArgs e)
        {

            var unitItem = new DepartmentQuery().GetDepartments();
            //Com_DepartmentID.Items.Clear();
            Com_DepartmentID.DataSource = unitItem;
            Com_DepartmentID.ValueMember = "ObjectID";
            Com_DepartmentID.DisplayMember = "DepartmentName";

            if (!IsEdit)
            {
                var userId = Guid.NewGuid().ToString();

                while (new DepartmentQuery().GetDepartment(userId) != null)
                {
                    userId = Guid.NewGuid().ToString();
                }

                Txt_UserID.Text = userId;
            }
            else
            {
                var items = new UserQuery().GetUser(UserID);
                if (items != null)
                {
                    Txt_UserID.Text = items.ObjectID;
                    Txt_UserName.Text = items.UserName;
                    Com_DepartmentID.SelectedValue = items.UserDepartmentID;

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
            if (String.IsNullOrEmpty(Txt_UserName.Text))
            {
                MessageBox.Show("请输入员工姓名");
                return;
            }
            else if (Com_DepartmentID.SelectedIndex < 0)
            {
                MessageBox.Show("请选择所属部门");
                return;
            }


            try
            {
                var item = new UserItems()
                {
                    ObjectID = Txt_UserID.Text,
                    UserName = Txt_UserName.Text,
                    UserDepartmentID = Com_DepartmentID.SelectedValue.ToString(),
                    IsEnable = Rbtn_Yes.Checked ? "Y" : "N"
                };

                var result = IsEdit ? new UserQuery().UpdateUser(item) : new UserQuery().InsertUser(item);

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

                        while (new UserQuery().GetUser(unitId) != null)
                        {
                            unitId = Guid.NewGuid().ToString();
                        }

                        Txt_UserID.Text = unitId;

                        Txt_UserName.Text = String.Empty;
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
