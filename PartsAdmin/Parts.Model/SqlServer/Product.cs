using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Parts.Model.SqlServer
{
    [Table("product")]
    public class Product
    {
        /// <summary>
        /// 产品ID
        /// </summary>
        [Key]
        [Column("pro_id")]
        public int Id { get; set; }
        /// <summary>
        /// 商品编号
        /// </summary>
        [Column("pro_number")]
        public string ProNumber { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        [Column("pro_name")]
        public string ProName { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        [Column("unit")]
        public string Unit { get; set; }
        /// <summary>
        /// 入库数
        /// </summary>
        [Column("stock_number")]
        public int StockNumber { get; set; }
        /// <summary>
        /// 成本价
        /// </summary>
        [Column("cost_price")]
        public double CostPrice { get; set; }
        /// <summary>
        /// 销售价
        /// </summary>
        [Column("sell_price")]
        public double SellPrice { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        [Column("update_time")]
        public DateTime UpdateTime { get; set; }
    }
}
