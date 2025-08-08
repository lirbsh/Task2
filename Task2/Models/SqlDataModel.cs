using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.ModelsLogic;

namespace Task2.Models
{
    internal abstract class SqlDataModel
    {
        protected SQLiteConnection? conn;
        protected const string DbName = "sql.data";
        public bool IsNewDb { get; protected set; }
        public abstract bool Insert(object obj);
        public abstract bool Update(object obj);
        public abstract bool Delete(object obj);
        public abstract ObservableCollection<Product> GetProducts();
        public abstract ObservableCollection<Order> GetOrders();

    }
}
