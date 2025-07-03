using PolimericosInventoryAPI.DTOs;

namespace PolimericosInventoryAPI.Interfaces
{
    public interface IInventoryMovementService
    {
        Task<IEnumerable<InventoryMovementDTO>> GetAllAsync();
        Task<InventoryMovementDTO?> GetByIdAsync(int id);
        Task<InventoryMovementDTO> CreateAsync(InventoryMovementCreateDTO dto);
    }
}
