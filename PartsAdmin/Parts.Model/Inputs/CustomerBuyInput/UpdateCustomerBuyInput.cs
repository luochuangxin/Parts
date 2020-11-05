using System;
using System.Collections.Generic;
using System.Text;

namespace Parts.Model.Inputs.CustomerBuyInput
{
    public class UpdateCustomerBuyInput
    {
        public int CustomerBuyId { get; set; }
        public double Price { get; set; }
        public int Number { get; set; }
    }
}
