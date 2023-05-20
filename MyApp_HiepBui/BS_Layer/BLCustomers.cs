using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MyApp_HiepBui.DB_Layer;
namespace MyApp_HiepBui.BS_Layer
{
    class BLCustomers
    {
        public BLCustomers()
        {

        }
        public DataGridView GetInfo_Customer(DataGridView data)
        {
            using (ConvenienceStoreManagementDataContext convenience = new ConvenienceStoreManagementDataContext())
            {
                var query = from u in convenience.v_Info_Of_Customers
                            select u;
                data.DataSource = query;
                return data;
            }

        }
        public void addCustomer(string Name, string Phone, DateTime OpeningDate, DateTime TransactionDate, int AccumulatedPoint, ref string error)
        {
            using (ConvenienceStoreManagementDataContext convenience = new ConvenienceStoreManagementDataContext())
            {
                string IdCus;
                var query = (from u in convenience.AutoGenerateIDCustomer()
                             select u).Aggregate(string.Empty, (current, next) => current + next);
                IdCus = query.ToString();
                CUSTOMER cus = new CUSTOMER();
                cus.IDCustomer = IdCus;
                cus.Name = Name;
                cus.Phone = Phone;
                cus.OpeningDate = OpeningDate;
                cus.TransactionDate = TransactionDate;
                cus.AccumulatedPoint = AccumulatedPoint;
                convenience.CUSTOMERs.InsertOnSubmit(cus);
                convenience.CUSTOMERs.Context.SubmitChanges();
            }
        }
        public DataGridView searchCustomer(string Phone, DataGridView data)
        {
            using (ConvenienceStoreManagementDataContext convenience = new ConvenienceStoreManagementDataContext())
            {
                var Query = (from u in convenience.v_Info_Of_Customers
                             where u.Phone == Phone
                             select u);

                data.DataSource = Query;
                return data;
            }
        }
        public void delCustomer(string IDCustomer, ref string error)
        {
            using (ConvenienceStoreManagementDataContext convenience = new ConvenienceStoreManagementDataContext())
            {
                var query = from u in convenience.CUSTOMERs
                            where u.IDCustomer == IDCustomer
                            select u;
                convenience.CUSTOMERs.DeleteAllOnSubmit(query);
                convenience.SubmitChanges();

            }
        }
        public void modifyCustomer(string IDCustomer, string Name, string Phone, DateTime OpeningDate, DateTime TransactionDate, int AccumulatedPoint, ref string error)
        {
            using (ConvenienceStoreManagementDataContext convenience = new ConvenienceStoreManagementDataContext())
            {
                var query = (from u in convenience.CUSTOMERs
                             where u.IDCustomer == IDCustomer
                             select u).Single();
                if (query != null)
                {

                    query.Name = Name;
                    query.Phone = Phone;
                    query.OpeningDate = OpeningDate;
                    query.TransactionDate = TransactionDate;
                    query.AccumulatedPoint = AccumulatedPoint;
                    convenience.SubmitChanges();
                }
                else
                {   
                    return;
                }


            }
        }
        public int analyseCustomer(int Month_of_OpeningDate, ref string error)
        {
            using (ConvenienceStoreManagementDataContext convenience = new ConvenienceStoreManagementDataContext())
            {
                var query = (from u in convenience.CUSTOMERs
                             where u.OpeningDate.Month == Month_of_OpeningDate
                             select u).Count();
                int i = Convert.ToInt32(query);
                return i;
            }
        }

    }
}
