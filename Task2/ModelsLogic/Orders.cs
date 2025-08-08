using Task2.Models;

namespace Task2.ModelsLogic
{
    internal class Orders:OrdersModel
    {
        public override bool Set(Order order)
        {
            bool result;
            if (order.Id == 0)
            {
                result = sqd.Insert(order);
                if (result)
                    OrdersList.Add(order);
            }
            else
                result = sqd.Update(order);
            if (result)
                OrdersList = sqd.GetOrders();
            return result;
        }
        public override bool Delete(Order order)
        {
            bool result = sqd.Delete(order);
            if (result)
                OrdersList.Remove(order);
            return result;
        }
    }
}

