using System;
using System.Collections.Generic;
using System.Text;

namespace Parts.Model.Inputs.CustomerBuyInput
{
    public class GetOrderRecordInput:PageInputBase
    {
        public int CustomerId { get; set; }
    }
}
