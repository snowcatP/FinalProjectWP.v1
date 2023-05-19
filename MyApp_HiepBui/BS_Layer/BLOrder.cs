using MyApp_HiepBui.DB_Layer;
using System;
using System.Data;
using System.Linq;

namespace MyApp_HiepBui.BS_Layer
{
    public class BLOrder
    {
        public BLOrder()
        {

        }
        public DataTable GetNameOfItem()
        {
            using (ConvenienceStoreManagementDataContext store = new ConvenienceStoreManagementDataContext())
            {
                var data = from it in store.ITEMs
                           select new
                           {
                               it.IDItem,
                               it.NameItem,
                               it.Price
                           };

                DataTable dt = new DataTable();
                dt.Columns.Add("IDItem");
                dt.Columns.Add("NameItem");
                dt.Columns.Add("Price");

                foreach (var item in data)
                {
                    dt.Rows.Add(
                        item.IDItem,
                        item.NameItem,
                        item.Price);
                }
                return dt;
            }
        }
        public DataTable GetPhoneOfCus()
        {
            using (ConvenienceStoreManagementDataContext store = new ConvenienceStoreManagementDataContext())
            {
                var data = from cus in store.CUSTOMERs
                           select cus.Phone;
                DataTable dt = new DataTable();
                dt.Columns.Add("Phone");
                foreach (var item in data)
                {
                    dt.Rows.Add(item);
                }
                return dt;
            }
        }
        public string TakeNameCus(string phone)
        {
            using (ConvenienceStoreManagementDataContext store = new ConvenienceStoreManagementDataContext())
            {
                var data = (from cus in store.CUSTOMERs
                            where cus.Phone == phone
                            select cus.Name).SingleOrDefault();
                return data.ToString();
            }
        }
        public DataTable SearchingInfo(string content, string category)
        {
            using (ConvenienceStoreManagementDataContext store = new ConvenienceStoreManagementDataContext())
            {
                var data = from it in store.ITEMs
                           join iio in store.ITEM_IN_ORDERs on it.IDItem equals iio.IDItem
                           join or in store.ORDERs on iio.IDOrder equals or.IDOrder
                           join cus in store.CUSTOMERs on or.IDCustomer equals cus.IDCustomer
                           join wh in store.WAREHOUSEs on it.IDItem equals wh.IDItem
                           select new
                           {
                               IDOrder = or.IDOrder,
                               NameCus = cus.Name,
                               Phone = cus.Phone,
                               TotalPrice = or.TotalPrice,
                               TotalQuantity = store.WAREHOUSEs.Where(
                                                wareh => wareh.IDItem == wh.IDItem
                                                ).Sum(wareh => wareh.NumberOfItem),
                               DayTransaction = or.InvoiceDay
                           };

                if (category == "Phone")
                    data = data.Where(x => x.Phone.Contains(content));
                
                else if (category == "Name")
                    data = data.Where(x => x.NameCus.Contains(content));

                DataTable dt = new DataTable();
                dt.Columns.Add("ID Order");
                dt.Columns.Add("Name customer");
                dt.Columns.Add("Total price");
                dt.Columns.Add("Total quantity");
                dt.Columns.Add("Day transaction");

                foreach (var item in data)
                {
                    dt.Rows.Add(
                        item.IDOrder,
                        item.NameCus,
                        item.TotalPrice,
                        item.TotalQuantity,
                        item.DayTransaction.ToString("dd/MM/yyyy"));
                    return dt;
                }
                return dt;
            }
        }

