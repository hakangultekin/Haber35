using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber35.BLL.DTOs
{
    public class CommentUpdateDTO
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public string ModifierUserId { get; set; }
    }
}
