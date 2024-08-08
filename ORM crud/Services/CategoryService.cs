using Microsoft.EntityFrameworkCore;
using ORM_crud.Contexts;
using ORM_crud.Exceptions;
using ORM_crud.Models;

namespace ORM_crud.Services
{
    internal class CategoryService
    {
        public async Task CreateAsync(Category category)
        {
            AppDbContext context= new AppDbContext();
            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();

        }

        public async Task<List<Category>> GetAllAsync()
        {
            AppDbContext context= new AppDbContext();
            var categories= await context.Categories.AsNoTracking().ToListAsync();
            return categories;

        }
        public async Task<Category> GetByIdAsync(int id)
        {
            AppDbContext context= new AppDbContext();
            var category = await context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if(category == null)
                throw new NotFoundException($"Cant find Product with id:{id}");

            return category;
        }

        public async Task UpdateAsync(Category category)
        {
            AppDbContext context= new AppDbContext();
            context.Categories.Update(category);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            AppDbContext context= new AppDbContext();
            var category =await context.Categories.FirstOrDefaultAsync(c=>c.Id == id);
            if (category == null)
                throw new NotFoundException($"Cant find Product with id:{id}");
            context.Remove(category);
            await context.SaveChangesAsync();
        }
    }
}
