using Task2.ViewModels;

namespace Task2.Views;

public partial class OrdersPage : ContentPage
{
	public OrdersPage()
	{
		InitializeComponent();
		BindingContext = new OrdersPageVM();
    }
}