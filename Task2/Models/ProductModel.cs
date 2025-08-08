using SQLite;

namespace Task2.Models
{
    [Table("Products")]
    public abstract class ProductModel
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime ValidDate { get; set; }
        public double Price {  get; set; }
        [Ignore]
        public abstract string ValidDateFormated { get; }
        public ProductModel() 
        { 
            ValidDate = DateTime.Now;
        }
    }
}
