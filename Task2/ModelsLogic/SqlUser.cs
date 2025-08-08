using System.Collections.ObjectModel;
using Task2.Models;

namespace Task2.ModelsLogic
{
    public class SqlUser : SqlUserModel
    {
        public override void SaveToDatabase(User user)
        {
            ObservableCollection<SqlUser> users = sqd.GetUsers();
            SqlUser? savedUser;
            if (users.Count > 0)
            {
                savedUser = users[0];
                savedUser.Name = user.Name;
                savedUser.BirthDate = user.BirthDate;
                savedUser.UserName = user.UserName;
                savedUser.Email = user.Email;
                savedUser.Password = user.Password;
                sqd.Update(savedUser);
            }
            else
            {
                Name = user.Name;
                BirthDate = user.BirthDate;
                UserName = user.UserName;
                Email = user.Email;
                Password = user.Password;
                sqd.Insert(this);
            }
        }
    }
}
