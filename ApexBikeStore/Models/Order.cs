using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApexBikeStore.Models
{
    public class Order
    {
        public double Price { get; set; }
        public int Quantity { get; set; }

        public double LowDeliveryRate(double price)
        {
            return price*1.05;
        }

        public double HighDeliveryRate(double price)
        {
            return price*1.1;
        }
        
    }
}