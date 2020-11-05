using Microsoft.EntityFrameworkCore;
using Parts.Model.Inputs.ProductInput;
using Parts.Model.Output;
using Parts.Model.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parts.Core.Bll
{
    public class ProductBll
    {
        private DataContext _context;

        public ProductBll(DataContext context)
        {
            this._context = context;
        }
        /// <summary>
        /// 添加产品
        /// </summary>
        /// <returns></returns>
        public async Task<int> AddProduct(AddProductInput input)
        {
            Product product = new Product
            {
                ProNumber = input.ProNumber,
                ProName = input.proName,
                Unit = input.Unit,
                StockNumber = input.StockNumber,
                SellPrice = input.SellPrice,
                CostPrice = input.CostPrice,
                UpdateTime = DateTime.Now
            };
            _context.products.Add(product);
            var output = await _context.SaveChangesAsync();
            return output;
        }
        /// <summary>
        /// 删除单个产品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task RemoveProduct(int id)
        {
            var product = await _context.products.FirstOrDefaultAsync(x => x.Id == id);
            if (product != null)
            {
                _context.products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
        /// <summary>
        /// 修改产品
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<bool> UpdateProduct(UpdateProductInput input)
        {
            var product = await _context.products.FirstOrDefaultAsync(x => x.Id == input.ProId);
            if (product != null)
            {
                product.StockNumber = input.StockNumber;
                product.CostPrice = input.CostPrice;
                product.SellPrice = input.SellPrice;
                product.UpdateTime = DateTime.Now;
                _context.products.Update(product);
                var output= await _context.SaveChangesAsync();
                return output > 0;
            }
            return false;
        }

        /// <summary>
        /// 查询产品
        /// </summary>
        /// <returns></returns>
        public async Task<(long,List<Product>)> GetProduct(GetProductInput input)
        {
            var count = await _context.products.AsQueryable()
                .Where(x => x.ProNumber.Contains(input.ProNumber) && x.ProName.Contains(input.ProName))
                .CountAsync();
            var output = await _context.products.AsQueryable()
                 .Where(x => x.ProNumber.Contains(input.ProNumber) && x.ProName.Contains(input.ProName))
                 .OrderByDescending(x => x.UpdateTime)
                 .Skip(input.skip)
                 .Take(input.size)
                 .ToListAsync();
            return (count, output);
        }

    }
}
