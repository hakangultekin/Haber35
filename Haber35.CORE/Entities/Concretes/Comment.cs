using Haber35.CORE.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber35.CORE.Concretes
{
    public class Comment : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public Guid ArticleId { get; set; }
        public Article Article { get; set; }
    }
}
