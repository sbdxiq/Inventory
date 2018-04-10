namespace InventoryManagement
{
    partial class Material
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.Txt_MaterialName = new System.Windows.Forms.TextBox();
            this.Rbtn_Yes = new System.Windows.Forms.RadioButton();
            this.Rbtn_No = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.Btn_Save = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Com_MaterialUnit = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Txt_MaterialID = new System.Windows.Forms.TextBox();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "物品名称";
            // 
            // Txt_MaterialName
            // 
            this.Txt_MaterialName.Location = new System.Drawing.Point(92, 67);
            this.Txt_MaterialName.Name = "Txt_MaterialName";
            this.Txt_MaterialName.Size = new System.Drawing.Size(260, 21);
            this.Txt_MaterialName.TabIndex = 1;
            // 
            // Rbtn_Yes
            // 
            this.Rbtn_Yes.AutoSize = true;
            this.Rbtn_Yes.Checked = true;
            this.Rbtn_Yes.Location = new System.Drawing.Point(92, 175);
            this.Rbtn_Yes.Name = "Rbtn_Yes";
            this.Rbtn_Yes.Size = new System.Drawing.Size(35, 16);
            this.Rbtn_Yes.TabIndex = 2;
            this.Rbtn_Yes.TabStop = true;
            this.Rbtn_Yes.Text = "是";
            this.Rbtn_Yes.UseVisualStyleBackColor = true;
            // 
            // Rbtn_No
            // 
            this.Rbtn_No.AutoSize = true;
            this.Rbtn_No.Location = new System.Drawing.Point(133, 175);
            this.Rbtn_No.Name = "Rbtn_No";
            this.Rbtn_No.Size = new System.Drawing.Size(35, 16);
            this.Rbtn_No.TabIndex = 3;
            this.Rbtn_No.TabStop = true;
            this.Rbtn_No.Text = "否";
            this.Rbtn_No.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "是否启用";
            // 
            // Btn_Save
            // 
            this.Btn_Save.Location = new System.Drawing.Point(92, 238);
            this.Btn_Save.Name = "Btn_Save";
            this.Btn_Save.Size = new System.Drawing.Size(260, 23);
            this.Btn_Save.TabIndex = 4;
            this.Btn_Save.Text = "保存";
            this.Btn_Save.UseVisualStyleBackColor = true;
            this.Btn_Save.Click += new System.EventHandler(this.Btn_Save_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "计量单位";
            // 
            // Com_MaterialUnit
            // 
            this.Com_MaterialUnit.FormattingEnabled = true;
            this.Com_MaterialUnit.Location = new System.Drawing.Point(92, 117);
            this.Com_MaterialUnit.Name = "Com_MaterialUnit";
            this.Com_MaterialUnit.Size = new System.Drawing.Size(94, 20);
            this.Com_MaterialUnit.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "物品ID";
            // 
            // Txt_MaterialID
            // 
            this.Txt_MaterialID.Location = new System.Drawing.Point(92, 26);
            this.Txt_MaterialID.Name = "Txt_MaterialID";
            this.Txt_MaterialID.ReadOnly = true;
            this.Txt_MaterialID.Size = new System.Drawing.Size(260, 21);
            this.Txt_MaterialID.TabIndex = 6;
            // 
            // skinEngine1
            // 
            this.skinEngine1.@__DrawButtonFocusRectangle = true;
            this.skinEngine1.DisabledButtonTextColor = System.Drawing.Color.Gray;
            this.skinEngine1.DisabledMenuFontColor = System.Drawing.SystemColors.GrayText;
            this.skinEngine1.InactiveCaptionColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.skinEngine1.SerialNumber = "";
            this.skinEngine1.SkinFile = null;
            // 
            // Material
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 299);
            this.Controls.Add(this.Txt_MaterialID);
            this.Controls.Add(this.Com_MaterialUnit);
            this.Controls.Add(this.Btn_Save);
            this.Controls.Add(this.Rbtn_No);
            this.Controls.Add(this.Rbtn_Yes);
            this.Controls.Add(this.Txt_MaterialName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Name = "Material";
            this.Text = "物品名称";
            this.Load += new System.EventHandler(this.Material_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Txt_MaterialName;
        private System.Windows.Forms.RadioButton Rbtn_Yes;
        private System.Windows.Forms.RadioButton Rbtn_No;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Btn_Save;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox Com_MaterialUnit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Txt_MaterialID;
        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
    }
}