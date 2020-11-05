using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parts.Model.Output
{
    public class PageOutputBase<T>
    {
        /// <summary>
        /// 总数
        /// </summary>
        public long? totalNum { get; set; }
        /// <summary>
        /// 当前页码
        /// </summary>
        public int? page { get; set; }
        /// <summary>
        /// 每页大小
        /// </summary>
        public int? size { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public IEnumerable<T> records { get; set; }
        /// <summary>
        /// 是否有下一页
        /// </summary>
        public bool? hasNextPage { get; set; }
        /// <summary>
        /// 是否最后一页
        /// </summary>
        public bool? isLastPage => size * (page - 1) + records?.Count() >= totalNum;
    }
}
