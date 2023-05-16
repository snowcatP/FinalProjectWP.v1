using MyApp_HiepBui.BS_Layer;
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
    public partial class UserControl_SuaNhanVien : UserControl
    {
        string err;
        DataTable dtNhanVien = null;
        BLNhanVien dbNV = new BLNhanVien();
        bool Sua = false;
        public UserControl_SuaNhanVien()
        {
            InitializeComponent();
        }
        void loadDataNV()
        {
            try
            {
                dtNhanVien = new DataTable();
                dtNhanVien.Clear();
                DataSet ds = dbNV.Lay_DSNhanVien_Full();
                dtNhanVien = ds.Tables[0];
                dgv_UserControl_SuaNhanVien.DataSource = dtNhanVien;
                dgv_UserControl_SuaNhanVien.AutoResizeColumns();

                //
                txt_AddName.ResetText();
                dateTimePicker_Add.ResetText();
                txt_AddDiaChi.ResetText();
                txt_AddPhone.ResetText();
                txt_AddStatusEmp.ResetText();
                txt_AddIDKOE.ResetText();
                txt_AddIDGroupEmp.ResetText();
                txt_AddIDTypeUser.ResetText();
                txt_AddIDStore.ResetText();
            }
            catch (SqlException)
            {

                throw;
            }
        }

        private void UserControl_SuaNhanVien_Load_1(object sender, EventArgs e)
        {
            loadDataNV();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (Sua)
            {
                try
                {
                    // Thực hiện lệnh
                    BLNhanVien blNhanVien = new BLNhanVien();
                    int value_StatusEmp = Convert.ToInt32(txt_AddStatusEmp.Text);
                    dateTimePicker_Add.CustomFormat = "yyyy-MM-dd";
                    blNhanVien.SuaNhanVien(txt_AddID.Text, txt_AddName.Text, dateTimePicker_Add.Text, txt_AddDiaChi.Text, txt_AddPhone.Text,
                        value_StatusEmp, txt_AddIDKOE.Text, txt_AddIDGroupEmp.Text,
                        txt_AddIDTypeUser.Text, txt_AddIDStore.Text, ref err);
                    // Load lại dữ liệu trên DataGridView
                    loadDataNV();
                    // Thông báo
                    MessageBox.Show("Đã thêm xong!");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không thêm được. Lỗi rồi!");
                }
            }

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            txt_AddName.ResetText();
            dateTimePicker_Add.ResetText();
            txt_AddDiaChi.ResetText();
            txt_AddPhone.ResetText();
            txt_AddStatusEmp.ResetText();
            txt_AddIDKOE.ResetText();
            txt_AddIDGroupEmp.ResetText();
            txt_AddIDTypeUser.ResetText();
            txt_AddIDStore.ResetText();
        }


    }
}
