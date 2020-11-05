using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Parts.Model.SqlServer
{
    [Table("bill_record")]
    public class BillRecord
    {
        /// <summary>
        /// 自增ID
        /// </summary>
        [Column("id")]
        public int Id { get; set; }
        /// <summary>
        /// 开单ID
        /// </summary>
        [Column("admin_id")]
        public int AdminId { get; set; }
        /// <summary>
        /// 客户ID
        /// </summary>
        [Column("csr_id")]
        public int CustomerId { get; set; }
        /// <summary>
        /// 还款金额
        /// </summary>
        [Column("repayment_amount")]
        public double RepaymentAmount { get; set; }
        /// <summary>
        /// 欠款金额
        /// </summary>
        [Column("arrears_amount")]
        public double ArrearsAmount { get; set; }
        /// <summary>
        /// 欠款总金额
        /// </summary>
        [Column("arrears_total_amount")]
        public double ArrearsTotalTmount { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("create_time")]
        public DateTime CreateTime { get; set; }
    }
}
