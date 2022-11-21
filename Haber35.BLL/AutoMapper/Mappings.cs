using AutoMapper;
using Haber35.BLL.DTOs;
using Haber35.CORE.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber35.BLL.AutoMapper
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryCreateDTO, Category>();
            CreateMap<CategoryUpdateDTO, Category>();


            CreateMap<ArticleCreateDTO, Article>().ForAllMembers(x => x.UseDestinationValue());
            CreateMap<ArticleUpdateDTO, Article>().ForAllMembers(x => x.UseDestinationValue());
            CreateMap<ArticleDetailDTO, Article>().ForAllMembers(x => x.UseDestinationValue());

            CreateMap<CommentUpdateDTO, Comment>();
            CreateMap<CommentCreateDTO, Comment>();
            CreateMap<Comment, CommentDTO>();
            CreateMap<Comment, CommentListDTO>();

        }
    }
}
