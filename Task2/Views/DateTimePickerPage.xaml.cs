using Task2.ViewModels;

namespace Task2.Views;

public partial class DateTimePickerPage : ContentPage
{
    public DateTimePickerPage(DateTime dt, EventHandler DateTimeChanged)
    {
        InitializeComponent();
        BindingContext = new DateTimePickerPageVM(this, dt, DateTimeChanged);
    }
}