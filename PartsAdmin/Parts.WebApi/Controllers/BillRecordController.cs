using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Helpers.WebHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parts.Core.Bll;
using Parts.Model.Inputs.BillInput;
using Parts.Model.Output.BillOutput;
using Parts.Model.SqlServer;

namespace Parts.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillRecordController : ControllerBase
    {
        private readonly DataContext _context;
        private BillRecordBll _billRecordBll;
        public BillRecordController(DataContext context)
        {
            this._context = context;
            _billRecordBll = new BillRecordBll(context);
        }
        /// <summary>
        /// 添加账单
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("add")]
        public async Task<ActionResult<MyResult<string>>> AddBillRecord(AddBillInput input)
        {
            var output = await _billRecordBll.AddBillRecord(input);
            return ActionResultFactory.Return200(output);
        }
        /// <summary>
        /// 查询客户账号记录
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("list")]
        public async Task<ActionResult<MyResult<GetBillOutput>>> GetBillRecord(GetBillInput input)
        {
            var output = await _billRecordBll.GetBillRecord(input);
            return ActionResultFactory.Return200(new GetBillOutput()
            {
                page = input.page,
                size = input.size,
                records = output.Item2,
                totalNum = output.Item1
            });
        }
    }
}
