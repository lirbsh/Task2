using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Models;

namespace Task2.ModelsLogic
{
    public class Product : ProductModel
    {
        public override string ValidDateFormated => ValidDate.ToString("dd/MM/yyyy HH:mm");
    }
}
