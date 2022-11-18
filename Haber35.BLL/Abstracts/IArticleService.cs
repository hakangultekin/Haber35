using Haber35.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber35.BLL.Abstracts
{
    public interface IArticleService
    {
        Task<bool> CreateAsync(ArticleCreateDTO articleCreateDTO);
        Task<List<ArticleDTO>> GetAllAsync();
        Task<List<ArticleDTO>> GetAllPassivesAsync();
        Task<ArticleDTO> GetByIdAsync(Guid id);
        Task<List<ArticleDTO>> GetArticlesByCategory(Guid categoryId);
        Task<List<ArticleDTO>> GetPopularArticles();
        Task<List<ArticleDTO>> GetRecentArticles();
        Task<bool> UpdateAsync(ArticleUpdateDTO articleUpdateDTO);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> ActiveArticleAsync(Guid id);
    }
}
