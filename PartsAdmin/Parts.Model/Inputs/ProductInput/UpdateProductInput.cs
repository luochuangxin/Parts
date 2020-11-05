using System;
using System.Collections.Generic;
using System.Text;

namespace Parts.Model.Inputs.ProductInput
{
    public class UpdateProductInput
    {
        /// <summary>
        /// 产品ID
        /// </summary>
        public int ProId { get; set; }

        /// <summary>
        /// 入库数
        /// </summary>
        public int StockNumber { get; set; }
        /// <summary>
        /// 成本价
        /// </summary>
        public double CostPrice { get; set; }
        /// <summary>
        /// 销售价
        /// </summary>
        public double SellPrice { get; set; }
    }
}
