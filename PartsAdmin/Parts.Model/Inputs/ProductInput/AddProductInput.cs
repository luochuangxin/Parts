using System;
using System.Collections.Generic;
using System.Text;

namespace Parts.Model.Inputs.ProductInput
{
    public class AddProductInput
    {
        /// <summary>
        /// 商品编号
        /// </summary>
        public string ProNumber { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string proName { get; set; }
        /// <summary>
        /// 入库数
        /// </summary>
        public int StockNumber { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string Unit { get; set; }
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
