using AutoMapper;
using Haber35.BLL.Abstracts;
using Haber35.CORE.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber35.BLL.Concretes
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IMapper _mapper;

        public ArticleService(IArticleRepository articleRepository , IMapper mapper)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
        }
    }
}
