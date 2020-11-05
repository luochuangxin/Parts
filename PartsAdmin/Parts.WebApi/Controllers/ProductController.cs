using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Helpers.WebHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Parts.Core.Bll;
using Parts.Model.Inputs.ProductInput;
using Parts.Model.Output;
using Parts.Model.Output.ProductOutput;
using Parts.Model.SqlServer;

namespace Parts.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly DataContext _context;
        private readonly ProductBll _productBll;
        public ProductController(ILogger<ProductController> logger, DataContext context)
        {
            _logger = logger;
            _productBll = new ProductBll(context);
        }
        /// <summary>
        /// 添加产品
        /// </summary>
        /// <returns></returns>
        [HttpPost("add")]
        public async Task<ActionResult<MyResult<int>>> AddProduct(AddProductInput input)
        {
            var ret= await _productBll.AddProduct(input);
            if (ret > 0)
            {
                return ActionResultFactory.Return200(ret);
            }
            else
            {
                return ActionResultFactory.Return400();
            }
            
        }
        /// <summary>
        /// 删除产品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("remove/{id}")]
        public async Task RemoveProduct(int id)
        {
            await _productBll.RemoveProduct(id);
        }
        //[HttpPost("remove/many")]
        //public async Task<ActionResult<MyResult<DelProductOutput>>> RemoveProducts()
        //{

        //}

        /// <summary>
        /// 修改产品信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("update")]
       public async Task<ActionResult<MyResult<bool>>> UpdateProduct(UpdateProductInput input)
        {
           var output= await _productBll.UpdateProduct(input);
            return ActionResultFactory.Return200(output);
        }

        /// <summary>
        /// 查询产品记录
        /// </summary>
        /// <returns></returns>
        [HttpPost("records")]
        public async Task<ActionResult<MyResult<GetProductOutput>>> GetValue(GetProductInput input)
        {
           var output= await _productBll.GetProduct(input);
            return ActionResultFactory.Return200(new GetProductOutput()
            {
                page = input.page,
                size = input.size,
                records = output.Item2,
                totalNum = output.Item1
            });
        }

    }
}
