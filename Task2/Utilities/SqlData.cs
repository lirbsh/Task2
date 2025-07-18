using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.ModelsLogic;

namespace Task2.Utilities
{
    internal class SqlData
    {
        public static List<User> GetUsers()
        {
            // Simulate fetching users from a database
            return
            [
                new User { UserName = "john_doe", Password = "Password123", Name = "John Doe", Email = "j@b.com", BirthDate = new DateTime(1990, 1, 1), IsRegistered = true },
                new User { UserName = "jane_doe", Password = "Password456", Name = "Jane Doe", Email = "w@n.com", BirthDate = new DateTime(1992, 2, 2), IsRegistered = true }
            ];
        }
        public static void AddUser(User user)
        {
            // Simulate saving a user to a database
            // In a real application, this would involve database operations
            Console.WriteLine($"User {user.UserName} saved successfully.");
        }
        public static void DeleteUser(string userName)
        {
            // Simulate deleting a user from a database
            // In a real application, this would involve database operations
            Console.WriteLine($"User {userName} deleted successfully.");
        }
        public static void UpdateUser(User user)
        {
            // Simulate updating a user in the database
            // In a real application, this would involve database operations
            Console.WriteLine($"User {user.UserName} updated successfully.");
        }
        public static User GetUserByUserName(string userName)
        {
            // Simulate fetching a user by username from a database
            return new User { UserName = userName };
        }
        public static bool UserExists(string userName)
        {
            // Simulate checking if a user exists in the database
            return GetUsers().Any(u => u.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase));
        }
        
    }
}
