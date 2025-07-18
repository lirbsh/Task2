using Task2.Utilities;

namespace Task2.Models
{
    internal abstract class UserModel 
    {
        protected bool hasUserNameError = true, hasPwdError = true, hasAgeError = true;
        protected string userNameErrorMessage = Strings.UserNameErr, pwdErrorMessage = Strings.PwdErr,
            loginResult = string.Empty, userName = string.Empty, password = string.Empty;
        protected DateTime birthDate = DateTime.Now;
        public static string AgeErrorMessage { get => Strings.AgeErr; } //same for all users
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public  string SavedPassword { get; set; } = string.Empty;
        public  string SavedUserName { get; set; } = string.Empty;
        public bool IsRegistered { get; set; }
        public abstract DateTime BirthDate {  get; set; }
        public abstract string UserName { get; set; } 
        public abstract string Password { get; set; } 
        public abstract double Age { get; }
        public abstract bool IsValid { get; }
        public abstract bool HasUserNameError { get; }
        public abstract bool HasPwdError { get; }
        public abstract bool HasAgeError { get; }
        public abstract string UserNameErrorMessage { get; }
        public abstract string PwdErrorMessage { get; }
        public abstract string LoginResult { get; }
        public abstract bool Login();
        public abstract void Register();
    }
}
