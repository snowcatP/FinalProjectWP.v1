﻿using MyApp_HiepBui.BS_Layer;
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

namespace MyApp_HiepBui.IF_Layer
{
    public partial class FormModifyEmp : Form
    {
        string err = "";
        DataTable dtKindOfEmp = null;
        DataTable dtGroupEmp = null;
        DataTable dtTypeUser = null;
        DataTable dtFullEmp = null;

        BLNhanVien dbNV = new BLNhanVien();
        public FormModifyEmp()
        {
            InitializeComponent();
            dateTimePicker_DOB.Format = DateTimePickerFormat.Custom;
            dateTimePicker_DOB.CustomFormat = "dd-MM-yyyy";
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
                //
                dgv_FullEmp.DataSource = dbNV.Get_Full_List_Employee();
                dgv_FullEmp.AutoResizeColumns();

            }
            catch (SqlException)
            {

                throw;
            }
        }

        private void FormModifyEmp_Load(object sender, EventArgs e)
        {
            LoadDataInformation();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                // Thực hiện lệnh
                BLNhanVien blNhanVien = new BLNhanVien();
                int value_StatusEmp = Convert.ToInt32(txt_StatusEmp.Text);
                dateTimePicker_DOB.CustomFormat = "yyyy-MM-dd";
                blNhanVien.Update_Employee(txt_ID.Text, txt_Name.Text, dateTimePicker_DOB.Text, txt_Address.Text, txt_Phone.Text,
                    value_StatusEmp, txt_IDKindEmp.Text, txt_GroupEmp.Text,
                    txt_TypeUser.Text, txt_IDStore.Text, ref err);
                if (err != "")
                {
                    MessageBox.Show(err);
                    return;
                }
                else
                {
                    // Thông báo
                    MessageBox.Show("Đã sửa xong!");

                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không sửa được. Lỗi rồi!");
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dgv_FullEmp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dateTimePicker_DOB.Format = DateTimePickerFormat.Custom;
            dateTimePicker_DOB.CustomFormat = "dd-MM-yyyy";
            int r = dgv_FullEmp.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel
            txt_ID.Text = dgv_FullEmp.Rows[r].Cells[0].Value.ToString();
            txt_Name.Text = dgv_FullEmp.Rows[r].Cells[1].Value.ToString();
            dateTimePicker_DOB.Text = dgv_FullEmp.Rows[r].Cells[2].Value.ToString();
            txt_Address.Text = dgv_FullEmp.Rows[r].Cells[3].Value.ToString();
            txt_Phone.Text = dgv_FullEmp.Rows[r].Cells[4].Value.ToString();
            txt_StatusEmp.Text = dgv_FullEmp.Rows[r].Cells[5].Value.ToString();
            txt_IDKindEmp.Text = dgv_FullEmp.Rows[r].Cells[6].Value.ToString();
            txt_GroupEmp.Text = dgv_FullEmp.Rows[r].Cells[7].Value.ToString();
            txt_TypeUser.Text = dgv_FullEmp.Rows[r].Cells[8].Value.ToString();
            txt_IDStore.Text = dgv_FullEmp.Rows[r].Cells[9].Value.ToString();
        }
    }
}
