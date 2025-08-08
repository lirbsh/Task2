using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Models
{
    [Table("Orders")]
    public class Order
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
    }
}
