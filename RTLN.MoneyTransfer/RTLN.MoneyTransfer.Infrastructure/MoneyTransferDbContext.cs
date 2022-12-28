using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RTLN.MoneyTransfer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTLN.MoneyTransfer.Infrastructure
{
    public class MoneyTransferDbContext : DbContext
    {
        private readonly IConfiguration Configuration;
        public DbSet<User> Users { get; set; }

        public MoneyTransferDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
