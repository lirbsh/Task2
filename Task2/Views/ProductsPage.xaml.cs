using Task2.ViewModels;

namespace Task2.Views;

public partial class ProductsPage : ContentPage
{
	public ProductsPage()
	{
		InitializeComponent();
		BindingContext = new ProductsPageVM();
    }
}