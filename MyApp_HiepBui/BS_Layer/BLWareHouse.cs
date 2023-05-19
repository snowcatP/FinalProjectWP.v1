using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyApp_HiepBui.DB_Layer;

namespace MyApp_HiepBui.BS_Layer
{
    internal class BLWareHouse
    {
        public BLWareHouse()
        {

        }
        public DataTable CheckInventory()
        {
            ConvenienceStoreManagementDataContext store = new ConvenienceStoreManagementDataContext();

            var data = from it in store.ITEMs
                       join wh in store.WAREHOUSEs on it.IDItem equals wh.IDItem
                       join toi in store.TYPE_OF_ITEMs on it.IDType equals toi.IDType
                       join sup in store.SUPPLIERs on it.IDSupplier equals sup.IDSupplier
                       select new
                       {
                           it.IDItem,
                           it.NameItem,
                           it.Price,
                           Type = toi.NameTypeOfItem,
                           sup.NameOfSupplier,
                           wh.NumberOfItem,
                           it.ProductionDate,
                           it.ExpirationDate
                       };
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("IDItem");
            dataTable.Columns.Add("NameItem");
            dataTable.Columns.Add("Price");
            dataTable.Columns.Add("Type");
            dataTable.Columns.Add("NameOfSupplier");
            dataTable.Columns.Add("NumberOfItem");
            dataTable.Columns.Add("ProductionDate");
            dataTable.Columns.Add("ExpirationDate");

            foreach (var item in data)
            {
                dataTable.Rows.Add(
                    item.IDItem,
                    item.NameItem,
                    item.Price,
                    item.Type,
                    item.NameOfSupplier,
                    item.NumberOfItem,
                    item.ProductionDate.ToString("dd/MM/yyyy"),
                    item.ExpirationDate.ToString("dd/MM/yyyy")
                );
            }
            return dataTable;
        }
        public DataTable GetTypeOfItem()
        {
            ConvenienceStoreManagementDataContext store = new ConvenienceStoreManagementDataContext();
            var data = store.TYPE_OF_ITEMs.Select(x => x.NameTypeOfItem);
            
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("NameTypeOfItem");
            foreach (var item in data)
            {
                dataTable.Rows.Add(item);
            }
            return dataTable;
        }
        public DataTable GetNameOfSupplier()
        {
            ConvenienceStoreManagementDataContext store = new ConvenienceStoreManagementDataContext();
            var data = store.SUPPLIERs.Select(x => x.NameOfSupplier);
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("NameOfSupplier");
            foreach (var item in data)
            {
                dataTable.Rows.Add(item);
            }
            return dataTable;
        }
        public bool AddNewItem(string name, int price, DateTime dateTime, string type, string supplier,
            int quantity, ref string err)
        {
            using (ConvenienceStoreManagementDataContext store = new ConvenienceStoreManagementDataContext())
            {
                try
                {
                    var doPro = store.AddNewItem(name, price, dateTime, type, supplier, quantity);
                }
                catch (SqlException)
                {
                    err = "Some thing was wrong, try again";
                }
                return true;
            }
        }
        public bool ModifyItem(string id, string name, int price, string type, string supplier, ref string err)
        {
            ConvenienceStoreManagementDataContext store = new ConvenienceStoreManagementDataContext();
            var data = (from it in store.ITEMs
                        where it.IDItem == id
                        select it).SingleOrDefault();
            var idtype = (from typ in store.TYPE_OF_ITEMs
                            where typ.NameTypeOfItem == type
                            select typ.IDType).SingleOrDefault();
            var idsup = (from sup in store.SUPPLIERs
                         where sup.NameOfSupplier == supplier
                         select sup.IDSupplier).SingleOrDefault();
            if (data != null)
            {
                data.IDItem = id;
                data.NameItem = name;
                data.Price = price;
                data.IDType = idtype;
                data.IDSupplier = idsup;
                store.SubmitChanges();
            }
            return true;
        }
        public DataTable SearchInfo(string content, string category)
        {
            ConvenienceStoreManagementDataContext store = new ConvenienceStoreManagementDataContext();
            var data = from it in store.ITEMs
                       join wh in store.WAREHOUSEs on it.IDItem equals wh.IDItem
                       join toi in store.TYPE_OF_ITEMs on it.IDType equals toi.IDType
                       join sup in store.SUPPLIERs on it.IDSupplier equals sup.IDSupplier
                       select new
                       {
                           it.IDItem,
                           it.NameItem,
                           it.Price,
                           Type = toi.NameTypeOfItem,
                           sup.NameOfSupplier,
                           wh.NumberOfItem,
                           it.ProductionDate,
                           it.ExpirationDate
                       };

            if (category == "ID Item")
                data = data.Where(x => x.IDItem.Contains(content));
            if (category == "Name")
                data = data.Where(x => x.NameItem.Contains(content));
            if (category == "Type")
                data = data.Where(x => x.Type.Contains(content));
            if (category == "Supplier")
                data = data.Where(x => x.NameOfSupplier.Contains(content));

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("IDItem");
            dataTable.Columns.Add("NameItem");
            dataTable.Columns.Add("Price");
            dataTable.Columns.Add("Type");
            dataTable.Columns.Add("NameOfSupplier");
            dataTable.Columns.Add("NumberOfItem");
            dataTable.Columns.Add("ProductionDate");
            dataTable.Columns.Add("ExpirationDate");
            foreach (var item in data)
            {
                dataTable.Rows.Add(
                    item.IDItem,
                    item.NameItem,
                    item.Price,
                    item.Type,
                    item.NameOfSupplier,
                    item.NumberOfItem,
                    item.ProductionDate.ToString("dd/MM/yyyy"),
                    item.ExpirationDate.ToString("dd/MM/yyyy")
                );
            }
            return dataTable;
        }
        public int GetTotalItemInInventory()
        {
            using (ConvenienceStoreManagementDataContext store = new ConvenienceStoreManagementDataContext()){
                return (from wh in store.WAREHOUSEs
                        select wh.NumberOfItem).Sum();
            }
        }

