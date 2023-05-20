﻿using ConvenienceStoreManagement.BS_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConvenienceStoreManagement.IF_Layer
{
    public partial class FormAddEmployee : Form
    {
        string err = "";
        DataTable dtKindOfEmp = null;
        DataTable dtGroupEmp = null;
        DataTable dtTypeUser = null;
        BLNhanVien dbNV = new BLNhanVien();
        public FormAddEmployee()
        {
            InitializeComponent();
            dateTimePicker_AddDOB.Format = DateTimePickerFormat.Custom;
            dateTimePicker_AddDOB.CustomFormat = "dd-MM-yyyy";
        }
        void LoadDataInformation()
        {
            try
            {

                dgv_KindOfEmployee.DataSource = dbNV.Get_List_Kind_Of_Employee();
                dgv_KindOfEmployee.AutoResizeColumns();
                //

                dgv_GroupEmp.DataSource = dbNV.Get_List_Group_Of_Employee();
                dgv_GroupEmp.AutoResizeColumns();
                //
                dgv_TypeUser.DataSource = dbNV.Get_List_Type_Of_User();
                dgv_TypeUser.AutoResizeColumns();

            }
            catch (SqlException)
            {

                throw;
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                // Thực hiện lệnh
                BLNhanVien blNhanVien = new BLNhanVien();
                int value_StatusEmp = Convert.ToInt32(txt_AddStatusEmp.Text);
                dateTimePicker_AddDOB.CustomFormat = "yyyy-MM-dd";
                blNhanVien.Add_Employee(txt_AddName.Text, dateTimePicker_AddDOB.Text, txt_AddAddress.Text, txt_AddPhone.Text,
                    value_StatusEmp, txt_AddIDKindEmp.Text, txt_AddGroupEmp.Text,
                    txt_AddTypeUser.Text, txt_AddIDStore.Text, ref err);
                if (err != "")
                {
                    MessageBox.Show(err);
                    return;
                }
                // Thông báo
                MessageBox.Show("Đã thêm xong!");
            }
            catch (SqlException)
            {
                MessageBox.Show("Không thêm được. Lỗi rồi!");
            }
        }

        private void FormAddEmployee_Load(object sender, EventArgs e)
        {
            LoadDataInformation();
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            txt_AddName.Clear();
            dateTimePicker_AddDOB.ResetText();
            txt_AddAddress.Clear();
            txt_AddPhone.Clear();
            txt_AddStatusEmp.Clear();
            txt_AddIDKindEmp.Clear();
            txt_AddGroupEmp.Clear();
            txt_AddTypeUser.Clear();
            txt_AddIDStore.Clear();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
