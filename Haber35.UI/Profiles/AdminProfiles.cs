using AutoMapper;
using Haber35.BLL.DTOs;
using Haber35.CORE.Concretes;
using Haber35.UI.Models.VMs.Admin;
using Haber35.UI.Models.VMs.Article;
using Haber35.UI.Models.VMs.Category;
using Haber35.UI.Models.VMs.Comment;
using Haber35.UI.Models.VMs.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber35.UI.Profiles
{
    public class AdminProfiles : Profile
    {
        public AdminProfiles()
        {
            CreateMap<AppUser, AdminUpdateVM>().ReverseMap().ForMember("ImagePath", x => x.Ignore());

            CreateMap<ArticleDTO, Models.VMs.Admin.IndexVM>();
            CreateMap<ArticleDTO, ArticleListVM>();
            CreateMap<ArticleDTO, ArticleUpdateVM>();
            CreateMap<ArticleDTO, PassiveArticleVM>();
            CreateMap<ArticleDTO, CategoryArticlesVM>();
            CreateMap<ArticleCreateVM, ArticleCreateDTO>();
            CreateMap<ArticleUpdateVM, ArticleUpdateDTO>();

            CreateMap<CategoryDTO, CategoryListVM>();
            CreateMap<CategoryDTO, PassiveCategoryListVM>();
            CreateMap<CategoryCreateVM, CategoryCreateDTO>();
            CreateMap<CategoryDTO, CategoryUpdateVM>();
            CreateMap<CategoryUpdateVM, CategoryUpdateDTO>();

            CreateMap<CommentDTO, CommentVM>();
            CreateMap<CommentCreateVM, CommentCreateDTO>();
            CreateMap<CommentUpdateVM, CommentUpdateDTO>();
            CreateMap<CommentListDTO, CommentListVM>();
        }
    }
}

