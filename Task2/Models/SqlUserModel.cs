using SQLite;
using Task2.ModelsLogic;

namespace Task2.Models
{
    [Table("Users")]
    public abstract class SqlUserModel
    {
        protected readonly SqlData sqd;
        
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public  DateTime BirthDate { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public abstract void SaveToDatabase(User user);
        public SqlUserModel()
        {
            sqd = new ();
        }

    }
}
