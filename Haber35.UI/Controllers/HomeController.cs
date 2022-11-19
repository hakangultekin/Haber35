using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Haber35.BLL.Abstracts;
using Haber35.BLL.DTOs;
using Haber35.CORE.Concretes;
using Haber35.UI.Models;
using Haber35.UI.Models.VMs;
using Haber35.UI.Models.VMs.Article;
using Haber35.UI.Models.VMs.Home;
using Haber35.UI.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace Haber35.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;
        private readonly INotyfService _notifyService;
        private readonly ClaimService claimService;

        public HomeController(IArticleService articleService, ICategoryService categoryService ,UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMapper mapper, INotyfService notifyService)
        {
            _articleService = articleService;
            _categoryService = categoryService;
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _notifyService = notifyService;
            claimService = new ClaimService(userManager);
        }

        public async Task<IActionResult> Index()
        {
            IndexVM vm = new()
            {
                Populars = _mapper.Map<List<ArticleVM>>(await _articleService.GetPopularArticles()),
                Recents = _mapper.Map<List<ArticleVM>>(await _articleService.GetRecentArticles())
            };

            return View(vm);
        }

        public async Task<IActionResult> CategoryArticles(Guid id)
        {
            CategoryDTO cat = await _categoryService.GetByIdAsync(id);
            if (cat == null)
            {
                _notifyService.Error("Kategori bulunamadı !");
                return RedirectToAction("Index");
            }

            ViewBag.Category = cat.CategoryName;
            return View(_mapper.Map<IEnumerable<CategoryArticlesVM>>(await _articleService.GetArticlesByCategory(cat.Id)));
        }

        public IActionResult ArticleDetail(Guid id)
        {
            return View();
        }


        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated) RedirectToAction("Index");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (!ModelState.IsValid)
            {
                _notifyService.Error("Eksik veya hatalı bilgi girdiniz");
                return View(model);
            }

            AppUser user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                _notifyService.Error("Geçersiz kullanıcı adı veya şifre !");
                return View(model);
            }

            // Normalde claimlerin giriş onaylandıktan sonra eklenmesi gerekiyor ancak o şekilde eklediğimde manuel olarak eklediğim claim'leri admin layoutunda yakalayamadım. Bug'ı çözmek için vaktim kalmadığı için bu şekilde bıraktım
            List<Claim> list = new List<Claim>()
            {
                new Claim("Id", user.Id),
                new Claim("FirstName", user.FirstName),
                new Claim("ImagePath", user.ImagePath),
            };
            await _userManager.AddClaimsAsync(user, list);

            SignInResult result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
            if (!result.Succeeded)
            {
                _notifyService.Error("Geçersiz kullanıcı adı veya şifre !");
                await _userManager.RemoveClaimsAsync(user, list);
                return View(model);
            }

            _notifyService.Success($"Hoşgeldiniz : {user.UserName}");
            return RedirectToAction(controllerName: "Home", actionName: "Index");
        }

        
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Adress = model.Adress
                };

                IdentityResult result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    _notifyService.Success("Kullanıcı kaydı başarılı. Giriş yapabilirsiniz.");
                    return RedirectToAction("Login");
                }
                else
                {
                    LogResultErrors(result);
                    StringBuilder msg = new();
                    foreach (IdentityError item in result.Errors)
                    {
                        msg.Append($"<p>{item.Description}</p>");
                    }
                    _notifyService.Error(msg.ToString());
                    return View(model);
                }
            }

            var modelStateErrors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
            StringBuilder errorMsg = new();
            foreach (string item in modelStateErrors)
            {
                errorMsg.Append($"<p>{item}</p>");
            }
            _notifyService.Error(errorMsg.ToString());
            return View(model);
        }

        public async Task<IActionResult> LogOut()
        {
            AppUser user = await _userManager.GetUserAsync(User);

            if (user == null) return RedirectToAction("Index");

            await claimService.RemoveClaims(user);
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }

        private void LogResultErrors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", $"{error.Description}");
            }
        }
    }
}
