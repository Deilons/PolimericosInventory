using PolimericosInventoryAPI.DTOs;

namespace PolimericosInventoryAPI.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAllAsync();
        Task<ProductDTO?> GetByIdAsync(int id);
        Task<ProductDTO> CreateAsync(ProductCreateDTO dto);
        Task<bool> UpdateAsync(int id, ProductCreateDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
