using System.Windows.Input;
using Task2.Models;
using Task2.Views;

namespace Task2.ViewModels
{
    internal class OrderPageVM : ObservableObject
    {
        private readonly Order order;
        private readonly OrderPage op;
        private event EventHandler? OrderChanged;
        private event EventHandler? OrderDeleted;
        public ICommand OrderChangedCommand { get; private set; }
        public ICommand OrderDeletedCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }

        public OrderPageVM(OrderPage op, Order o, EventHandler? OrderChanged, EventHandler? OrderDeleted)
        {
            order = o;
            this.op = op;
            this.OrderChanged = OrderChanged;
            this.OrderDeleted = OrderDeleted;
            OrderChangedCommand = new Command(OnOrderChanged);
            OrderDeletedCommand = new Command(OnOrderDeleted);
            CancelCommand = new Command(OnCancel);
        }
        private void OnCancel(object obj)
        {
            op.Navigation.PopAsync();
        }

        public string Name
        {
            get => order.Name;
            set => order.Name = value;
        }
        public double Price
        {
            get => order.Price;
            set => order.Price = value;
        }
        private void OnOrderDeleted(object obj)
        {
            OrderDeleted?.Invoke(order, EventArgs.Empty);
            op.Navigation.PopAsync();
        }
        private void OnOrderChanged(object obj)
        {
            OrderChanged?.Invoke(order, EventArgs.Empty);
            op.Navigation.PopAsync();
        }
    }
}
