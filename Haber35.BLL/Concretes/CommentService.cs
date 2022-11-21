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
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        public CommentService(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<List<CommentListDTO>> GetAllComments()
        {
            List<CommentListDTO> list = await _commentRepository.GetFilteredList(
                selector: x => new CommentListDTO
                {
                    Id = x.Id,
                    ArticleId = x.ArticleId,
                    CreatedDate = x.CreatedDate,
                    Description = x.Description,
                    Email = x.Email,
                    Name = x.Name,
                    ArticleTitle = x.Article.Title
                },
                expression: x => x.Status == true,
                orderBy: x => x.OrderByDescending(a => a.CreatedDate)
                );
            return list;
        }

        public async Task<List<CommentListDTO>> GetAllDeletedComments()
        {
            List<CommentListDTO> list = await _commentRepository.GetFilteredList(
                selector: x => new CommentListDTO
                {
                    Id = x.Id,
                    ArticleId = x.ArticleId,
                    CreatedDate = x.CreatedDate,
                    Description = x.Description,
                    Email = x.Email,
                    Name = x.Name,
                    ArticleTitle = x.Article.Title
                },
                expression: x => x.Status == false,
                orderBy: x => x.OrderByDescending(a => a.CreatedDate)
                );
            return list;
        }

        public async Task<bool> CreateAsync(CommentCreateDTO commentCreateDTO)
        {
            Comment comment = new();
            comment = _mapper.Map<Comment>(commentCreateDTO);

            return await _commentRepository.CreateAsync(comment);
        }

        public async Task<bool> DeleteAsync(Guid commentId)
        {
            Comment comment = await _commentRepository.GetWhere(a => a.Id == commentId);
            return await _commentRepository.DeleteAsync(comment);
        }

        public async Task<CommentDTO> GetByIdAsync(Guid commentId)
        {
            CommentDTO commentDto = await _commentRepository.GetFilteredFirstOrDefault(
                selector: x => new CommentDTO
                {
                    Id = x.Id,
                    ArticleId = x.ArticleId,
                    CreatedDate = x.CreatedDate,
                    Description = x.Description,
                    Email = x.Email,
                    Name = x.Name,
                },
                expression: x => x.Id == commentId
                );
            return commentDto;
        }

        public async Task<List<CommentDTO>> GetCommentsByArticleAsync(Guid articleId)
        {
            List<CommentDTO> list = await _commentRepository.GetFilteredList(
                selector: x => new CommentDTO
                {
                    Id = x.Id,
                    ArticleId = x.ArticleId,
                    CreatedDate = x.CreatedDate,
                    Description = x.Description,
                    Email = x.Email,
                    Name = x.Name,
                },
                expression: x => x.Status == true && x.ArticleId == articleId,
                orderBy: x => x.OrderByDescending(a => a.CreatedDate)
                );
            return list;
        }

        public async Task<bool> UpdateAsync(CommentUpdateDTO commentUpdateDTO)
        {
            Comment comment = await _commentRepository.GetWhere(x => x.Id == commentUpdateDTO.Id);
            comment = _mapper.Map(commentUpdateDTO, comment);

            return await _commentRepository.UpdateAsync(comment);
        }

        public async Task<bool> ActiveAsync(Guid commentId)
        {
            Comment comment = await _commentRepository.GetWhere(x => x.Id == commentId);
            comment.Status = true;
            return await _commentRepository.UpdateAsync(comment);
        }
    }
}
