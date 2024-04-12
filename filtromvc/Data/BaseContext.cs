
using Microsoft.EntityFrameworkCore;
using filtromvc.Models;


namespace filtromvc.Data{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
       
        {
        }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Employee> Employees { get; set; }
        
        
    }
    
}
