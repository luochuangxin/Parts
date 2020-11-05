using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Parts.Model.Inputs
{
    /// <summary>
    /// 分页基础类
    /// </summary>
    public class PageInputBase
    {
        /// <summary>
        /// 页数
        /// </summary>
        [Range(1, int.MaxValue)]
        public int page { get; set; } = 1;
        /// <summary>
        /// 每页大小
        /// </summary>
        [Range(1, 100)]
        public int size { get; set; } = 100;
        [JsonIgnore]
        public int skip => size * (page - 1);
        /// <summary>
        /// 排序条件,updateTime,createTime
        /// </summary>
        public string orderByCondition { get; set; }
        /// <summary>
        /// 升序 ASC 还是降序 DESC
        /// </summary>
        public string orderByType { get; set; }
    }
}
