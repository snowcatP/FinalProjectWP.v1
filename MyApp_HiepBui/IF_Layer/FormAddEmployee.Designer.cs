﻿
namespace MyApp_HiepBui.IF_Layer
{
    partial class FormAddEmployee
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
            this.btn_Clear = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.dateTimePicker_AddDOB = new System.Windows.Forms.DateTimePicker();
            this.txt_AddIDStore = new System.Windows.Forms.TextBox();
            this.txt_AddStatusEmp = new System.Windows.Forms.TextBox();
            this.txt_AddPhone = new System.Windows.Forms.TextBox();
            this.txt_AddAddress = new System.Windows.Forms.TextBox();
            this.txt_AddName = new System.Windows.Forms.TextBox();
            this.label_IDStore = new System.Windows.Forms.Label();
            this.label_TypeUser = new System.Windows.Forms.Label();
            this.label_GroupEmp = new System.Windows.Forms.Label();
            this.label_IDKindEmp = new System.Windows.Forms.Label();
            this.label_StatusEmp = new System.Windows.Forms.Label();
            this.label_Phone = new System.Windows.Forms.Label();
            this.label_Diachi = new System.Windows.Forms.Label();
            this.label_Ngaysinh = new System.Windows.Forms.Label();
            this.label_Name = new System.Windows.Forms.Label();
            this.label_DienThongTin = new System.Windows.Forms.Label();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.dgv_KindOfEmployee = new System.Windows.Forms.DataGridView();
            this.dgv_GroupEmp = new System.Windows.Forms.DataGridView();
            this.dgv_TypeUser = new System.Windows.Forms.DataGridView();
            this.txt_AddIDKindEmp = new System.Windows.Forms.TextBox();
            this.txt_AddGroupEmp = new System.Windows.Forms.TextBox();
            this.txt_AddTypeUser = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_KindOfEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_GroupEmp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TypeUser)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Clear
            // 
            this.btn_Clear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(135)))), ((int)(((byte)(190)))));
            this.btn_Clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Clear.ForeColor = System.Drawing.Color.White;
            this.btn_Clear.Location = new System.Drawing.Point(197, 423);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(122, 59);
            this.btn_Clear.TabIndex = 43;
            this.btn_Clear.Text = "Clear";
            this.btn_Clear.UseVisualStyleBackColor = false;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(135)))), ((int)(((byte)(190)))));
            this.btn_Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Save.ForeColor = System.Drawing.Color.White;
            this.btn_Save.Location = new System.Drawing.Point(37, 423);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(122, 59);
            this.btn_Save.TabIndex = 42;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = false;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // dateTimePicker_AddDOB
            // 
            this.dateTimePicker_AddDOB.CustomFormat = "MM-dd-yyyy";
            this.dateTimePicker_AddDOB.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_AddDOB.Location = new System.Drawing.Point(177, 78);
            this.dateTimePicker_AddDOB.Name = "dateTimePicker_AddDOB";
            this.dateTimePicker_AddDOB.Size = new System.Drawing.Size(217, 22);
            this.dateTimePicker_AddDOB.TabIndex = 41;
            // 
            // txt_AddIDStore
            // 
            this.txt_AddIDStore.Location = new System.Drawing.Point(178, 372);
            this.txt_AddIDStore.Name = "txt_AddIDStore";
            this.txt_AddIDStore.Size = new System.Drawing.Size(217, 22);
            this.txt_AddIDStore.TabIndex = 40;
            // 
            // txt_AddStatusEmp
            // 
            this.txt_AddStatusEmp.Location = new System.Drawing.Point(177, 206);
            this.txt_AddStatusEmp.Name = "txt_AddStatusEmp";
            this.txt_AddStatusEmp.Size = new System.Drawing.Size(216, 22);
            this.txt_AddStatusEmp.TabIndex = 36;
            // 
            // txt_AddPhone
            // 
            this.txt_AddPhone.Location = new System.Drawing.Point(178, 164);
            this.txt_AddPhone.Name = "txt_AddPhone";
            this.txt_AddPhone.Size = new System.Drawing.Size(216, 22);
            this.txt_AddPhone.TabIndex = 35;
            // 
            // txt_AddAddress
            // 
            this.txt_AddAddress.Location = new System.Drawing.Point(178, 123);
            this.txt_AddAddress.Name = "txt_AddAddress";
            this.txt_AddAddress.Size = new System.Drawing.Size(216, 22);
            this.txt_AddAddress.TabIndex = 34;
            // 
            // txt_AddName
            // 
            this.txt_AddName.Location = new System.Drawing.Point(177, 39);
            this.txt_AddName.Name = "txt_AddName";
            this.txt_AddName.Size = new System.Drawing.Size(216, 22);
            this.txt_AddName.TabIndex = 33;
            // 
            // label_IDStore
            // 
            this.label_IDStore.AutoSize = true;
            this.label_IDStore.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_IDStore.Location = new System.Drawing.Point(58, 371);
            this.label_IDStore.Name = "label_IDStore";
            this.label_IDStore.Size = new System.Drawing.Size(78, 22);
            this.label_IDStore.TabIndex = 32;
            this.label_IDStore.Text = "IDStore:";
            // 
            // label_TypeUser
            // 
            this.label_TypeUser.AutoSize = true;
            this.label_TypeUser.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_TypeUser.Location = new System.Drawing.Point(56, 328);
            this.label_TypeUser.Name = "label_TypeUser";
            this.label_TypeUser.Size = new System.Drawing.Size(112, 22);
            this.label_TypeUser.TabIndex = 31;
            this.label_TypeUser.Text = "IDTypeUser:";
            // 
            // label_GroupEmp
            // 
            this.label_GroupEmp.AutoSize = true;
            this.label_GroupEmp.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_GroupEmp.Location = new System.Drawing.Point(56, 290);
            this.label_GroupEmp.Name = "label_GroupEmp";
            this.label_GroupEmp.Size = new System.Drawing.Size(122, 22);
            this.label_GroupEmp.TabIndex = 30;
            this.label_GroupEmp.Text = "IDGroupEmp:";
            // 
            // label_IDKindEmp
            // 
            this.label_IDKindEmp.AutoSize = true;
            this.label_IDKindEmp.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_IDKindEmp.Location = new System.Drawing.Point(58, 244);
            this.label_IDKindEmp.Name = "label_IDKindEmp";
            this.label_IDKindEmp.Size = new System.Drawing.Size(111, 22);
            this.label_IDKindEmp.TabIndex = 29;
            this.label_IDKindEmp.Text = "IDKindEmp:";
            // 
            // label_StatusEmp
            // 
            this.label_StatusEmp.AutoSize = true;
            this.label_StatusEmp.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_StatusEmp.Location = new System.Drawing.Point(58, 206);
            this.label_StatusEmp.Name = "label_StatusEmp";
            this.label_StatusEmp.Size = new System.Drawing.Size(63, 22);
            this.label_StatusEmp.TabIndex = 28;
            this.label_StatusEmp.Text = "Status:";
            // 
            // label_Phone
            // 
            this.label_Phone.AutoSize = true;
            this.label_Phone.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Phone.Location = new System.Drawing.Point(58, 164);
            this.label_Phone.Name = "label_Phone";
            this.label_Phone.Size = new System.Drawing.Size(64, 22);
            this.label_Phone.TabIndex = 27;
            this.label_Phone.Text = "Phone:";
            // 
            // label_Diachi
            // 
            this.label_Diachi.AutoSize = true;
            this.label_Diachi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Diachi.Location = new System.Drawing.Point(58, 123);
            this.label_Diachi.Name = "label_Diachi";
            this.label_Diachi.Size = new System.Drawing.Size(82, 22);
            this.label_Diachi.TabIndex = 26;
            this.label_Diachi.Text = "Address:";
            // 
            // label_Ngaysinh
            // 
            this.label_Ngaysinh.AutoSize = true;
            this.label_Ngaysinh.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Ngaysinh.Location = new System.Drawing.Point(56, 78);
            this.label_Ngaysinh.Name = "label_Ngaysinh";
            this.label_Ngaysinh.Size = new System.Drawing.Size(113, 22);
            this.label_Ngaysinh.TabIndex = 25;
            this.label_Ngaysinh.Text = "DateOfBirth:";
            // 
            // label_Name
            // 
            this.label_Name.AutoSize = true;
            this.label_Name.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Name.Location = new System.Drawing.Point(58, 39);
            this.label_Name.Name = "label_Name";
            this.label_Name.Size = new System.Drawing.Size(62, 22);
            this.label_Name.TabIndex = 24;
            this.label_Name.Text = "Name:";
            // 
            // label_DienThongTin
            // 
            this.label_DienThongTin.AutoSize = true;
            this.label_DienThongTin.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_DienThongTin.Location = new System.Drawing.Point(90, 9);
            this.label_DienThongTin.Name = "label_DienThongTin";
            this.label_DienThongTin.Size = new System.Drawing.Size(330, 23);
            this.label_DienThongTin.TabIndex = 23;
            this.label_DienThongTin.Text = "Fill in additional employee information";
            // 
            // btn_Exit
            // 
            this.btn_Exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(135)))), ((int)(((byte)(190)))));
            this.btn_Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Exit.ForeColor = System.Drawing.Color.White;
            this.btn_Exit.Location = new System.Drawing.Point(363, 423);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(122, 59);
            this.btn_Exit.TabIndex = 44;
            this.btn_Exit.Text = "Exit";
            this.btn_Exit.UseVisualStyleBackColor = false;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // dgv_KindOfEmployee
            // 
            this.dgv_KindOfEmployee.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_KindOfEmployee.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv_KindOfEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_KindOfEmployee.Location = new System.Drawing.Point(564, 30);
            this.dgv_KindOfEmployee.Name = "dgv_KindOfEmployee";
            this.dgv_KindOfEmployee.RowHeadersWidth = 51;
            this.dgv_KindOfEmployee.RowTemplate.Height = 24;
            this.dgv_KindOfEmployee.Size = new System.Drawing.Size(628, 115);
            this.dgv_KindOfEmployee.TabIndex = 48;
            // 
            // dgv_GroupEmp
            // 
            this.dgv_GroupEmp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_GroupEmp.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv_GroupEmp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_GroupEmp.Location = new System.Drawing.Point(564, 164);
            this.dgv_GroupEmp.Name = "dgv_GroupEmp";
            this.dgv_GroupEmp.RowHeadersWidth = 51;
            this.dgv_GroupEmp.RowTemplate.Height = 24;
            this.dgv_GroupEmp.Size = new System.Drawing.Size(628, 117);
            this.dgv_GroupEmp.TabIndex = 49;
            // 
            // dgv_TypeUser
            // 
            this.dgv_TypeUser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_TypeUser.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv_TypeUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_TypeUser.Location = new System.Drawing.Point(564, 306);
            this.dgv_TypeUser.Name = "dgv_TypeUser";
            this.dgv_TypeUser.RowHeadersWidth = 51;
            this.dgv_TypeUser.RowTemplate.Height = 24;
            this.dgv_TypeUser.Size = new System.Drawing.Size(628, 126);
            this.dgv_TypeUser.TabIndex = 50;
            // 
            // txt_AddIDKindEmp
            // 
            this.txt_AddIDKindEmp.Location = new System.Drawing.Point(176, 244);
            this.txt_AddIDKindEmp.Name = "txt_AddIDKindEmp";
            this.txt_AddIDKindEmp.Size = new System.Drawing.Size(217, 22);
            this.txt_AddIDKindEmp.TabIndex = 51;
            // 
            // txt_AddGroupEmp
            // 
            this.txt_AddGroupEmp.Location = new System.Drawing.Point(176, 290);
            this.txt_AddGroupEmp.Name = "txt_AddGroupEmp";
            this.txt_AddGroupEmp.Size = new System.Drawing.Size(217, 22);
            this.txt_AddGroupEmp.TabIndex = 52;
            // 
            // txt_AddTypeUser
            // 
            this.txt_AddTypeUser.Location = new System.Drawing.Point(175, 327);
            this.txt_AddTypeUser.Name = "txt_AddTypeUser";
            this.txt_AddTypeUser.Size = new System.Drawing.Size(218, 22);
            this.txt_AddTypeUser.TabIndex = 53;
            // 
            // FormAddEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(231)))), ((int)(((byte)(243)))));
            this.ClientSize = new System.Drawing.Size(1266, 536);
            this.Controls.Add(this.txt_AddTypeUser);
            this.Controls.Add(this.txt_AddGroupEmp);
            this.Controls.Add(this.txt_AddIDKindEmp);
            this.Controls.Add(this.dgv_TypeUser);
            this.Controls.Add(this.dgv_GroupEmp);
            this.Controls.Add(this.dgv_KindOfEmployee);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.dateTimePicker_AddDOB);
            this.Controls.Add(this.txt_AddIDStore);
            this.Controls.Add(this.txt_AddStatusEmp);
            this.Controls.Add(this.txt_AddPhone);
            this.Controls.Add(this.txt_AddAddress);
            this.Controls.Add(this.txt_AddName);
            this.Controls.Add(this.label_IDStore);
            this.Controls.Add(this.label_TypeUser);
            this.Controls.Add(this.label_GroupEmp);
            this.Controls.Add(this.label_IDKindEmp);
            this.Controls.Add(this.label_StatusEmp);
            this.Controls.Add(this.label_Phone);
            this.Controls.Add(this.label_Diachi);
            this.Controls.Add(this.label_Ngaysinh);
            this.Controls.Add(this.label_Name);
            this.Controls.Add(this.label_DienThongTin);
            this.Name = "FormAddEmployee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormAddEmployee";
            this.Load += new System.EventHandler(this.FormAddEmployee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_KindOfEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_GroupEmp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TypeUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.DateTimePicker dateTimePicker_AddDOB;
        private System.Windows.Forms.TextBox txt_AddIDStore;
        private System.Windows.Forms.TextBox txt_AddStatusEmp;
        private System.Windows.Forms.TextBox txt_AddPhone;
        private System.Windows.Forms.TextBox txt_AddAddress;
        private System.Windows.Forms.TextBox txt_AddName;
        private System.Windows.Forms.Label label_IDStore;
        private System.Windows.Forms.Label label_TypeUser;
        private System.Windows.Forms.Label label_GroupEmp;
        private System.Windows.Forms.Label label_IDKindEmp;
        private System.Windows.Forms.Label label_StatusEmp;
        private System.Windows.Forms.Label label_Phone;
        private System.Windows.Forms.Label label_Diachi;
        private System.Windows.Forms.Label label_Ngaysinh;
        private System.Windows.Forms.Label label_Name;
        private System.Windows.Forms.Label label_DienThongTin;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.DataGridView dgv_KindOfEmployee;
        private System.Windows.Forms.DataGridView dgv_GroupEmp;
        private System.Windows.Forms.DataGridView dgv_TypeUser;
        private System.Windows.Forms.TextBox txt_AddIDKindEmp;
        private System.Windows.Forms.TextBox txt_AddGroupEmp;
        private System.Windows.Forms.TextBox txt_AddTypeUser;
    }
}