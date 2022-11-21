using Haber35.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber35.BLL.Abstracts
{
    public interface ICommentService
    {
        /// <summary>
        /// Bütün yorumları getirir
        /// </summary>
        /// <returns>List<CommentListDTO> türünde data objesi</returns>
        Task<List<CommentListDTO>> GetAllComments();

        /// <summary>
        /// Bütün silinen yorumları getirir
        /// </summary>
        /// <returns>List<CommentListDTO> türünde data objesi</returns>
        Task<List<CommentListDTO>> GetAllDeletedComments();

        /// <summary>
        /// Yeni bir yorum oluşturur.
        /// </summary>
        /// <param name="commentCreateDTO">commentCreateDTO türünde data objesi</param>
        /// <returns>bool türünde işlem sonucu</returns>
        Task<bool> CreateAsync(CommentCreateDTO commentCreateDTO);

        /// <summary>
        /// Belirli bir habere ait yorumları getirir.
        /// </summary>
        /// <param name="articleId">Haber Id'si</param>
        /// <returns>List<CommentDTO> türünde data objesi</returns>
        Task<List<CommentDTO>> GetCommentsByArticleAsync(Guid articleId);

        /// <summary>
        /// Id'si verilen yorumu getirir.
        /// </summary>
        /// <param name="commentId">Yorum Id'si</param>
        /// <returns>CommentDTO türünde data objesi</returns>
        Task<CommentDTO> GetByIdAsync(Guid commentId);

        /// <summary>
        /// Yorumu günceller.
        /// </summary>
        /// <param name="commentUpdateDTO">commentUpdateDTO türünde data objesi</param>
        /// <returns>bool türünde işlem sonucu</returns>
        Task<bool> UpdateAsync(CommentUpdateDTO commentUpdateDTO);

        /// <summary>
        /// Id'si verilen yorumu siler. (pasif hale getirir databaseden silmez.)
        /// </summary>
        /// <param name="commentId">Yorum Id'si</param>
        /// <returns>bool türünde işlem sonucu</returns>
        Task<bool> DeleteAsync(Guid commentId);

        /// <summary>
        /// Id'si verilen silinmiş yorumu aktifleştirir.
        /// </summary>
        /// <param name="commentId">Yorum Id'si</param>
        /// <returns>CommentDTO türünde data objesi</returns>
        Task<bool> ActiveAsync(Guid commentId);
    }
}
