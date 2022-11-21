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

        /// <summary>
        /// Silinmemiş olan bütün haberleri getirir
        /// </summary>
        /// <returns>List<ArticleDTO> türünde data objesi</returns>
        Task<List<ArticleDTO>> GetAllAsync();

        /// <summary>
        /// Silinmiş olan bütün haberleri getirir
        /// </summary>
        /// <returns>List<ArticleDTO> türünde data objesi</returns>
        Task<List<ArticleDTO>> GetAllPassivesAsync();

        /// <summary>
        /// Verilen Id'ye sahip haberi getirir
        /// </summary>
        /// <param name="articleId">Haber Id'si</param>
        /// <returns>ArticleDTO türünde data objesi</returns>
        Task<ArticleDTO> GetByIdAsync(Guid articleId);

        /// <summary>
        /// Kategori Id'sine göre haberleri getirir.
        /// </summary>
        /// <param name="categoryId">Kategori Id</param>
        /// <returns>List<ArticleDTO> türünde data objesi</returns>
        Task<List<ArticleDTO>> GetArticlesByCategory(Guid categoryId);

        /// <summary>
        /// Kategori ismine göre haberleri getirir.
        /// </summary>
        /// <param name="categoryName">Tam kategori ismi</param>
        /// <param name="limit">DB'den alınacak haber limiti. Default bırakılırsa limit olmaz.</param>
        /// <returns>List<ArticleDTO> türünde data objesi</returns>
        Task<List<ArticleDTO>> GetArticlesByCategoryName(string categoryName, int limit=0);

        /// <summary>
        /// En çok okunan 20 haberi getirir.
        /// </summary>
        /// <returns>List<ArticleDTO> türünde data objesi</returns>
        Task<List<ArticleDTO>> GetPopularArticles();

        /// <summary>
        /// En son eklenen 20 haberi getirir.
        /// </summary>
        /// <returns>List<ArticleDTO> türünde data objesi</returns>
        Task<List<ArticleDTO>> GetRecentArticles();

        /// <summary>
        /// Haberi günceller
        /// </summary>
        /// <param name="articleUpdateDTO">articleUpdateDTO türünde data objesi</param>
        /// <returns>bool türünde işlem sonucu</returns>
        Task<bool> UpdateAsync(ArticleUpdateDTO articleUpdateDTO);

        /// <summary>
        /// Aktif olan bir haberi yayından kaldırır. (Pasif yapar)
        /// </summary>
        /// <param name="articleId">Haber Id'si</param>
        /// <returns>bool türünde işlem sonucu</returns>
        Task<bool> DeleteAsync(Guid articleId);

        /// <summary>
        /// Silinmiş olan haberi tekrar aktif eder.
        /// </summary>
        /// <param name="articleId">Haber Id'si</param>
        /// <returns>bool türünde işlem sonucu</returns>
        Task<bool> ActiveArticleAsync(Guid articleId);

        /// <summary>
        /// Haberin yorum ve kategorilerini içeren sonuç döner.
        /// </summary>
        /// <param name="articleId">Haber Id'si</param>
        /// <returns>ArticleDetailDTO tipinde data objesi</returns>
        Task<ArticleDetailDTO> GetArticleWithDetail(Guid articleId);

        /// <summary>
        /// Haberin görüntülenme sayısını 1 arttırır
        /// </summary>
        /// <param name="articleId">Haberin Id'si</param>
        /// <returns>bool türünde işlem sonucu</returns>
        Task<bool> IncreaseViewerCount(Guid articleId);
    }
}
