using SQLite;
using Task2.Models;
using System.Collections.ObjectModel;

namespace Task2.ModelsLogic
{
    public class SqlData:SqlDataModel
    {

        public SqlData()
        {
            string path = Path.Combine(FileSystem.AppDataDirectory, DbName);
            IsNewDb = !File.Exists(path);
            conn = new SQLiteConnection(path);
            if (IsNewDb)
            {
                conn.CreateTable<Product>();
                conn.CreateTable<Order>();
                conn.CreateTable<SqlUser>();
            }
        }
        public override bool Insert(object obj)
        {
            int rows = (conn != null) ? conn.Insert(obj) : 0;
            return rows > 0;
        }

        public override bool Update(object obj)
        {
            int rows = (conn != null) ? conn.Update(obj) : 0;
            return rows > 0;
        }

        public override bool Delete(object obj)
        {
            int rows = (conn != null) ? conn.Delete(obj) : 0;
            return rows > 0;
        }
        public override ObservableCollection<Product> GetProducts()
        {
            List<Product> lstProducts = (conn != null) ? [.. conn.Table<Product>()]: [];
            ObservableCollection<Product> ocProducts = [.. lstProducts];
            return ocProducts;
        }

        public override ObservableCollection<Order> GetOrders()
        {
            List<Order> lstOrders = (conn != null) ? [.. conn.Table<Order>()] : [];
            ObservableCollection<Order> ocOrders = [.. lstOrders];
            return ocOrders;
        }

        public override ObservableCollection<SqlUser> GetUsers()
        {
            List<SqlUser> lstUsers = (conn != null) ? [.. conn.Table<SqlUser>()] : [];
            ObservableCollection<SqlUser> ocOrders = [.. lstUsers];
            return ocOrders;
        }
    }
}
