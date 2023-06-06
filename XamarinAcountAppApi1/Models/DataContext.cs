using Microsoft.EntityFrameworkCore;

namespace XamarinAcountAppApi1.Models
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options)
            : base(options) 
        {
            
        
        }

        public DbSet<Account> Accounts { get; set; }


    }
}
