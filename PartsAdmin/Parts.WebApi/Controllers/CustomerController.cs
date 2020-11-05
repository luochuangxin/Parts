using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Helpers.WebHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Parts.Core.Bll;
using Parts.Model.Inputs.CustomerInput;
using Parts.Model.Output.CustomerOutput;
using Parts.Model.SqlServer;

namespace Parts.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly DataContext _context;
        private readonly CustomerBll _customerBll;

        public CustomerController(ILogger<CustomerController> logger,DataContext context)
        {
            this._logger = logger;
            this._context = context;
            _customerBll = new CustomerBll(context);
        }
        /// <summary>
        /// 添加客户
        /// </summary>
        /// <returns></returns>
        [HttpPost("add")]
        public async Task<ActionResult<MyResult<string>>> AddCustomer(AddCustomerInput input)
        {
            var output = await _customerBll.AddCustomer(input);
            return ActionResultFactory.Return200(output);
        }
        /// <summary>
        /// 删除客户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("remove/{id}")]
        public async Task<ActionResult<MyResult<string>>> DelCustomer(int id)
        {
            var output = await _customerBll.DelCustomer(id);
            return ActionResultFactory.Return200(output);
        }
        /// <summary>
        /// 修改客户信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("update")]
        public async Task<ActionResult<MyResult<string>>> UpdateCustomer(UpdateCustomerInput input)
        {
            var output = await _customerBll.UpdateCustomer(input);
            return ActionResultFactory.Return200(output);
        }
        /// <summary>
        /// 客户列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("list")]
        public async Task<ActionResult<MyResult<GetCustomerOutput>>> GetCustomerList(GetCustomerInput input)
        {
            var output = await _customerBll.GetCustomerList(input);
            return ActionResultFactory.Return200(new GetCustomerOutput()
            {
                totalNum = output.Item1,
                records = output.Item2,
                page = input.page,
                size = input.size
            });
        }

    }
}
