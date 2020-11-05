using System;
using System.Collections.Generic;
using System.Text;

namespace Parts.Model.Inputs.ProductInput
{
    public class GetProductInput: PageInputBase
    {
        /// <summary>
        /// 商品编号
        /// </summary>
        public string ProNumber { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string ProName { get; set; }
    }
}
