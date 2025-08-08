using Task2.Models;
using Task2.Views;
using System.Windows.Input;
using Task2.ModelsLogic;

namespace Task2.ViewModels
{
    public partial class ProductPageVM:ObservableObject
    {
        private readonly Product product;
        private readonly ProductPage pp;
        private event EventHandler? ProductChanged;
        private event EventHandler? ProductDeleted;
        public ICommand ProductChangedCommand { get; private set; }
        public ICommand ProductDeletedCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }
        public ICommand SetValidDateCommand { get; private set; }

        public ProductPageVM(ProductPage pp, Product p, EventHandler? ProductChanged, EventHandler? ProductDeleted) 
        {
            product = p;
            this.pp = pp;
            this.ProductChanged = ProductChanged;
            this.ProductDeleted = ProductDeleted;
            ProductChangedCommand = new Command(OnProductChanged);
            ProductDeletedCommand = new Command(OnProductDeleted);
            CancelCommand = new Command(OnCancel);
            SetValidDateCommand = new Command(SetValidDate);

        }
        private void SetValidDate(object obj)
        {
            DateTimePickerPage dtpp = new(product.ValidDate, OnDateTimeChanged);
            pp.Navigation.PushAsync(dtpp, true);
        }
        private void OnDateTimeChanged(object? sender, EventArgs e)
        {
            if (sender != null)
            {
                product.ValidDate = (DateTime)sender;
                OnProductChanged(nameof(ValidDateFormated));
            }
        }
        private void OnCancel(object obj)
        {
            pp.Navigation.PopAsync();
        }

        public string Name
        {
            get => product.Name;
            set => product.Name = value;
        }
        public double Price
        {
            get => product.Price;
            set => product.Price = value;
        }
        public string ValidDateFormated
        {
            get => product.ValidDateFormated;
        }
        private void OnProductDeleted(object obj)
        {
            ProductDeleted?.Invoke(product, EventArgs.Empty);
            pp.Navigation.PopAsync();
        }
        private void OnProductChanged(object obj)
        {
            ProductChanged?.Invoke(product, EventArgs.Empty);
            pp.Navigation.PopAsync();
        }
    }
}
