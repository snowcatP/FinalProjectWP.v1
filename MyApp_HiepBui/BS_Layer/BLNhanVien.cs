using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MyApp_HiepBui.DB_Layer;
namespace MyApp_HiepBui.BS_Layer
{
    class BLNhanVien
    {
        DBMain db = null;
        public BLNhanVien()
        {
            db = new DBMain();
        }
        public BLNhanVien(string connstr)
        {
            db = new DBMain(connstr);
        }
        public System.Data.Linq.Table<Employees_View> Get_Employee_Is_Working()
        {
            DataSet ds = new DataSet();
            ConvenienceStoreManagementDataContext qlNV = new ConvenienceStoreManagementDataContext();
            return qlNV.Employees_Views;
        }

        public bool Add_Employee(string hoten, string ngaysinh, string diachi, string sdt,
                                    int tinhtrang, string idKindEmp, string idGroup, string idTypeUser, string idStore, ref string err)
        {
            //ConvenienceStoreManagementDataContext qlNV = new ConvenienceStoreManagementDataContext();
            //EMPLOYEE el = new EMPLOYEE();
            //el.Name = hoten;
            //el.DateOfBirth = Convert.ToDateTime(ngaysinh);
            //el.Address = diachi;
            //el.Phone = sdt;
            //el.Status_emp = Convert.ToBoolean(tinhtrang);
            //el.IDKindEmp = idKindEmp;
            //el.IDGroup = idGroup;
            //el.IDTypeUser = idTypeUser;
            //el.IDStore = idStore;

            //qlNV.EMPLOYEEs.InsertOnSubmit(el);
            //qlNV.EMPLOYEEs.Context.SubmitChanges();
            using (ConvenienceStoreManagementDataContext qlNV = new ConvenienceStoreManagementDataContext())
            {
                try
                {
                    var el = qlNV.Add_Employee(hoten, Convert.ToDateTime(ngaysinh), diachi, sdt, Convert.ToBoolean(tinhtrang),
                        idKindEmp, idGroup, idTypeUser, idStore);
                }
                catch (SqlException)
                {
                    err = "Some thing was wrong, try again";
                }
                return true;
            }
            return true;

        }

        public bool Delete_Employee(string id, ref string err)
        {
            ConvenienceStoreManagementDataContext qlNV = new ConvenienceStoreManagementDataContext();
            var elQuery = from el in qlNV.EMPLOYEEs
                          where el.IDEmp == id
                          select el;
            qlNV.EMPLOYEEs.DeleteAllOnSubmit(elQuery);
            qlNV.SubmitChanges();
            return true;
        }
        public bool Update_Employee(string id, string hoten, string ngaysinh, string diachi, string sdt,
                                    int tinhtrang, string idKindEmp, string idGroup, string idTypeUser, string idStore, ref string err)
        {
            ConvenienceStoreManagementDataContext qlNV = new ConvenienceStoreManagementDataContext();
            var elQuery = (from el in qlNV.EMPLOYEEs
                           where el.IDEmp == id
                           select el).SingleOrDefault();
            if (elQuery != null)
            {
                elQuery.Name = hoten;
                elQuery.DateOfBirth = Convert.ToDateTime(ngaysinh);
                elQuery.Address = diachi;
                elQuery.Phone = sdt;
                elQuery.Status_emp = Convert.ToBoolean(tinhtrang);
                elQuery.IDKindEmp = idKindEmp;
                elQuery.IDGroup = idGroup;
                elQuery.IDTypeUser = idTypeUser;
                elQuery.IDStore = idStore;
                qlNV.SubmitChanges();
            }
            return true;
        }

