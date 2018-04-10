namespace InventoryManagement
{
    partial class InInventoryEdit
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
            this.Num_Price_InPut = new System.Windows.Forms.NumericUpDown();
            this.Num_Number_Input = new System.Windows.Forms.NumericUpDown();
            this.Txt_Unit_Input = new System.Windows.Forms.TextBox();
            this.Btn_Reset_Input = new System.Windows.Forms.Button();
            this.Btn_Save_Input = new System.Windows.Forms.Button();
            this.Txt_Mark_Input = new System.Windows.Forms.TextBox();
            this.Time_InPutTime_Input = new System.Windows.Forms.DateTimePicker();
            this.Com_Material_Input = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine();
            ((System.ComponentModel.ISupportInitialize)(this.Num_Price_InPut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_Number_Input)).BeginInit();
            this.SuspendLayout();
            // 
            // Num_Price_InPut
            // 
            this.Num_Price_InPut.DecimalPlaces = 2;
            this.Num_Price_InPut.Location = new System.Drawing.Point(132, 114);
            this.Num_Price_InPut.Name = "Num_Price_InPut";
            this.Num_Price_InPut.Size = new System.Drawing.Size(201, 21);
            this.Num_Price_InPut.TabIndex = 24;
            // 
            // Num_Number_Input
            // 
            this.Num_Number_Input.Location = new System.Drawing.Point(503, 114);
            this.Num_Number_Input.Name = "Num_Number_Input";
            this.Num_Number_Input.Size = new System.Drawing.Size(163, 21);
            this.Num_Number_Input.TabIndex = 23;
            // 
            // Txt_Unit_Input
            // 
            this.Txt_Unit_Input.Location = new System.Drawing.Point(503, 52);
            this.Txt_Unit_Input.Name = "Txt_Unit_Input";
            this.Txt_Unit_Input.ReadOnly = true;
            this.Txt_Unit_Input.Size = new System.Drawing.Size(163, 21);
            this.Txt_Unit_Input.TabIndex = 22;
            // 
            // Btn_Reset_Input
            // 
            this.Btn_Reset_Input.Location = new System.Drawing.Point(403, 357);
            this.Btn_Reset_Input.Name = "Btn_Reset_Input";
            this.Btn_Reset_Input.Size = new System.Drawing.Size(75, 23);
            this.Btn_Reset_Input.TabIndex = 21;
            this.Btn_Reset_Input.Text = "关闭";
            this.Btn_Reset_Input.UseVisualStyleBackColor = true;
            this.Btn_Reset_Input.Click += new System.EventHandler(this.Btn_Reset_Input_Click);
            // 
            // Btn_Save_Input
            // 
            this.Btn_Save_Input.Location = new System.Drawing.Point(206, 357);
            this.Btn_Save_Input.Name = "Btn_Save_Input";
            this.Btn_Save_Input.Size = new System.Drawing.Size(75, 23);
            this.Btn_Save_Input.TabIndex = 20;
            this.Btn_Save_Input.Text = "保存";
            this.Btn_Save_Input.UseVisualStyleBackColor = true;
            this.Btn_Save_Input.Click += new System.EventHandler(this.Btn_Save_Input_Click);
            // 
            // Txt_Mark_Input
            // 
            this.Txt_Mark_Input.Location = new System.Drawing.Point(132, 247);
            this.Txt_Mark_Input.Multiline = true;
            this.Txt_Mark_Input.Name = "Txt_Mark_Input";
            this.Txt_Mark_Input.Size = new System.Drawing.Size(534, 82);
            this.Txt_Mark_Input.TabIndex = 19;
            // 
            // Time_InPutTime_Input
            // 
            this.Time_InPutTime_Input.Location = new System.Drawing.Point(132, 174);
            this.Time_InPutTime_Input.Name = "Time_InPutTime_Input";
            this.Time_InPutTime_Input.Size = new System.Drawing.Size(201, 21);
            this.Time_InPutTime_Input.TabIndex = 18;
            // 
            // Com_Material_Input
            // 
            this.Com_Material_Input.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Com_Material_Input.FormattingEnabled = true;
            this.Com_Material_Input.Location = new System.Drawing.Point(132, 52);
            this.Com_Material_Input.Name = "Com_Material_Input";
            this.Com_Material_Input.Size = new System.Drawing.Size(201, 20);
            this.Com_Material_Input.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 257);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "备注";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(435, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "入库数量";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(61, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "单价";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "入库时间";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(435, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "计量单位";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 16;
            this.label1.Text = "物品名称";
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
            // InInventoryEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 447);
            this.Controls.Add(this.Num_Price_InPut);
            this.Controls.Add(this.Num_Number_Input);
            this.Controls.Add(this.Txt_Unit_Input);
            this.Controls.Add(this.Btn_Reset_Input);
            this.Controls.Add(this.Btn_Save_Input);
            this.Controls.Add(this.Txt_Mark_Input);
            this.Controls.Add(this.Time_InPutTime_Input);
            this.Controls.Add(this.Com_Material_Input);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "InInventoryEdit";
            this.Text = "入库记录修改";
            this.Load += new System.EventHandler(this.InventoryEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Num_Price_InPut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_Number_Input)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown Num_Price_InPut;
        private System.Windows.Forms.NumericUpDown Num_Number_Input;
        private System.Windows.Forms.TextBox Txt_Unit_Input;
        private System.Windows.Forms.Button Btn_Reset_Input;
        private System.Windows.Forms.Button Btn_Save_Input;
        private System.Windows.Forms.TextBox Txt_Mark_Input;
        private System.Windows.Forms.DateTimePicker Time_InPutTime_Input;
        private System.Windows.Forms.ComboBox Com_Material_Input;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
    }
}