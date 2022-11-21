using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber35.BLL.DTOs
{
    public class ArticleDetailDTO
    {
        public Guid Id { get; set; }
        public string AuthorUserName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImagePath { get; set; }
        public int Viewer { get; set; }
        public string ViewTime
        {
            get
            {
                if (Content.Length > 0)
                {
                    string[] wordList = Content.Split(' ');
                    int saniye = Convert.ToInt32(wordList.Length / 2);
                    if (saniye < 60)
                        return $"{saniye} saniye.";
                    else
                    {
                        return $"{Convert.ToInt32(saniye / 60)} dakika";
                    }
                }
                return "0 saniye";
            }
        }

        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public List<CategoryDTO> Categories = new List<CategoryDTO>();
        public List<CommentDTO> Comments = new List<CommentDTO>();
    }
}