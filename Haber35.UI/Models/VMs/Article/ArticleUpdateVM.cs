using Haber35.BLL.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber35.UI.Models.VMs.Article
{
    public class ArticleUpdateVM
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImagePath { get; set; }
        public List<CategoryDTO> Categories { get; set; }
        public Guid[] SelectedCategoriesIDs { get; set; }
        public IFormFile UploadImage { get; set; }
        public string ModifierUserId { get; set; }
    }
}

