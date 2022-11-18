using Haber35.CORE.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Haber35.CORE.IRepositories
{
    public interface IArticleRepository : IBaseRepository<Article>
    {
        Task<Article> GetWhereIncludeCategories(Expression<Func<Article, bool>> expression);
    }
}
