using Task2.Models;
namespace Task2.ModelsLogic
{
    class Products:ProductsModel
    {
        
        public override bool Set(Product product)
        {
            bool result;
            if (product.Id == 0)
            {
                result = sqd.Insert(product);
                if (result)
                    ProductsList.Add(product);
            }
            else
                result = sqd.Update(product);
                if (result) 
                    ProductsList = sqd.GetProducts(); 
            return result;
        }
        public override bool Delete(Product product)
        {
            bool result = sqd.Delete(product);
            if (result)
                ProductsList.Remove(product);
            return result;
        }
    }
}
