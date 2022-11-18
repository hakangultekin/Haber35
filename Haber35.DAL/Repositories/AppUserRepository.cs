using Haber35.CORE.Concretes;
using Haber35.CORE.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber35.DAL.Repositories
{
    public class AppUserRepository : BaseRepository<AppUser>, IAppUserRepository
    {
        public AppUserRepository(AppDbContext db) : base(db)
        {
        }
    }
}
