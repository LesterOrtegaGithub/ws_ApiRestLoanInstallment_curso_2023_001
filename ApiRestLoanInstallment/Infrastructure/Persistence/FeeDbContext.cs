using ApiRestLoanInstallment.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiRestLoanInstallment.Infrastructure.Persistence
{
    public class FeeDbContext : DbContext
    {
        public FeeDbContext(DbContextOptions options) : base(options) { }

        public DbSet<MonthlyFee> MonthlyFees { get; set; }
    }
}
