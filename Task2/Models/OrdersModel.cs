using System.Collections.ObjectModel;
using Task2.ModelsLogic;

namespace Task2.Models
{
    internal abstract class OrdersModel
    {
        protected readonly SqlData sqd;
        public ObservableCollection<Order> OrdersList { get; set; }

        public OrdersModel()
        {
            sqd = new();
            OrdersList = sqd.GetOrders();
        }
        public abstract bool Set(Order order);
        public abstract bool Delete(Order order);
    }
}
