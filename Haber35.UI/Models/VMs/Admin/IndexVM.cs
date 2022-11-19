using Haber35.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber35.UI.Models.VMs.Admin
{
    public class IndexVM
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImagePath { get; set; }
        public int Viewer { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<CategoryDTO> Categories = new List<CategoryDTO>();
        public string GetCategoriesString { get => string.Join(',', Categories.Select(x => x.CategoryName)); }
    }
}

