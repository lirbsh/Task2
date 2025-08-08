using Task2.Views;
using System.Windows.Input;

namespace Task2.ViewModels
{
    public class DateTimePickerPageVM
    {
        private DateTime dt;
        private readonly EventHandler DateTimeChanged;
        private readonly DateTimePickerPage dtpp;
        public ICommand SetDateTimeCommand { get;private set; }    
        public ICommand CancelCommand { get;private set; }    
        public DateTimePickerPageVM(DateTimePickerPage dtpp, DateTime dt, EventHandler DateTimeChanged)
        {
            this.dt = dt;
            this.DateTimeChanged = DateTimeChanged;
            this.dtpp = dtpp;
            SetDateTimeCommand = new Command(SetDateTime);
            CancelCommand = new Command(Cancel);
        }
        private void Cancel(object? obj)
        {
            dtpp.Navigation.PopAsync();
        }
        private void SetDateTime(object obj)
        {
            DateTimeChanged.Invoke(dt,EventArgs.Empty);
            Cancel(null);
        }
        public DateTime Date 
        {
            get => dt.Date; 
            set 
            { 
                if(dt.Date != value) 
                    dt = value.Add(dt.TimeOfDay);
            }
        }
        public TimeSpan Time
        {
            get => dt.TimeOfDay;
            set
            {
                if (dt.TimeOfDay != value)
                    dt = dt.Date.Add(value);
            }
        }
    }
}
