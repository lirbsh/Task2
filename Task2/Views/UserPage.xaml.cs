using Task2.ViewModels;

namespace Task2.Views;

public partial class UserPage : ContentPage
{
    public UserPage()
    {
        InitializeComponent();
        BindingContext = new UserPageVM();
    }
}