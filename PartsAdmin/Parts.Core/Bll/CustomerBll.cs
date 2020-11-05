using Microsoft.EntityFrameworkCore;
using Parts.Model.Inputs.CustomerInput;
using Parts.Model.Output.CustomerOutput;
using Parts.Model.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parts.Core.Bll
{
    public class CustomerBll
    {
        public DataContext _context;
        public CustomerBll(DataContext context)
        {
            this._context = context;
        }
        /// <summary>
        /// 添加客户
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<string> AddCustomer(AddCustomerInput input)
        {
            var customer = await _context.customers.FirstOrDefaultAsync(x => x.CustomerName == input.CustomerName);
            if (customer != null)
            {
                return "该客户已存在！";
            }
            customer = new Customer()
            {
                CustomerName = input.CustomerName,
                CustomerAddress = input.CustomerAddress,
                CustomerPhone = input.CustomerPhone,
                Email = input.Email,
                Remark = input.Remark,
                CreateTime = DateTime.Now
            };
            _context.customers.Add(customer);
            var ret = await _context.SaveChangesAsync();
            return ret > 0 ? "添加客户成功" : "添加客户失败";
        }
        /// <summary>
        /// 删除客户
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task<string> DelCustomer(int customerId)
        {
            var customer = await _context.customers.FirstOrDefaultAsync(x => x.CustomerId == customerId);
            if (customer != null)
            {
                _context.customers.Remove(customer);
                var ret = await _context.SaveChangesAsync();
                return ret > 0 ? "删除成功" : "删除失败";
            }
            return "删除失败";
        }
        /// <summary>
        /// 修改客户信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<string> UpdateCustomer(UpdateCustomerInput input)
        {
            var customer = await _context.customers.FirstOrDefaultAsync(x => x.CustomerId == input.CustomerId);
            if (customer != null)
            {
                customer.CustomerPhone = input.CustomerPhone;
                customer.CustomerAddress = input.CustomerAddress;
                customer.Email = input.Email;
                customer.Remark = input.Remark;
                _context.customers.Update(customer);
                var ret = await _context.SaveChangesAsync();
                return ret > 0 ? "修改成功" : "修改失败";
            }
            return "修改失败";
        }
        /// <summary>
        /// 查询客户列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<(long,List<Customer>)> GetCustomerList(GetCustomerInput input)
        {
            var count = await _context.customers.AsQueryable()
                .Where(x => x.CustomerName.Contains(input.CustomerName))
                .CountAsync();
            var output = await _context.customers.AsQueryable()
                .Where(x => x.CustomerName.Contains(input.CustomerName))
                .OrderByDescending(x => x.CreateTime)
                .Skip(input.skip)
                .Take(input.size)
                .ToListAsync();
            return (count, output);
        }
    }
}
