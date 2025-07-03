﻿using PolimericosInventoryAPI.DTOs;

namespace PolimericosInventoryAPI.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetAllAsync();
        Task<CategoryDTO?> GetByIdAsync(int id);
        Task<CategoryDTO> CreateAsync(CategoryCreateDTO dto);
        Task<bool> UpdateAsync(int id, CategoryCreateDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
