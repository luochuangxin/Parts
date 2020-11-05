using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Helpers.WebHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parts.Core.Bll;
using Parts.Model.Inputs.CustomerBuyInput;
using Parts.Model.Output.CustomerBuyOutput;
using Parts.Model.SqlServer;

namespace Parts.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class CustomerBuyController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly CustomerBuyBll _customerBuyBll;
       
        public CustomerBuyController(DataContext context)
        {
            this._context = context;
            _customerBuyBll = new CustomerBuyBll(context);
        }
        /// <summary>
        /// 添加客户购买单
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("add")]
        public async Task<ActionResult<MyResult<string>>> AddCustomerBuy(AddCustomerBuyInput input)
        {
            var output = await _customerBuyBll.AddCustomerBuy(input);
            return ActionResultFactory.Return200(output);
        }
        /// <summary>
        /// 删除客户购买单
        /// </summary>
        /// <returns></returns>
        [HttpPost("remove/{id}")]
        public async Task<ActionResult<MyResult<string>>> DelCustomerBuy(int id)
        {
            var output = await _customerBuyBll.DelCustomerBuy(id);
            return ActionResultFactory.Return200(output);
        }
        /// <summary>
        /// 修改客户购买单
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("update")]
        public async Task<ActionResult<MyResult<string>>> UpdateCustomerBuy(UpdateCustomerBuyInput input)
        {
            var output = await _customerBuyBll.UpdateCustomerBuy(input);
            return ActionResultFactory.Return200(output);
        }
        /// <summary>
        /// 查询客户购买单
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("list")]
        public async Task<ActionResult<MyResult<GetCustomerBuyOutput>>> GetCustomerBuyList(GetCustomerBuyInput input)
        {
            var output = await _customerBuyBll.GetCustomerBuyList(input);
            return ActionResultFactory.Return200(new GetCustomerBuyOutput()
            {
                page = input.page,
                size = input.size,
                records = output.Item2,
                totalNum = output.Item1
            });
        }
        /// <summary>
        /// 添加出库单详情
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("order/detail/add")]
        public async Task<ActionResult<MyResult<string>>> AddOrderDetailRecord(AddOrderRecordInput input)
        {
            var output = await _customerBuyBll.AddOrderDetailRecord(input);
            return ActionResultFactory.Return200(output);
        }

        /// <summary>
        /// 删除出库单详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("order/detail/remove/{id}")]
        public async Task<ActionResult<MyResult<string>>> DelOrderDetailRecord(int id)
        {
            var output = await _customerBuyBll.DelOrderDetailRecord(id);
            return ActionResultFactory.Return200(output);
        }

        /// <summary>
        /// 查询出库单详情
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("order/detail/list")]
        public async Task<ActionResult<MyResult<GetOrderRecordOutput>>> GetOrderDetailRecord(GetOrderRecordInput input)
        {
            var output = await _customerBuyBll.GetOrderDetailRecord(input);
            return ActionResultFactory.Return200(new GetOrderRecordOutput()
            {
                page = input.page,
                size = input.size,
                records = output.Item2,
                totalNum = output.Item1
            });
        }

    }
}
