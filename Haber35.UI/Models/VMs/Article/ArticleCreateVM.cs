using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber35.UI.Models.VMs.Article
{
    public class ArticleCreateVM
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImagePath { get; set; }
        public Guid[] SelectedCategoriesIDs { get; set; }
        public IFormFile UploadImage { get; set; }
        public string CreatorUserId { get; set; }
    }
}

