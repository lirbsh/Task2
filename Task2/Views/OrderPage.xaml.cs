using Task2.Models;
using Task2.ViewModels;

namespace Task2.Views;

public partial class OrderPage : ContentPage
{
    public OrderPage(Order order, EventHandler? OrderChanged, EventHandler? OrderDeleted)
    {
        InitializeComponent();
        BindingContext = new OrderPageVM(this, order, OrderChanged, OrderDeleted);
    }
}