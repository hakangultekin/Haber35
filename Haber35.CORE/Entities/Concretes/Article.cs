using Haber35.CORE.Abstracts;
using Haber35.CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber35.CORE.Concretes
{
    public class Article : BaseEntity
    {
        public Article()
        {
            Categories = new HashSet<Category>();
            Comments = new HashSet<Comment>();
            Id = Guid.NewGuid();
        }

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

        public ICollection<Category> Categories { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
