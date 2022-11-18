using Haber35.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber35.UI.Models.VMs.Article
{
    public class ArticleListVM
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImagePath { get; set; }
        public int Viewer { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<CategoryDTO> Categories = new List<CategoryDTO>();
        public string GetCategoriesString
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                foreach (var item in Categories)
                {
                    sb.Append(item.CategoryName + ",");
                }
                return sb.ToString();
            }
        }
    }
}