        public string GetNewIDOrder()
        {
            using (ConvenienceStoreManagementDataContext store = new ConvenienceStoreManagementDataContext())
            {
                var data = store.AutoGenerateIDOrder();
                return data.ToString();
            }
        }
        public int GetOrdersInMonth()
        {
            using (ConvenienceStoreManagementDataContext store = new ConvenienceStoreManagementDataContext())
            {
                var data = from or in store.ORDERs
                           where or.InvoiceDay.Month - DateTime.Now.Month == 0
                                && or.InvoiceDay.Year - DateTime.Now.Year == 0
                           select or;
                return data.Count();
            }
        }
        public int GetCustomerVisitedThisMonth()
        {
            using (ConvenienceStoreManagementDataContext store = new ConvenienceStoreManagementDataContext())
            {
                var data = from or in store.ORDERs
                           join cus in store.CUSTOMERs on or.IDCustomer equals cus.IDCustomer
                           where or.InvoiceDay.Month - DateTime.Now.Month == 0
                                && or.InvoiceDay.Year - DateTime.Now.Year == 0
                                && or.IDCustomer == cus.IDCustomer
                           select or;
                return data.Count();
            }

        }
        public int GetWeeklyRevenue()
        {
            using (ConvenienceStoreManagementDataContext store = new ConvenienceStoreManagementDataContext())
            {
                var data = from or in store.ORDERs
                           where or.InvoiceDay.Month - DateTime.Now.Month == 0
                                && or.InvoiceDay.Year - DateTime.Now.Year == 0
                                && Math.Abs(or.InvoiceDay.Day - DateTime.Now.Day) <= 7
                           select or.TotalPrice;
                return data.Sum();
            }
        }
        public int GetMonthlyRevenue()
        {
            using (ConvenienceStoreManagementDataContext store = new ConvenienceStoreManagementDataContext())
            {
                var data = from or in store.ORDERs
                           where or.InvoiceDay.Month - DateTime.Now.Month == 0
                                && or.InvoiceDay.Year - DateTime.Now.Year == 0
                           select or.TotalPrice;
                return data.Sum();
            }
        }
        public DataTable GetRevenueByYear()
        {
            using (ConvenienceStoreManagementDataContext store = new ConvenienceStoreManagementDataContext())
            {
                var data = from or in store.ORDERs
                           group or by new { or.InvoiceDay.Year, or.InvoiceDay.Month } into gr
                           orderby gr.Key.Year descending, gr.Key.Month descending
                           select new
                           {
                               Year = gr.Key.Year,
                               Month = gr.Key.Month,
                               Revenue = gr.Sum(x => x.TotalPrice)
                           };
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("Year");
                dataTable.Columns.Add("Month");
                dataTable.Columns.Add("Revenue");
                foreach (var item in data)
                {
                    dataTable.Rows.Add(
                        item.Year,
                        item.Month,
                        item.Revenue);
                }
                return dataTable;
            }
        }

        public bool AddNewOrder(string idOrder, string phone, string idItem, int quantity)
        {
            using (ConvenienceStoreManagementDataContext store = new ConvenienceStoreManagementDataContext())
            {
                var doPro = store.AddNewOrder(idOrder, phone, idItem, quantity);
                return true;
            }
        }
        public bool CreateNewOrder(string idOrder, string phone)
        {
            using (ConvenienceStoreManagementDataContext store = new ConvenienceStoreManagementDataContext())
            {
                var doPro = store.CreateNewOrder(idOrder, phone);
                return true;
            }
        }
        public DataTable GetAllOrders()
        {
            using (ConvenienceStoreManagementDataContext store = new ConvenienceStoreManagementDataContext())
            {
                var data = from or in store.ORDERs
                           join cus in store.CUSTOMERs on or.IDCustomer equals cus.IDCustomer
                           join iio in store.ITEM_IN_ORDERs on or.IDOrder equals iio.IDOrder
                           join it in store.ITEMs on iio.IDItem equals it.IDItem
                           join wh in store.WAREHOUSEs on it.IDItem equals wh.IDItem
                           group new { or, cus } by new { or.IDOrder, cus.Name, or.TotalPrice, or.InvoiceDay } into gr
                           select new
                           {
                               IDOrder = gr.Key.IDOrder,
                               NameCus = gr.Key.Name,
                               TotalPrice = gr.Key.TotalPrice,
                               InvoiceDay = gr.Key.InvoiceDay
                           };
                DataTable dt = new DataTable();
                dt.Columns.Add("ID Order");
                dt.Columns.Add("Name customer");
                dt.Columns.Add("Total price");
                dt.Columns.Add("Day transaction");
                foreach (var item in data)
                {
                    dt.Rows.Add(
                        item.IDOrder,
                        item.NameCus,
                        item.TotalPrice,
                        item.InvoiceDay.ToString("dd/MM/yyyy")
                        );
                }
                return dt;
            }

        }
    }
}
