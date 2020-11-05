using Microsoft.EntityFrameworkCore;
using Parts.Model.Inputs.CustomerBuyInput;
using Parts.Model.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parts.Core.Bll
{
    public class CustomerBuyBll
    {
        private DataContext _context;

        public CustomerBuyBll(DataContext context)
        {
            this._context = context;
        }
        /// <summary>
        /// 添加客户购买单
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<string> AddCustomerBuy(AddCustomerBuyInput input)
        {
            CustomerBuy customerBuy = await _context.customerBuys.FirstOrDefaultAsync(m => m.ProductId == input.ProductId && m.IsCreateOrder == 1);
            if (customerBuy == null)
            {
                customerBuy = new CustomerBuy()
                {
                    ProductId = input.ProductId,
                    CustomerId = input.CustomerId,
                    ProductNumber = input.ProductNumber,
                    ProductName = input.ProductName,
                    Unit = input.Unit,
                    Price = input.Price,
                    Number = input.Number,
                    IsCreateOrder = 1,
                    CreateTime = DateTime.Now
                };
                _context.customerBuys.Add(customerBuy);
                var ret = await _context.SaveChangesAsync();
                return ret > 0 ? "添加成功" : "添加失败";
            }
            else
            {
                //累增出库数
            }
            return "添加失败";
        }
        /// <summary>
        /// 删除客户购买单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<string> DelCustomerBuy(int id)
        {
            var customerBuy = await _context.customerBuys.FirstOrDefaultAsync(m => m.Id == id);
            if (customerBuy != null)
            {
                _context.customerBuys.Remove(customerBuy);
                var ret = await _context.SaveChangesAsync();
                return ret > 0 ? "删除成功" : "删除失败";
            }
            return "删除失败";
        }
        /// <summary>
        /// 修改客户购买单
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<string> UpdateCustomerBuy(UpdateCustomerBuyInput input)
        {
            var customerBuy = await _context.customerBuys.FirstOrDefaultAsync(m => m.Id == input.CustomerBuyId);
            if (customerBuy != null)
            {
                customerBuy.Price = input.Price;
                customerBuy.Number = input.Number;
                _context.customerBuys.Update(customerBuy);
                var ret = await _context.SaveChangesAsync();
                return ret > 0 ? "修改成功" : "修改失败";
            }
            return "修改失败";
        }
        /// <summary>
        /// 查询客户购买单
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<(long, List<CustomerBuy>)> GetCustomerBuyList(GetCustomerBuyInput input)
        {
            var query = _context.customerBuys.AsQueryable();
            if (input.CustomerId > 0)
            {
                query = query.Where(m => m.CustomerId == input.CustomerId);
            }
            var count = await query.CountAsync();
            var output = await query
                .OrderByDescending(m => m.CreateTime)
                .Skip(input.skip)
                .Take(input.size)
                .ToListAsync();
            return (count, output);
        }

        #region 出库单详情
        /// <summary>
        /// 添加出库单详情
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<string> AddOrderDetailRecord(AddOrderRecordInput input)
        {
            OrderRecord orderRecord = new OrderRecord()
            {
                CustomerId = input.CustomerId,
                OrderDetail = input.OrderDetail,
                NumberTotal = input.NumberTotal,
                AmountTotal = input.AmountTotal,
                CreateTime=DateTime.Now
            };
            _context.orderRecords.Add(orderRecord);
            var ret = await _context.SaveChangesAsync();
            return ret > 0 ? "添加成功" : "添加失败";
        }
        /// <summary>
        /// 删除出库单详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<string> DelOrderDetailRecord(int id)
        {
            var order = await _context.orderRecords.FirstOrDefaultAsync(x => x.Id == id);
            if (order != null)
            {
                _context.orderRecords.Remove(order);
                var ret = await _context.SaveChangesAsync();
                return ret > 0 ? "删除成功" : "删除失败";
            }
            return "删除失败";
        }
        /// <summary>
        /// 查询出库单详情
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<(long, List<OrderRecord>)> GetOrderDetailRecord(GetOrderRecordInput input)
        {
            var query = _context.orderRecords.AsQueryable();
            if (input.CustomerId > 0)
            {
                query = query.Where(m => m.CustomerId == input.CustomerId);
            }
            var count = await query.CountAsync();
            var output = await query
                .OrderByDescending(x => x.CreateTime)
                .Skip(input.skip)
                .Take(input.size)
                .ToListAsync();
            return (count, output);
        }

        #endregion
    }
}
