using Microsoft.EntityFrameworkCore;

namespace tenthMVP.Models {

    public class MyContext : DbContext 
    {
        public MyContext (DbContextOptions options) : base (options) { }

        public DbSet<Dish> Dishes { get; set; }
        
    }
}