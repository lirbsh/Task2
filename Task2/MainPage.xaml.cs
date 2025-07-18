using Task2.ViewModels;

namespace Task2
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageVM();
        }

    }
}
