using System.Windows.Input;
using Task2.Models;
using Task2.ModelsLogic;

namespace Task2.ViewModels
{
    public partial class UserPageVM : ObservableObject
    {
        private readonly User user = new();
        public ICommand SaveCommand { get; }
        public ICommand TakePictureCommand { get; }
        public ICommand UpdateFromContactCommand { get; }

        public UserPageVM()
        {
            user.PictureTaken += (s, e) => OnPropertyChanged(nameof(UserImage));
            user.NameUpdated += (s, e) => OnPropertyChanged(nameof(Name));
            SaveCommand = new Command(Save);
            TakePictureCommand = new Command(TakePicture);
            UpdateFromContactCommand = new Command(UpdateFromContact);
        }

        private void UpdateFromContact()
        {
            user.UpdateFromContact();
        }   

        private void TakePicture()
        {
            user.TakePicture();
        }
        private void Save()
        {
            user.Register();
        }

        public ImageSource? UserImage { get => user.UserImage; }
        public bool IsUserValid { get => user.IsValid; }
        public string UserNameErrorMessage { get => user.UserNameErrorMessage; }
        public bool HasUserNameError { get => user.HasUserNameError; }
        public string UserPwdErrorMessage { get => user.PwdErrorMessage; }
        public bool HasUserPwdError { get => user.HasPwdError; }
        public static string UserAgeErrorMessage { get => User.AgeErrorMessage; }
        public bool HasUserAgeError { get => user.HasAgeError; }
        public string Name { get => user.Name; set => user.Name = value; }
        public string Email { get => user.Email; set => user.Email = value; }
        public double Age { get => user.Age; }
        public string LoginResult { get => user.LoginResult; }
        public string UserName
        {
            get => user.UserName;
            set
            {
                if (user.UserName != value)
                {
                    user.UserName = value;
                    OnPropertyChanged(nameof(UserNameErrorMessage));
                    OnPropertyChanged(nameof(HasUserNameError));
                    OnPropertyChanged(nameof(IsUserValid));
                    OnPropertyChanged(nameof(LoginResult));
                }
            }
        }
        public string Password
        {
            get => user.Password;
            set
            {
                if (user.Password != value)
                {
                    user.Password = value;
                    OnPropertyChanged(nameof(UserPwdErrorMessage));
                    OnPropertyChanged(nameof(HasUserPwdError));
                    OnPropertyChanged(nameof(IsUserValid));
                    OnPropertyChanged(nameof(LoginResult));
                }
            }
        }

        public DateTime BirthDate
        {
            get { return user.BirthDate; }
            set
            {
                if (user.BirthDate != value)
                {
                    user.BirthDate = value;
                    OnPropertyChanged(nameof(Age));
                    OnPropertyChanged(nameof(HasUserAgeError));
                    OnPropertyChanged(nameof(IsUserValid));
                    OnPropertyChanged(nameof(LoginResult));
                }
            }
        }
        public bool IsNewUser
        {
            get => !user.IsRegistered;
        }

    }
}
