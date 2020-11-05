using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Parts.Model.SqlServer
{
    [Table("customer")]
    public class Customer
    {
        /// <summary>
        /// 客户ID
        /// </summary>
        [Key]
        [Column("csr_id")]
        public int CustomerId { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        [Column("csr_name")]
        public string CustomerName { get; set; }
        /// <summary>
        /// 客户地址
        /// </summary>
        [Column("csr_address")]
        public string CustomerAddress { get; set; }
        /// <summary>
        /// 客户电话
        /// </summary>
        [Column("csr_phone")]
        public string CustomerPhone { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        [Column("email")]
        public string Email { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Column("remark")]
        public string Remark { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("create_time")]
        public DateTime CreateTime { get; set; }
    }
}
