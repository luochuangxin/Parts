using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Parts.Model.SqlServer
{
    [Table("customer_buy")]
    public class CustomerBuy
    {
        /// <summary>
        /// 主键id
        /// </summary>
        [Key]
        [Column("id")]
        public int Id { get; set; }
        /// <summary>
        /// 产品ID
        /// </summary>
        [Column("pro_id")]
        public int ProductId { get; set; }
        /// <summary>
        /// 客户ID
        /// </summary>
        [Column("csr_id")]
        public int CustomerId { get; set; }
        /// <summary>
        /// 商品编号
        /// </summary>
        [Column("pro_number")]
        public string ProductNumber { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        [Column("pro_name")]
        public string ProductName { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        [Column("unit")]
        public string Unit { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        [Column("price")]
        public double Price { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        [Column("number")]
        public int Number { get; set; }
        /// <summary>
        /// 是否已出单
        /// 1 待出单
        /// 0 已出单
        /// </summary>
        [Column("is_create_order")]
        public int IsCreateOrder { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("create_time")]
        public DateTime CreateTime { get; set; }
    }
}
