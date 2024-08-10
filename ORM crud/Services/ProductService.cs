using Microsoft.EntityFrameworkCore;
using ORM_crud.Contexts;
using ORM_crud.Exceptions;
using ORM_crud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_crud.Services
{
    internal class ProductService
    {

        public async Task CreateAsync(Product student)
        {
            AppDbContext context = new AppDbContext();
            await context.Products.AddAsync(student);
            await context.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            AppDbContext context = new AppDbContext();
            var products= await context.Products.Include(p => p.Category).AsNoTracking().ToListAsync();

            return products;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            AppDbContext context = new AppDbContext();
            var product=await context.Products.Include(p=>p.Category).FirstOrDefaultAsync(p=>p.Id == id);
            if (product == null)
                throw new NotFoundException($"Cant find Product with id:{id}");
            
            return product;
        }

        public async Task UpdateAsync(Product product)
        {
            AppDbContext context = new AppDbContext();
            context.Products.Update(product);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            AppDbContext context = new AppDbContext();
            var product= await context.Products.FirstOrDefaultAsync(p=>p.Id == id);
            if (product == null)
                throw new NotFoundException($"Cant find Product with id:{id}");

            context.Products.Remove(product);
            await context.SaveChangesAsync();
        }

    }
}
