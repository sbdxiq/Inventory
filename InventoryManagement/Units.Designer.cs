﻿namespace InventoryManagement
{
    partial class Units
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
            this.Txt_UnitID = new System.Windows.Forms.TextBox();
            this.Btn_Save = new System.Windows.Forms.Button();
            this.Rbtn_No = new System.Windows.Forms.RadioButton();
            this.Rbtn_Yes = new System.Windows.Forms.RadioButton();
            this.Txt_UnitName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine();
            this.SuspendLayout();
            // 
            // Txt_UnitID
            // 
            this.Txt_UnitID.Location = new System.Drawing.Point(113, 49);
            this.Txt_UnitID.Name = "Txt_UnitID";
            this.Txt_UnitID.ReadOnly = true;
            this.Txt_UnitID.Size = new System.Drawing.Size(260, 21);
            this.Txt_UnitID.TabIndex = 16;
            // 
            // Btn_Save
            // 
            this.Btn_Save.Location = new System.Drawing.Point(113, 205);
            this.Btn_Save.Name = "Btn_Save";
            this.Btn_Save.Size = new System.Drawing.Size(260, 23);
            this.Btn_Save.TabIndex = 14;
            this.Btn_Save.Text = "保存";
            this.Btn_Save.UseVisualStyleBackColor = true;
            this.Btn_Save.Click += new System.EventHandler(this.Btn_Save_Click);
            // 
            // Rbtn_No
            // 
            this.Rbtn_No.AutoSize = true;
            this.Rbtn_No.Location = new System.Drawing.Point(154, 142);
            this.Rbtn_No.Name = "Rbtn_No";
            this.Rbtn_No.Size = new System.Drawing.Size(35, 16);
            this.Rbtn_No.TabIndex = 13;
            this.Rbtn_No.TabStop = true;
            this.Rbtn_No.Text = "否";
            this.Rbtn_No.UseVisualStyleBackColor = true;
            // 
            // Rbtn_Yes
            // 
            this.Rbtn_Yes.AutoSize = true;
            this.Rbtn_Yes.Checked = true;
            this.Rbtn_Yes.Location = new System.Drawing.Point(113, 142);
            this.Rbtn_Yes.Name = "Rbtn_Yes";
            this.Rbtn_Yes.Size = new System.Drawing.Size(35, 16);
            this.Rbtn_Yes.TabIndex = 12;
            this.Rbtn_Yes.TabStop = true;
            this.Rbtn_Yes.Text = "是";
            this.Rbtn_Yes.UseVisualStyleBackColor = true;
            // 
            // Txt_UnitName
            // 
            this.Txt_UnitName.Location = new System.Drawing.Point(113, 90);
            this.Txt_UnitName.Name = "Txt_UnitName";
            this.Txt_UnitName.Size = new System.Drawing.Size(260, 21);
            this.Txt_UnitName.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "是否启用";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "计量单位ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "计量单位名称";
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
            // Units
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 299);
            this.Controls.Add(this.Txt_UnitID);
            this.Controls.Add(this.Btn_Save);
            this.Controls.Add(this.Rbtn_No);
            this.Controls.Add(this.Rbtn_Yes);
            this.Controls.Add(this.Txt_UnitName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Name = "Units";
            this.Text = "计量单位";
            this.Load += new System.EventHandler(this.Units_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Txt_UnitID;
        private System.Windows.Forms.Button Btn_Save;
        private System.Windows.Forms.RadioButton Rbtn_No;
        private System.Windows.Forms.RadioButton Rbtn_Yes;
        private System.Windows.Forms.TextBox Txt_UnitName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
    }
}