namespace InventoryManagement
{
    partial class OutInventoryEdit
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
            this.Com_UsingUser = new System.Windows.Forms.ComboBox();
            this.Num_Number_OutPut = new System.Windows.Forms.NumericUpDown();
            this.Txt_Unit_OutPut = new System.Windows.Forms.TextBox();
            this.Btn_Reset_OutPut = new System.Windows.Forms.Button();
            this.Btn_Save_OutPut = new System.Windows.Forms.Button();
            this.Txt_Mark_OutPut = new System.Windows.Forms.TextBox();
            this.Time_OutPutTime_Output = new System.Windows.Forms.DateTimePicker();
            this.Com_Material_OutPut = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine();
            ((System.ComponentModel.ISupportInitialize)(this.Num_Number_OutPut)).BeginInit();
            this.SuspendLayout();
            // 
            // Com_UsingUser
            // 
            this.Com_UsingUser.FormattingEnabled = true;
            this.Com_UsingUser.Location = new System.Drawing.Point(123, 108);
            this.Com_UsingUser.Name = "Com_UsingUser";
            this.Com_UsingUser.Size = new System.Drawing.Size(201, 20);
            this.Com_UsingUser.TabIndex = 38;
            // 
            // Num_Number_OutPut
            // 
            this.Num_Number_OutPut.Location = new System.Drawing.Point(494, 108);
            this.Num_Number_OutPut.Name = "Num_Number_OutPut";
            this.Num_Number_OutPut.Size = new System.Drawing.Size(163, 21);
            this.Num_Number_OutPut.TabIndex = 37;
            // 
            // Txt_Unit_OutPut
            // 
            this.Txt_Unit_OutPut.Location = new System.Drawing.Point(494, 46);
            this.Txt_Unit_OutPut.Name = "Txt_Unit_OutPut";
            this.Txt_Unit_OutPut.ReadOnly = true;
            this.Txt_Unit_OutPut.Size = new System.Drawing.Size(163, 21);
            this.Txt_Unit_OutPut.TabIndex = 36;
            // 
            // Btn_Reset_OutPut
            // 
            this.Btn_Reset_OutPut.Location = new System.Drawing.Point(394, 351);
            this.Btn_Reset_OutPut.Name = "Btn_Reset_OutPut";
            this.Btn_Reset_OutPut.Size = new System.Drawing.Size(75, 23);
            this.Btn_Reset_OutPut.TabIndex = 35;
            this.Btn_Reset_OutPut.Text = "关闭";
            this.Btn_Reset_OutPut.UseVisualStyleBackColor = true;
            this.Btn_Reset_OutPut.Click += new System.EventHandler(this.Btn_Reset_OutPut_Click);
            // 
            // Btn_Save_OutPut
            // 
            this.Btn_Save_OutPut.Location = new System.Drawing.Point(197, 351);
            this.Btn_Save_OutPut.Name = "Btn_Save_OutPut";
            this.Btn_Save_OutPut.Size = new System.Drawing.Size(75, 23);
            this.Btn_Save_OutPut.TabIndex = 34;
            this.Btn_Save_OutPut.Text = "保存";
            this.Btn_Save_OutPut.UseVisualStyleBackColor = true;
            this.Btn_Save_OutPut.Click += new System.EventHandler(this.Btn_Save_OutPut_Click);
            // 
            // Txt_Mark_OutPut
            // 
            this.Txt_Mark_OutPut.Location = new System.Drawing.Point(123, 241);
            this.Txt_Mark_OutPut.Multiline = true;
            this.Txt_Mark_OutPut.Name = "Txt_Mark_OutPut";
            this.Txt_Mark_OutPut.Size = new System.Drawing.Size(534, 82);
            this.Txt_Mark_OutPut.TabIndex = 33;
            // 
            // Time_OutPutTime_Output
            // 
            this.Time_OutPutTime_Output.Location = new System.Drawing.Point(123, 168);
            this.Time_OutPutTime_Output.Name = "Time_OutPutTime_Output";
            this.Time_OutPutTime_Output.Size = new System.Drawing.Size(201, 21);
            this.Time_OutPutTime_Output.TabIndex = 32;
            // 
            // Com_Material_OutPut
            // 
            this.Com_Material_OutPut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Com_Material_OutPut.FormattingEnabled = true;
            this.Com_Material_OutPut.Location = new System.Drawing.Point(123, 46);
            this.Com_Material_OutPut.Name = "Com_Material_OutPut";
            this.Com_Material_OutPut.Size = new System.Drawing.Size(201, 20);
            this.Com_Material_OutPut.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(52, 251);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 27;
            this.label7.Text = "备注";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(426, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 26;
            this.label8.Text = "出库数量";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(52, 110);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 25;
            this.label9.Text = "领用人";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(52, 174);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 30;
            this.label10.Text = "入库时间";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(426, 49);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 29;
            this.label11.Text = "计量单位";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(52, 49);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 28;
            this.label12.Text = "物品名称";
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
            // OutInventoryEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 420);
            this.Controls.Add(this.Com_UsingUser);
            this.Controls.Add(this.Num_Number_OutPut);
            this.Controls.Add(this.Txt_Unit_OutPut);
            this.Controls.Add(this.Btn_Reset_OutPut);
            this.Controls.Add(this.Btn_Save_OutPut);
            this.Controls.Add(this.Txt_Mark_OutPut);
            this.Controls.Add(this.Time_OutPutTime_Output);
            this.Controls.Add(this.Com_Material_OutPut);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Name = "OutInventoryEdit";
            this.Text = "出库记录修改";
            this.Load += new System.EventHandler(this.OutventoryEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Num_Number_OutPut)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox Com_UsingUser;
        private System.Windows.Forms.NumericUpDown Num_Number_OutPut;
        private System.Windows.Forms.TextBox Txt_Unit_OutPut;
        private System.Windows.Forms.Button Btn_Reset_OutPut;
        private System.Windows.Forms.Button Btn_Save_OutPut;
        private System.Windows.Forms.TextBox Txt_Mark_OutPut;
        private System.Windows.Forms.DateTimePicker Time_OutPutTime_Output;
        private System.Windows.Forms.ComboBox Com_Material_OutPut;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
    }
}