        public int GetGoodsNeedImported()
        {
            using (ConvenienceStoreManagementDataContext store = new ConvenienceStoreManagementDataContext())
            {
                return (from wh in store.WAREHOUSEs
                        join it in store.ITEMs on wh.IDItem equals it.IDItem
                        where wh.NumberOfItem < 20
                        select it.IDItem).Count();
            }
        }
        public int GetGoodsImportedThisMonth()
        {
            using (ConvenienceStoreManagementDataContext store = new ConvenienceStoreManagementDataContext())
            {
                var data = from wh in store.WAREHOUSEs
                           join it in store.ITEMs on wh.IDItem equals it.IDItem
                           where Math.Abs(it.ProductionDate.Month - DateTime.Now.Month) <= 1 &&
                                 it.ProductionDate.Year - DateTime.Now.Year == 0
                           select wh.NumberOfItem;
                if(data.Count() > 0)
                    return data.Sum();
                else
                    return 0;
            }
        }
        public int GetMonthlySpending()
        {
            using (ConvenienceStoreManagementDataContext store = new ConvenienceStoreManagementDataContext())
            {
                var data = from wh in store.WAREHOUSEs
                            join it in store.ITEMs on wh.IDItem equals it.IDItem
                            where Math.Abs(it.ProductionDate.Month - DateTime.Now.Month) <= 1 &&
                                  it.ProductionDate.Year - DateTime.Now.Year == 0
                            select wh.NumberOfItem * it.Price;
                return data.Sum();
            }
        }
        public DataTable GetDataPieChart()
        {
            ConvenienceStoreManagementDataContext store = new ConvenienceStoreManagementDataContext();
            var data = from it in store.ITEMs
                       join wh in store.WAREHOUSEs on it.IDItem equals wh.IDItem
                       join toi in store.TYPE_OF_ITEMs on it.IDType equals toi.IDType
                       group wh by toi.NameTypeOfItem into gr
                       select new
                       {
                           Name = gr.Key,
                           Quantity = gr.Sum(x => x.NumberOfItem)
                       };
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Quantity");
            foreach (var item in data)
            {
                dataTable.Rows.Add(
                    item.Name,
                    item.Quantity
                );
            }
            return dataTable;
        }
        public DataTable GetMonthlySpendingAllTime()
        {
            ConvenienceStoreManagementDataContext store = new ConvenienceStoreManagementDataContext();
            var data = from it in store.ITEMs
                       join wh in store.WAREHOUSEs on it.IDItem equals wh.IDItem
                       where it.ProductionDate.Year == DateTime.Now.Year
                       group new { it, wh } by new { it.ProductionDate.Year, it.ProductionDate.Month } into gr
                       orderby gr.Key.Year descending, gr.Key.Month descending
                       select new
                       {
                           Month = gr.Key.Month,
                           MonthlySpending = gr.Sum(x => x.it.Price * x.wh.NumberOfItem)
                       };
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Month");
            dataTable.Columns.Add("MonthlySpending");
            foreach (var item in data)
            {
                dataTable.Rows.Add(
                    item.Month,
                    item.MonthlySpending
                );
            }
            return dataTable;
        }
    }
}