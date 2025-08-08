using Task2.Utilities;
using Task2.Views;

namespace Task2
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(Strings.ProductsPageKey, typeof(ProductsPage));
            Routing.RegisterRoute(Strings.OrdersPageKey, typeof(OrdersPage));
        }
    }
}
