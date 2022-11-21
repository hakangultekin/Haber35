using AutoMapper;
using Haber35.BLL.Abstracts;
using Haber35.BLL.DTOs;
using Haber35.CORE.Concretes;
using Haber35.CORE.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber35.BLL.Concretes
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public ArticleService(IArticleRepository articleRepository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _articleRepository = articleRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<bool> ActiveArticleAsync(Guid id)
        {
            Article article = await _articleRepository.GetWhere(a => a.Id == id);
            article.Status = true;
            return await _articleRepository.UpdateAsync(article);
        }

        public async Task<bool> CreateAsync(ArticleCreateDTO articleCreateDTO)
        {
            Article article = new Article();
            article = _mapper.Map(articleCreateDTO, article);

            foreach (Guid item in articleCreateDTO.SelectedCategoriesIDs)
            {
                article.Categories.Add(await _categoryRepository.GetWhere(x => x.Id == item));
            }

            return await _articleRepository.CreateAsync(article);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            Article article = await _articleRepository.GetWhere(a => a.Id == id);
            return await _articleRepository.DeleteAsync(article);
        }

        public async Task<List<ArticleDTO>> GetAllAsync()
        {
            List<ArticleDTO> list = await _articleRepository.GetFilteredList(
                selector: x => new ArticleDTO
                {
                    Id = x.Id,
                    Content = x.Content,
                    CreatedDate = x.CreatedDate,
                    ModifiedDate = x.ModifiedDate,
                    ImagePath = x.ImagePath,
                    Title = x.Title,
                    Viewer = x.Viewer,
                    Categories = _mapper.Map<List<CategoryDTO>>(x.Categories),
                },
                includes: x => x.Include(c => c.Categories),
                expression: x => x.Status == true
                );
            return list;
        }

        public async Task<List<ArticleDTO>> GetAllPassivesAsync()
        {
            List<ArticleDTO> list = await _articleRepository.GetFilteredList(
                selector: x => new ArticleDTO
                {
                    Id = x.Id,
                    Content = x.Content,
                    CreatedDate = x.CreatedDate,
                    ModifiedDate = x.ModifiedDate,
                    ImagePath = x.ImagePath,
                    Title = x.Title,
                    Viewer = x.Viewer,
                    Categories = _mapper.Map<List<CategoryDTO>>(x.Categories),
                },
                includes: x => x.Include(c => c.Categories),
                expression: x => x.Status == false
                );
            return list;
        }

        public async Task<List<ArticleDTO>> GetArticlesByCategory(Guid categoryId)
        {
            List<ArticleDTO> list = await _articleRepository.GetFilteredList(
                selector: x => new ArticleDTO
                {
                    Id = x.Id,
                    Content = x.Content,
                    CreatedDate = x.CreatedDate,
                    ImagePath = x.ImagePath,
                    Title = x.Title,
                    Viewer = x.Viewer,
                    Categories = _mapper.Map<List<CategoryDTO>>(x.Categories),
                },
                includes: x => x.Include(c => c.Categories),
                expression: x => x.Status == true && x.Categories.Any(x => x.Id == categoryId)
                );
            return list;
        }

        public async Task<List<ArticleDTO>> GetArticlesByCategoryName(string categoryName, int limit=0)
        {
            List<ArticleDTO> list = await _articleRepository.GetFilteredList(
                selector: x => new ArticleDTO
                {
                    Id = x.Id,
                    Content = x.Content,
                    CreatedDate = x.CreatedDate,
                    ImagePath = x.ImagePath,
                    Title = x.Title,
                    Viewer = x.Viewer,
                    Categories = _mapper.Map<List<CategoryDTO>>(x.Categories),
                },
                includes: x => x.Include(c => c.Categories),
                expression: x => x.Status == true && x.Categories.Any(x => x.CategoryName == categoryName),
                limit : limit
                );
            return list;
        }

        public async Task<ArticleDTO> GetByIdAsync(Guid id)
        {
            ArticleDTO article = await _articleRepository.GetFilteredFirstOrDefault(
                selector: x => new ArticleDTO
                {
                    Id = x.Id,
                    Content = x.Content,
                    CreatedDate = x.CreatedDate,
                    ImagePath = x.ImagePath,
                    Title = x.Title,
                    Viewer = x.Viewer,
                    Categories = _mapper.Map<List<CategoryDTO>>(x.Categories),
                },
                includes: x => x.Include(c => c.Categories),
                expression: x => x.Id == id
                );
            return article;
        }

        public async Task<List<ArticleDTO>> GetPopularArticles()
        {
            List<ArticleDTO> list = await _articleRepository.GetFilteredList(
                selector: x => new ArticleDTO
                {
                    Id = x.Id,
                    AuthorUserName = x.CreatorUser.UserName,
                    Content = x.Content,
                    CreatedDate = x.CreatedDate,
                    ImagePath = x.ImagePath,
                    Title = x.Title,
                    Viewer = x.Viewer,
                    Categories = _mapper.Map<List<CategoryDTO>>(x.Categories),
                },
                includes: x => x.Include(c => c.Categories).Include(c => c.CreatorUser),
                expression: x => x.Status == true,
                orderBy: x => x.OrderByDescending(a => a.Viewer),
                limit: 20
                );
            return list;
        }

        public async Task<List<ArticleDTO>> GetRecentArticles()
        {
            List<ArticleDTO> list = await _articleRepository.GetFilteredList(
                selector: x => new ArticleDTO
                {
                    Id = x.Id,
                    AuthorUserName = x.CreatorUser.UserName,
                    Content = x.Content,
                    CreatedDate = x.CreatedDate,
                    ImagePath = x.ImagePath,
                    Title = x.Title,
                    Viewer = x.Viewer,
                    Categories = _mapper.Map<List<CategoryDTO>>(x.Categories),
                },
                includes: x => x.Include(c => c.Categories).Include(c => c.CreatorUser),
                expression: x => x.Status == true,
                orderBy: x => x.OrderByDescending(a => a.CreatedDate),
                limit: 20
                );
            return list;
        }

        public async Task<bool> UpdateAsync(ArticleUpdateDTO articleUpdateDTO)
        {
            Article article = await _articleRepository.GetWhereIncludeCategories(a => a.Id == articleUpdateDTO.Id);
            article = _mapper.Map(articleUpdateDTO, article);
            article.Categories.Clear();

            foreach (Guid item in articleUpdateDTO.SelectedCategoriesIDs)
            {
                article.Categories.Add(await _categoryRepository.GetWhere(x => x.Id == item));
            }


            return await _articleRepository.UpdateAsync(article);
        }

        public async Task<ArticleDetailDTO> GetArticleWithDetail(Guid articleId)
        {
            ArticleDetailDTO article = await _articleRepository.GetFilteredFirstOrDefault(
                selector: x => new ArticleDetailDTO
                {
                    Id = x.Id,
                    AuthorUserName = x.CreatorUser.UserName,
                    Content = x.Content,
                    CreatedDate = x.CreatedDate,
                    ImagePath = x.ImagePath,
                    Title = x.Title,
                    Viewer = x.Viewer,
                    Categories = _mapper.Map<List<CategoryDTO>>(x.Categories),
                    Comments = _mapper.Map<List<CommentDTO>>(x.Comments)
                },
                includes: x => x.Include(c => c.Categories).Include(cm => cm.Comments).Include(u => u.CreatorUser),
                expression: x => x.Id == articleId
            );
            return article;
        }

        public async Task<bool> IncreaseViewerCount(Guid articleId)
        {
            return await _articleRepository.ExecuteRawSqlQuery($"Update Articles Set Viewer = Viewer+1 where Id='{articleId}'");
        }
    }
}
