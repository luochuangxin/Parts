﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Parts.Model.Inputs.CustomerInput
{
    public class UpdateCustomerInput
    {
        /// <summary>
        /// 客户ID
        /// </summary>
        public int CustomerId { get; set; }
        /// <summary>
        /// 客户地址
        /// </summary>
        public string CustomerAddress { get; set; }
        /// <summary>
        /// 客户电话
        /// </summary>
        public string CustomerPhone { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
