using System.Collections.ObjectModel;
using System.Windows.Input;
using Task2.Models;
using Task2.ModelsLogic;
using Task2.Views;

namespace Task2.ViewModels
{
    internal class OrdersPageVM : ObservableObject
    {
        private readonly Orders orders;
        public ICommand AddOrderCommand { get; private set; }
        public ICommand OpenOrderCommand { get; private set; }
        public Order? SelectedOrder { get; set; }
        public OrdersPageVM()
        {
            AddOrderCommand = new Command(AddOrder);
            OpenOrderCommand = new Command(OpenOrder);
            orders = new ();
        }

        private void OpenOrder()
        {
            if (SelectedOrder != null)
                OpenOrderPage(SelectedOrder);
        }

        private void AddOrder(object obj)
        {
            OpenOrderPage(null);
        }
        public ObservableCollection<Order> Orders
        {
            get => orders.OrdersList;
            set
            {
                if (orders.OrdersList != value)
                {
                    orders.OrdersList = value;
                    OnPropertyChanged();
                }
            }
        }
        public void OpenOrderPage(Order? o)
        {
            o ??= new Order(); //if o is null
            OrderPage op = new(o, OnOrderChanged, OnOrderDeleted);
            Shell.Current.Navigation.PushAsync(op, true);
        }
        private void OnOrderChanged(object? sender, EventArgs e)
        {
            if (sender != null)
            {
                Order o = (Order)sender;
                orders.Set(o);
                OnPropertyChanged(nameof(Orders));
            }
        }
        private void OnOrderDeleted(object? sender, EventArgs e)
        {
            if (sender != null)
            {
                Order? o = (Order)sender;
                orders.Delete(o);
                OnPropertyChanged(nameof(Orders));
            }
        }
    }
}
