using Haber35.CORE.Concretes;
using Haber35.CORE.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Haber35.DAL.Repositories
{
    public class ArticleRepository : BaseRepository<Article>, IArticleRepository
    {
        private readonly AppDbContext db;

        public ArticleRepository(AppDbContext db) : base(db)
        {
            this.db = db;
        }

        public async Task<Article> GetWhereIncludeCategories(Expression<Func<Article, bool>> expression)
        {
            return await db.Set<Article>().Include(x => x.Categories).FirstOrDefaultAsync(expression);
        }
    }
}
