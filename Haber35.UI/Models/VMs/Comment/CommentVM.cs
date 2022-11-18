using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber35.UI.Models.VMs.Comment
{
    public class CommentVM
    {
        public Guid Id { get; set; }
        public Guid ArticleId { get; set; }
        public string UserName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

