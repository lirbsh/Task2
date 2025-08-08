using System.Collections.ObjectModel;
using Task2.ModelsLogic;

namespace Task2.Models
{
    internal abstract class ProductsModel
    {
        protected readonly SqlData sqd;
        public ObservableCollection<Product> ProductsList { get; set; }

        public ProductsModel()
        {
            sqd = new ();
            ProductsList = sqd.GetProducts();
        }
        public abstract bool Set(Product product);
        public abstract bool Delete(Product product);
    }
}
