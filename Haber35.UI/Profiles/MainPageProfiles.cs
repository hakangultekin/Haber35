using AutoMapper;
using Haber35.BLL.DTOs;
using Haber35.UI.Models.VMs.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber35.UI.Profiles
{
    public class MainPageProfiles :Profile
    {
        public MainPageProfiles()
        {
            CreateMap<ArticleDTO, ArticleVM>();
        }
    }
}

