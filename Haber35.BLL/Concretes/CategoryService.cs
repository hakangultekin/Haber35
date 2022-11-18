using AutoMapper;
using Haber35.BLL.Abstracts;
using Haber35.BLL.DTOs;
using Haber35.CORE.Concretes;
using Haber35.CORE.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber35.BLL.Concretes
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository ,IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<bool> ActiveCategoryAsync(Guid id)
        {
            Category category = await _categoryRepository.GetWhere(a => a.Id == id);
            category.Status = true;
            return await _categoryRepository.UpdateAsync(category);
        }

        public async Task<bool> CreateAsync(CategoryCreateDTO categoryCreateDTO)
        {
            Category category = new();
            category = _mapper.Map(categoryCreateDTO, category);

            return await _categoryRepository.CreateAsync(category);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            Category category = await _categoryRepository.GetWhere(a => a.Id == id);
            return await _categoryRepository.DeleteAsync(category);
        }

        public async Task<List<CategoryDTO>> GetAllAsync()
        {
            List<CategoryDTO> list = await _categoryRepository.GetFilteredList(
                selector: x => new CategoryDTO
                {
                    Id = x.Id,
                    CategoryName = x.CategoryName,
                    CreatedDate = x.CreatedDate
                },
                expression: x => x.Status == true,
                orderBy: x => x.OrderBy(a => a.CategoryName)
                );
            return list;
        }

        public async Task<List<CategoryDTO>> GetAllPassivesAsync()
        {
            List<CategoryDTO> list = await _categoryRepository.GetFilteredList(
                selector: x => new CategoryDTO
                {
                    Id = x.Id,
                    CategoryName = x.CategoryName,
                    CreatedDate = x.CreatedDate,
                    ModifiedDate = (DateTime)x.ModifiedDate
                },
                expression: x => x.Status == false,
                orderBy: x => x.OrderBy(a => a.CategoryName)
                );
            return list;
        }

        public async Task<CategoryDTO> GetByIdAsync(Guid id)
        {
            CategoryDTO categoryDto = await _categoryRepository.GetFilteredFirstOrDefault(
                selector: x => new CategoryDTO
                {
                    Id = x.Id,
                    CategoryName= x.CategoryName,
                    CreatedDate= x.CreatedDate
                },
                expression: x => x.Id == id
                );
            return categoryDto;
        }

        public async Task<bool> UpdateAsync(CategoryUpdateDTO categoryUpdateDTO)
        {
            Category category = await _categoryRepository.GetWhere(x => x.Id == categoryUpdateDTO.Id);
            category = _mapper.Map(categoryUpdateDTO, category);

            return await _categoryRepository.UpdateAsync(category);
        }
    }
}
