using Microsoft.EntityFrameworkCore;
using PolimericosInventoryAPI.Data;
using PolimericosInventoryAPI.DTOs;
using PolimericosInventoryAPI.Interfaces;
using PolimericosInventoryAPI.Models;

namespace PolimericosInventoryAPI.Services
{
    public class ProductService : IProductService

    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        // Creates a new product based on the provided DTO
        public async Task<ProductDTO> CreateAsync(ProductCreateDTO dto)
        {
            if (!Enum.TryParse<ProductType>(dto.ProductType, out var productType))
                throw new ArgumentException("Invalid product type");

            var product = new Product
                {
                Name = dto.Name,
                ProductType = productType,
                Unit = dto.Unit,
                QuantityInStock = dto.QuantityInStock,
                MinimumStock = dto.MinimumStock,
                UnitPrice = dto.UnitPrice,
                CategoryId = dto.CategoryId,
                CreatedAt = DateTime.UtcNow
            };
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return await GetByIdAsync(product.Id) ?? throw new InvalidOperationException("Product creation failed");
        }

        // Deletes a product by its ID
        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        // Retrieves all products and includes the category information
        public async Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            var products = await _context.Products
                .Include(p => p.Category)
                .ToListAsync();

            return products.Select(p => new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                ProductType = p.ProductType.ToString(),
                Unit = p.Unit,
                QuantityInStock = p.QuantityInStock,
                MinimumStock = p.MinimumStock,
                UnitPrice = p.UnitPrice,
                CreatedAt = p.CreatedAt,
                CategoryName = p.Category?.Name
            });
        }

        // Retrieves a product by its ID and includes the category information
        public async Task<ProductDTO?> GetByIdAsync(int id)
        {
            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) return null;

            return new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                ProductType = product.ProductType.ToString(),
                Unit = product.Unit,
                QuantityInStock = product.QuantityInStock,
                MinimumStock = product.MinimumStock,
                UnitPrice = product.UnitPrice,
                CreatedAt = product.CreatedAt,
                CategoryName = product.Category?.Name
            };
        }

        // Updates an existing product by its ID
        public async Task<bool> UpdateAsync(int id, ProductCreateDTO dto)
        {
            var product = _context.Products.Find(id);
            if (product == null) return false;

            if(!Enum.TryParse<ProductType>(dto.ProductType, out var productType))
                throw new ArgumentException("Invalid product type");

            product.Name = dto.Name;
            product.ProductType = productType;
            product.Unit = dto.Unit;
            product.QuantityInStock = dto.QuantityInStock;
            product.MinimumStock = dto.MinimumStock;
            product.UnitPrice = dto.UnitPrice;
            product.CategoryId = dto.CategoryId;
            product.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;

        }
    }
}
