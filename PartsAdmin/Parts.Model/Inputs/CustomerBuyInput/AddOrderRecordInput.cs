using System;
using System.Collections.Generic;
using System.Text;

namespace Parts.Model.Inputs.CustomerBuyInput
{
    public class AddOrderRecordInput
    {
        public int CustomerId { get; set; }
        public string OrderDetail { get; set; }
        public int NumberTotal { get; set; }
        public double AmountTotal { get; set; }
    }
}
