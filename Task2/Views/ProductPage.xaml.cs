using Task2.ModelsLogic;
using Task2.ViewModels;

namespace Task2.Views;

public partial class ProductPage : ContentPage
{
    public ProductPage(Product product, EventHandler? ProductChanged, EventHandler? ProductDeleted)
    {
        InitializeComponent();
        BindingContext = new ProductPageVM(this, product, ProductChanged, ProductDeleted);
    }
}