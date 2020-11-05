using Microsoft.EntityFrameworkCore;
using Parts.Model.Enums;
using Parts.Model.Inputs.BillInput;
using Parts.Model.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Parts.Core.Bll
{
    public class BillRecordBll
    {
        private DataContext _context;

        public BillRecordBll(DataContext context)
        {
            this._context = context;
        }
        /// <summary>
        ///添加账号
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<string> AddBillRecord(AddBillInput input)
        {
            BillRecord bill;
            var item = await _context.billRecords.FirstOrDefaultAsync(m => m.CustomerId == input.CustomerId);
            double repaymentAmount = 0;//还款
            double arrearsAmount = 0;//欠款
            double arrearsAmountTotal = item?.ArrearsTotalTmount ?? 0;
            switch (input.billType)
            {
                case BillEnum.欠款:
                    arrearsAmount = input.Amount;
                    arrearsAmountTotal += input.Amount;
                    break;
                case BillEnum.还款:
                    repaymentAmount = input.Amount;
                    arrearsAmountTotal -= input.Amount;
                    break;
            }
            bill = new BillRecord()
            {
                AdminId = input.AdminId,
                CustomerId = input.CustomerId,
                RepaymentAmount = repaymentAmount,
                ArrearsAmount = arrearsAmount,
                ArrearsTotalTmount= arrearsAmountTotal,
                CreateTime = DateTime.Now
            };
            _context.billRecords.Add(bill);
            var ret = await _context.SaveChangesAsync();
            return ret > 0 ? "添加成功" : "添加失败";
        }
        /// <summary>
        /// 查询账单记录
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<(long,List<BillRecord>)> GetBillRecord(GetBillInput input)
        {

            var query = _context.billRecords.AsQueryable();
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
    }
}
