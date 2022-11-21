using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber35.UI.Models.VMs.Comment
{
    public class CommentListVM
    {
        public Guid Id { get; set; }
        public Guid ArticleId { get; set; }
        public string ArticleTitle { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ArticleShortTitle { get => ArticleTitle.Length > 50 ? ArticleTitle.Substring(0, 50) : ArticleTitle; }
    }
}

