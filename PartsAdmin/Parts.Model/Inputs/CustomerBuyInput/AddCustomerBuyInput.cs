using System;
using System.Collections.Generic;
using System.Text;

namespace Parts.Model.Inputs.CustomerBuyInput
{
    public class AddCustomerBuyInput
    {
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public string ProductNumber { get; set; }
        public string ProductName { get; set; }
        public string Unit { get; set; }
        public double Price { get; set; }
        public int Number { get; set; }
    }
}
