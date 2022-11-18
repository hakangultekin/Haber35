using Haber35.BLL.DTOs;
using Haber35.CORE.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber35.BLL.Abstracts
{
    public interface ICategoryService
    {
        Task<bool> CreateAsync(CategoryCreateDTO categoryCreateDTO);
        Task<List<CategoryDTO>> GetAllAsync();
        Task<List<CategoryDTO>> GetAllPassivesAsync();
        Task<CategoryDTO> GetByIdAsync(Guid id);
        Task<bool> UpdateAsync(CategoryUpdateDTO categoryUpdateDTO);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> ActiveCategoryAsync(Guid id);
    }
}
