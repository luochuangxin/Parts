using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Parts.Model.SqlServer
{
    [Table("order_record")]
    public class OrderRecord
    {
        /// <summary>
        /// 自增ID
        /// </summary>
        [Column("id")]
        public int Id { get; set; }
        /// <summary>
        /// 客户ID
        /// </summary>
        [Column("csr_id")]
        public int CustomerId { get; set; }
        /// <summary>
        /// 订单详情
        /// </summary>
        [Column("order_detail")]
        public string OrderDetail { get; set; }
        /// <summary>
        /// 总数
        /// </summary>
        [Column("number_total")]
        public int NumberTotal { get; set; }
        /// <summary>
        /// 总金额
        /// </summary>
        [Column("amount_total")]
        public double AmountTotal { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("create_time")]
        public DateTime CreateTime { get; set; }
    }
}
