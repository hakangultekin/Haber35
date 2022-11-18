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
        Task<bool> CreateAsync(CommentCreateDTO commentCreateDTO);
        Task<List<CommentDTO>> GetCommentsByArticleAsync(Guid id);
        Task<CommentDTO> GetByIdAsync(Guid id);
        Task<bool> UpdateAsync(CommentUpdateDTO commentUpdateDTO);
        Task<bool> DeleteAsync(Guid id);
    }
}
