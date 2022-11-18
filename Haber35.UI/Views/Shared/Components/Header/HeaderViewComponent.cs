using AutoMapper;
using Haber35.BLL.Abstracts;
using Haber35.CORE.Concretes;
using Haber35.UI.Models.VMs.Category;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber35.UI.Views.Shared.ViewComponents.Header
{
    [ViewComponent(Name = "Header")]
    public class HeaderViewComponent : ViewComponent
    {
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;

        public HeaderViewComponent(ICategoryService categoryService, IMapper mapper)
        {
            this.categoryService = categoryService;
            this.mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(mapper.Map<List<CategoryListVM>>(await categoryService.GetAllAsync()));
        }
    }
}

