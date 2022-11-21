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
        /// <summary>
        /// Yeni kategori oluşturur.
        /// </summary>
        /// <param name="categoryCreateDTO">categoryCreateDTO türünde data objesi</param>
        /// <returns>bool türünde işlem sonucu</returns>
        Task<bool> CreateAsync(CategoryCreateDTO categoryCreateDTO);

        /// <summary>
        /// Bütün kategorileri getirir
        /// </summary>
        /// <returns>List<CategoryDTO> türünde data objesi</returns>
        Task<List<CategoryDTO>> GetAllAsync();

        /// <summary>
        /// Pasif duruma getirilmiş kategorileri getirir.
        /// </summary>
        /// <returns>List<CategoryDTO> türünde data objesi</returns>
        Task<List<CategoryDTO>> GetAllPassivesAsync();

        /// <summary>
        /// Verilen Id'ye ait kategoriyi getirir.
        /// </summary>
        /// <param name="categoryId">Kategori Id'si</param>
        /// <returns>CategoryDTO türünde data objesi</returns>
        Task<CategoryDTO> GetByIdAsync(Guid categoryId);

        /// <summary>
        /// Kategoriyi günceller
        /// </summary>
        /// <param name="categoryUpdateDTO">categoryUpdateDTO türünde data objesi</param>
        /// <returns>bool türünde işlem sonucu</returns>
        Task<bool> UpdateAsync(CategoryUpdateDTO categoryUpdateDTO);

        /// <summary>
        /// Kategoriyi pasif hale getirir. Yeni eklenen haberler için seçilemez olur.
        /// </summary>
        /// <param name="categoryId">Kategori Id'si</param>
        /// <returns>bool türünde işlem sonucu</returns>
        Task<bool> DeleteAsync(Guid categoryId);

        /// <summary>
        /// Pasif durumdaki kategoriyi aktif hale getirir. Yeni haberler için seçilebilir olur.
        /// </summary>
        /// <param name="categoryId">Kategori Id'si</param>
        /// <returns>bool türünde işlem sonucu</returns>
        Task<bool> ActiveCategoryAsync(Guid categoryId);
    }
}
