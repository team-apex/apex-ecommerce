using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace ApexBikeStore.Models
{
    public class Product
    {
        public ObservableCollection<Product> Items { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public Product() { }

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            //return base.ToString();
            return String.Format("{0} ({1})", Name, Price);
        }
    }
}