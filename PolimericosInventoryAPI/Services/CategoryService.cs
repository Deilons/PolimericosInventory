using Microsoft.EntityFrameworkCore;
using PolimericosInventoryAPI.Data;
using PolimericosInventoryAPI.DTOs;
using PolimericosInventoryAPI.Interfaces;
using PolimericosInventoryAPI.Models;


namespace PolimericosInventoryAPI.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;
        public CategoryService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<CategoryDTO> CreateAsync(CategoryCreateDTO dto)
        {
            var exists = await _context.Categories
                    .AnyAsync(c => c.Name.ToLower() == dto.Name.ToLower());

            if (exists)
                throw new ArgumentException("Category already exists");

            var category = new Category
            {
                Name = dto.Name   
            };

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null) return false;

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllAsync()
        {
            var categories = await _context.Categories.ToListAsync();
            return categories.Select(c => new CategoryDTO
            {
                Id = c.Id,
                Name = c.Name
            });

        }

        public async Task<CategoryDTO?> GetByIdAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) return null;
            return new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        public async Task<bool> UpdateAsync(int id, CategoryCreateDTO dto)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) return false;

            var exists = await _context.Categories.AnyAsync(c => c.Name == dto.Name && c.Id != id);
            if (exists)
                throw new ArgumentException("Category with this name already exists");
            
            category.Name = dto.Name;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