        public DataSet Lay_DSNhanVien_DangLamViec()
        {
            return db.ExecuteQueryDataSet("select * from [Employees View]", CommandType.Text);
        }
        public DataSet Lay_DSNhanVien_Full()
        {
            return db.ExecuteQueryDataSet("select * from [EMPLOYEES]", CommandType.Text);
        }
        public DataTable Get_Full_List_Employee()
        {
            ConvenienceStoreManagementDataContext qlNV = new ConvenienceStoreManagementDataContext();
            var elQuery = (from el in qlNV.EMPLOYEEs
                           select el);
            DataTable dt = new DataTable();
            dt.Columns.Add("IDEmp");
            dt.Columns.Add("Name");
            dt.Columns.Add("DateOfBirth");
            dt.Columns.Add("Address");
            dt.Columns.Add("Phone");
            dt.Columns.Add("Status_Emp");
            dt.Columns.Add("IDKindEmp");
            dt.Columns.Add("IDGroup");
            dt.Columns.Add("IDTypeUser");
            dt.Columns.Add("IDStore");
            foreach (var el in elQuery)
            {
                dt.Rows.Add(el.IDEmp, el.Name, el.DateOfBirth.ToString("MM/dd/yyyy"), el.Address, el.Phone, el.Status_emp, el.IDKindEmp,
                    el.IDGroup, el.IDTypeUser, el.IDStore);
            }
            return dt;
        }
        //public DataSet Get_List_StatusEmp()
        //{
        //    return db.ExecuteQueryDataSet("select IDEmp,Name, DateOfBirth, Address, Phone, Status_emp from [EMPLOYEES]", CommandType.Text);
        //}
        //public DataSet Get_List_Kind_Of_Employee()
        //{
        //    return db.ExecuteQueryDataSet("select * from [KIND_OF_EMPLOYEE]", CommandType.Text);
        //}
        //public DataSet Get_List_Group_Of_Employee()
        //{
        //    return db.ExecuteQueryDataSet("select * from [GROUP_OF_EMPLOYEE]", CommandType.Text);
        //}
        //public DataSet Get_List_Type_Of_User()
        //{
        //    return db.ExecuteQueryDataSet("select * from [TYPE_OF_USER]", CommandType.Text);
        //}
        public DataTable Get_List_Kind_Of_Employee()
        {
            ConvenienceStoreManagementDataContext qlNV = new ConvenienceStoreManagementDataContext();
            var elQuery = (from el in qlNV.KIND_OF_EMPLOYEEs
                           select el);
            DataTable dt = new DataTable();
            dt.Columns.Add("IDKindEmp");
            dt.Columns.Add("Name");
            foreach (var el in elQuery)
            {
                dt.Rows.Add(el.IDKindEmp, el.Name);
            }
            return dt;
        }
        public DataTable Get_List_Group_Of_Employee()
        {
            ConvenienceStoreManagementDataContext qlNV = new ConvenienceStoreManagementDataContext();
            var elQuery = (from el in qlNV.GROUP_OF_EMPLOYEEs
                           select el);
            DataTable dt = new DataTable();
            dt.Columns.Add("IDGroup");
            dt.Columns.Add("NameOfGroup");
            foreach (var el in elQuery)
            {
                dt.Rows.Add(el.IDGroup, el.NameOfGroup);
            }
            return dt;
        }
        public DataTable Get_List_Type_Of_User()
        {
            ConvenienceStoreManagementDataContext qlNV = new ConvenienceStoreManagementDataContext();
            var elQuery = (from el in qlNV.TYPE_OF_USERs
                           select el);
            DataTable dt = new DataTable();
            dt.Columns.Add("IDTypeUser");
            dt.Columns.Add("NameTypeOfUser");
            dt.Columns.Add("IDAuthority");
            foreach (var el in elQuery)
            {
                dt.Rows.Add(el.IDTypeUser, el.NameTypeOfUser, el.IDAuthority);
            }
            return dt;
        }
        public bool ThemNhanVien(string hoten, string ngaysinh, string diachi, string sdt,
                                    int tinhtrang, string idKindEmp, string idGroup, string idTypeUser, string idStore, ref string err)
        {
            string sqlString = "EXEC Add_Employee @name=N'"
                               + hoten + "', @dateofbirth=" +
                               "'" + ngaysinh + "', @address=" +
                               "N'" + diachi + "', @phone=" +
                               "'" + sdt +
                               "', @status_emp=" + tinhtrang + ",@idkindemp='" +
                               idKindEmp +
                               "',@idgroup= '" + idGroup +
                               "',@idtypeuser= '" + idTypeUser +
                               "',@idstore= '" + idStore + "'";

            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool SuaNhanVien(string id, string hoten, string ngaysinh, string diachi, string sdt,
                                    int tinhtrang, string idKindEmp, string idGroup, string idTypeUser, string idStore, ref string err)
        {
            string sqlString = "EXEC Edit_Employee @ide='" + id + "',@name=N'"
                               + hoten + "', @dateofbirth=" +
                               "'" + ngaysinh + "', @address=" +
                               "N'" + diachi + "', @phone=" +
                               "'" + sdt +
                               "', @status_emp=" + tinhtrang + ",@id_kind_emp='" +
                               idKindEmp +
                               "',@id_group= '" + idGroup +
                               "',@id_type_user= '" + idTypeUser +
                               "',@id_store= '" + idStore + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool XoaNhanVien(string id, ref string err)
        {
            string sqlString = "DELETE FROM EMPLOYEES WHERE IDEmp='" + id + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);

        }
        //public DataSet SearchInfo(string content)
        //{
        //    string str;
        //    str = $"SELECT * FROM dbo.[Employees View] " +
        //        $"WHERE Name LIKE N'%{content}%'";
        //    return db.ExecuteQueryDataSet(str, CommandType.Text);
        //}
        public DataTable SearchInfo(string content)
        {
            //try
            //{
            //    string str;
            //    str = $"SELECT * FROM dbo.[Employees View] " +
            //        $"WHERE Name LIKE N'%{content}%'";
            //    //return db.ExecuteQueryDataSet(str, CommandType.Text);
            //    var tb = db.ExecuteQueryDataTable(str, CommandType.Text);
            //    if (tb.Rows.Count == 0)
            //    {
            //        throw new Exception("No results found");
            //    }
            //    return tb;
            //}
            //catch (Exception ex)
            //{
            //    // Log the exception or display an error message to the user
            //    Console.WriteLine($"An error occurred while executing the query: {ex.Message}");
            //    return null;
            //}
            ConvenienceStoreManagementDataContext qlNV = new ConvenienceStoreManagementDataContext();
            var data = from el in qlNV.Employees_Views
                       where el.Name.Contains(content)
                       select new
                       {
                           el.IDEmp,
                           el.Name,
                           el.DateOfBirth,
                           el.Phone,
                           el.Address,
                           el.Position,
                           el.Type
        };

                data = data.Where(x => x.Name.Contains(content));

            DataTable dt = new DataTable();
            dt.Columns.Add("IDEmp");
            dt.Columns.Add("Name");
            dt.Columns.Add("DateOfBirth");
            dt.Columns.Add("Phone");
            dt.Columns.Add("Address");
            dt.Columns.Add("Position");
            dt.Columns.Add("Type");

            foreach (var el in data)
            {
                dt.Rows.Add(
                    el.IDEmp,
                    el.Name,
                    el.DateOfBirth.ToString("MM/dd/yyyy"),
                    el.Phone,
                    el.Address,
                    el.Position,
                    el.Type 
                );
            }
            return dt;
        }
    

        public DataSet Salary_Of_Employee()
        {
            return db.ExecuteQueryDataSet("SELECT * FROM dbo.[Salary_Of_Employee]", CommandType.Text);
        }
        public System.Data.Linq.Table<Salary_Of_Employee> Get_Salary_Of_Employee()
        {
            DataSet ds = new DataSet();
            ConvenienceStoreManagementDataContext qlNV = new ConvenienceStoreManagementDataContext();
            return qlNV.Salary_Of_Employees;
        }
        //public DataSet Account_Employee()
        //{
        //    return db.ExecuteQueryDataSet("SELECT * FROM dbo.[v_Account&Authority]", CommandType.Text);
        //}
        public System.Data.Linq.Table<v_Account_Authority> Get_Account_Of_Employee()
        {
            DataSet ds = new DataSet();
            ConvenienceStoreManagementDataContext qlNV = new ConvenienceStoreManagementDataContext();
            return qlNV.v_Account_Authorities;
        }
        public bool Add_Account_Emp(string id, string username, string password, ref string err)
        {
            //string sqlString = "EXEC Add_Account @ide='"
            //                   + id + "', @username=" +
            //                   "'" + username + "', @password=" +
            //                   "'" + password +"'";

            //return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
            using (ConvenienceStoreManagementDataContext qlNV = new ConvenienceStoreManagementDataContext())
            {
                try
                {
                    var el = qlNV.Add_Account(id,username, password);
                }
                catch (SqlException)
                {
                    err = "Some thing was wrong, try again";
                }
                return true;
            }
            return true;
        }
        public bool Modify_Account_Emp(string id, string username, string password, ref string err)
        {
            //    string sqlString = "EXEC Edit_Account @ide='"
            //                       + id + "', @username=" +
            //                       "'" + username + "', @password=" +
            //                       "'" + password + "'";
            //    return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
            using (ConvenienceStoreManagementDataContext qlNV = new ConvenienceStoreManagementDataContext())
            {
                try
                {
                    var el = qlNV.Edit_Account(id, username, password);
                }
                catch (SqlException)
                {
                    err = "Some thing was wrong, try again";
                }
                return true;
            }
            return true;
        }
        public bool Add_Salary_Emp(string id, string totaltime, ref string err)
        {

            //string sqlString = "EXEC Add_WorkingTime @ide='"
            //                   + id + "', @totaltime=" +
            //                   "'" + Convert.ToInt32(totaltime) + "'";

            //return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
            using (ConvenienceStoreManagementDataContext qlNV = new ConvenienceStoreManagementDataContext())
            {
                try
                {
                    var el = qlNV.Add_WorkingTime(id, Convert.ToInt32(totaltime));
                }
                catch (SqlException)
                {
                    err = "Some thing was wrong, try again";
                }
                return true;
            }
            return true;

        }
        public bool Modify_Salary_Emp(string id, string totaltime, ref string err)
        {
            //string sqlString = "EXEC Edit_WorkingTime @ide='"
            //                   + id + "', @totaltime=" +
            //                   "'" + Convert.ToInt32(totaltime) + "'";
            //return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
            using (ConvenienceStoreManagementDataContext qlNV = new ConvenienceStoreManagementDataContext())
            {
                try
                {
                    var el = qlNV.Edit_WorkingTime(id, Convert.ToInt32(totaltime));
                }
                catch (SqlException)
                {
                    err = "Some thing was wrong, try again";
                }
                return true;
            }
            return true;

        }
    }
}
