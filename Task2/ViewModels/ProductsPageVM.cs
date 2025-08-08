using System.Collections.ObjectModel;
using System.Windows.Input;
using Task2.Models;
using Task2.ModelsLogic;
using Task2.Views;

namespace Task2.ViewModels
{
    internal partial class ProductsPageVM : ObservableObject
    {
        private readonly Products products;
        public ICommand AddProductCommand { get; private set; }
        public ICommand OpenProductCommand { get; private set; }
        public Product? SelectedProduct { get; set; } 
        public ProductsPageVM()
        {
            AddProductCommand = new Command(AddProduct);
            OpenProductCommand = new Command(OpenProduct);
            products = new Products();
        }

        private void OpenProduct()
        {
            if (SelectedProduct !=null)
                OpenProductPage(SelectedProduct);
        }

        private void AddProduct(object obj)
        {
            OpenProductPage(null);
        }
        public ObservableCollection<Product> Products
        {
            get => products.ProductsList;
            set
            {
                if (products.ProductsList != value)
                {
                    products.ProductsList = value;
                    OnPropertyChanged();
                }
            }
        }
        public void OpenProductPage(Product? p)
        {
            p ??= new Product(); //if p is null
            ProductPage pp = new(p, OnProductChanged, OnProductDeleted);
            Shell.Current.Navigation.PushAsync(pp, true);
        }
        private void OnProductChanged(object? sender, EventArgs e)
        {
            if (sender != null)
            {
                Product p = (Product)sender;
                products.Set(p);
                OnPropertyChanged(nameof(Products));
            }
        }
        private void OnProductDeleted(object? sender, EventArgs e)
        {
            if (sender != null)
            {
                Product? p = (Product)sender;
                products.Delete(p);
                OnPropertyChanged(nameof(Products));
            }
        }
    }
}
