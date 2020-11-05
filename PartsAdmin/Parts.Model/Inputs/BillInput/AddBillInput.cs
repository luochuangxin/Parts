using Parts.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parts.Model.Inputs.BillInput
{
    public class AddBillInput
    {
        public int AdminId { get; set; }
        public int CustomerId { get; set; }
        public BillEnum billType { get; set; }
        public double Amount { get; set; }
    }
}
