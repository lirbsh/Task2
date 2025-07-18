using Task2.Models;
using Task2.Utilities;

namespace Task2.ModelsLogic
{
    internal class User:UserModel
    {
        public override double Age
        {
            get
            {
                TimeSpan ts = DateTime.Today - BirthDate;
                double age = double.Round(ts.TotalDays / 365, 2, MidpointRounding.ToPositiveInfinity);
                age = age < 0 ? 0 : age;
                return age;
            }
        }
        public override bool IsValid => !hasUserNameError && !hasPwdError && !hasAgeError;
        public override bool HasUserNameError => hasUserNameError;
        public override bool HasPwdError => hasPwdError;
        public override bool HasAgeError => hasAgeError;
        public override string UserNameErrorMessage => userNameErrorMessage;
        public override string PwdErrorMessage => pwdErrorMessage;
        public override string LoginResult => loginResult;

        public override string UserName 
        { 
            get => userName; 
            set
            {
                bool beginWithDigit = true, containSpace = true, empty = string.IsNullOrWhiteSpace(value);
                if (!empty)
                {
                    beginWithDigit = int.TryParse(value[..1], out _);
                    containSpace = value.Contains(' ');
                }
                hasUserNameError = beginWithDigit || containSpace || empty;
                if (empty)
                    userNameErrorMessage = Strings.UserNameErr;
                else if (beginWithDigit)
                    userNameErrorMessage = Strings.UserNameErr1;
                else
                    userNameErrorMessage = Strings.UserNameErr2;
                loginResult = string.Empty;
                userName = value;
            }
        }

        public override string Password 
        { 
            get => password; 
            set 
            {
                bool hasDigit = false, hasCapital = false, empty = string.IsNullOrWhiteSpace(value);
                if (!empty)
                {
                    hasDigit = value.Any(char.IsDigit);
                    hasCapital = value.Any(char.IsUpper);
                }

                hasPwdError = !hasDigit || !hasCapital || empty;
                if (empty)
                    pwdErrorMessage = Strings.PwdErr;
                else if (!hasCapital)
                    pwdErrorMessage = Strings.PwdErr1;
                else
                    pwdErrorMessage = Strings.PwdErr2;
                loginResult = string.Empty;
                password = value;
            } 
        }
        public override DateTime BirthDate 
        { 
            get => birthDate; 
            set
            {
                birthDate = value;
                hasAgeError = Age < 18;
                loginResult = string.Empty;
            } 
        }

        public override bool Login()
        {
            bool result = userName == SavedUserName && password == SavedPassword;
            loginResult = result ? "Loged in" : "Faield to login";
            return result;
        }

        public override void Register()
        {
            Preferences.Set(Strings.NameKey, Name);
            Preferences.Set(Strings.UserNameKey, userName);
            Preferences.Set(Strings.BirthDateKey, birthDate);
            Preferences.Set(Strings.PwdKey, password);
            Preferences.Set(Strings.EmailKey, Email);
            Preferences.Set(Strings.RegisteredKey, true);
            IsRegistered = true;
        }

        public User()
        {
            Name = Preferences.Get(Strings.NameKey, string.Empty);
            SavedUserName = Preferences.Get(Strings.UserNameKey, string.Empty);
            BirthDate = Preferences.Get(Strings.BirthDateKey, DateTime.Now);
            SavedPassword = Preferences.Get(Strings.PwdKey, string.Empty);
            Email = Preferences.Get(Strings.EmailKey, string.Empty);
            IsRegistered = Preferences.Get(Strings.RegisteredKey, false);
        }
    }
}
