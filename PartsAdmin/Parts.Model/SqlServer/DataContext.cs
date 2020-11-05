using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parts.Model.SqlServer
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> option) : base(option)
        {

        }
        public DbSet<Product> products { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<CustomerBuy> customerBuys { get; set; }
        public DbSet<BillRecord> billRecords { get; set; }
        public DbSet<OrderRecord> orderRecords { get; set; }
    }
}
