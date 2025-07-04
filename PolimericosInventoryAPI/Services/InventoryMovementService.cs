using Microsoft.EntityFrameworkCore;
using PolimericosInventoryAPI.Data;
using PolimericosInventoryAPI.DTOs;
using PolimericosInventoryAPI.Interfaces;
using PolimericosInventoryAPI.Models;

namespace PolimericosInventoryAPI.Services
{
    public class InventoryMovementService : IInventoryMovementService
    {
        private readonly AppDbContext _context;

        public InventoryMovementService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<InventoryMovementDTO>> GetAllAsync()
        {
            var movements = await _context.InventoryMovements
                .Include(m => m.Product)
                .OrderByDescending(m => m.Date)
                .ToListAsync();

            return movements.Select(m => new InventoryMovementDTO
            {
                Id = m.Id,
                ProductName = m.Product.Name,
                MovementType = m.MovementType.ToString(),
                Quantity = m.Quantity,
                Date = m.Date,
                Note = m.Note
            });
        }
        public async Task<InventoryMovementDTO?> GetByIdAsync(int id)
        {
            var movement = await _context.InventoryMovements
                .Include(m => m.Product)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (movement == null) return null;

            return new InventoryMovementDTO
            {
                Id = movement.Id,
                ProductName = movement.Product.Name,
                MovementType = movement.MovementType.ToString(),
                Quantity = movement.Quantity,
                Date = movement.Date,
                Note = movement.Note
            };
        }

        public async Task<InventoryMovementDTO> CreateAsync(InventoryMovementCreateDTO dto)
        {
            var product = await _context.Products.FindAsync(dto.ProductId);
            if (product == null)
                throw new ArgumentException("Product not found");

            if (!Enum.TryParse<MovementType>(dto.MovementType, out var movementType))
                throw new ArgumentException("Invalid movement type");

            if (movementType == MovementType.Entry)
                product.QuantityInStock += dto.Quantity;
            else if (movementType == MovementType.Exit)
            {
                if (product.QuantityInStock < dto.Quantity)
                    throw new InvalidOperationException("Not enough stock for this exit");

                product.QuantityInStock -= dto.Quantity;
            }

            var movement = new InventoryMovement
            {
                ProductId = dto.ProductId,
                MovementType = movementType,
                Quantity = dto.Quantity,
                Date = DateTime.UtcNow,
                Note = dto.Note
            };

            _context.InventoryMovements.Add(movement);
            await _context.SaveChangesAsync();

            return await GetByIdAsync(movement.Id)
                ?? throw new Exception("Movement created but could not be returned");
        }
    }
}
