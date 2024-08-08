using Microsoft.EntityFrameworkCore;
using ORM_crud.Models;

namespace ORM_crud.Contexts
{
    internal class AppDbContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=ORM_DB;User Id=sa;Password=!Dquery20@3;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
