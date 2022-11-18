using AutoMapper;
using Haber35.BLL.Abstracts;
using Haber35.CORE.Concretes;
using Haber35.UI.Models.VMs.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Haber35.UI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IArticleService _articleService;
        private readonly IMapper _mapper;

        public AdminController(UserManager<AppUser> userManager, IArticleService articleService, IMapper mapper)
        {
            _userManager = userManager;
            _articleService = articleService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<IndexVM>>(await _articleService.GetAllAsync()));
        }
    }
}
