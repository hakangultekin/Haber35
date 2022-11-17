using Haber35.CORE.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber35.CORE.Concretes
{
    public class Category : BaseEntity
    {
        public Category()
        {
            Articles = new HashSet<Article>();
            Id = Guid.NewGuid();
        }

        public string CategoryName { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}
