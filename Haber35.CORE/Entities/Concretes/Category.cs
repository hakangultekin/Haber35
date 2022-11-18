using Haber35.CORE.Abstracts;
using Haber35.CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber35.CORE.Concretes
{
    public class Category : BaseEntity, ICreateable
    {
        public Category()
        {
            Articles = new HashSet<Article>();
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Article> Articles { get; set; }

        public string CreatorUserId { get; set; }
        public AppUser CreatorUser { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
