using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Haber35.BLL.Abstracts;
using Haber35.CORE.Concretes;
using Haber35.UI.Models.VMs.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber35.UI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IPasswordHasher<AppUser> _passwordHasher;
        private readonly IArticleService _articleService;
        private readonly IMapper _mapper;
        private readonly INotyfService _notifyService;

        public AdminController(UserManager<AppUser> userManager, IPasswordHasher<AppUser> passwordHasher, IArticleService articleService, IMapper mapper, INotyfService notifyService)
        {
            _userManager = userManager;
            _passwordHasher = passwordHasher;
            _articleService = articleService;
            _mapper = mapper;
            _notifyService = notifyService;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<IndexVM>>(await _articleService.GetAllAsync()));
        }

        [HttpGet]
        public async Task<IActionResult> Update()
        {
            AppUser user = await _userManager.GetUserAsync(User);
            if(user == null)
            {
                _notifyService.Error("Kullanıcı bulunnamadı !");
                return RedirectToAction(controllerName: "Home", actionName: "Login");
            }

            return View(_mapper.Map<AdminUpdateVM>(user));
        }

        [HttpPost]
        public async Task<IActionResult> Update(AdminUpdateVM model)
        {
            AppUser user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                _notifyService.Error("Kullanıcı bulunnamadı !");
                return RedirectToAction(controllerName: "Home", actionName: "Login");
            }


            if (!ModelState.IsValid)
            {
                model.ImagePath = user.ImagePath;
                _notifyService.Error("Güncelleme başarısız lütfen girdiğiniz bilgileri kontrol edin !");
                return View(model);
            }

            user = _mapper.Map(model, user);
            IdentityResult result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                // Write photo
                if (model.UploadImage != null)
                {
                    using var image = Image.Load(model.UploadImage.OpenReadStream());

                    string fileName = $"{user.Id}.jpg";
                    image.Save($"wwwroot/Images/Users/{fileName}");
                }

                _notifyService.Success("Güncelleme başarılı !");
            }
            else
            {
                StringBuilder msg = new();
                foreach (IdentityError item in result.Errors)
                {
                    msg.Append($"<p>{item.Description}</p>");
                }
                _notifyService.Error(msg.ToString());
            };

            model.ImagePath = user.ImagePath;
            return View(model);
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordVM model)
        {
            if (!ModelState.IsValid)
            {
                _notifyService.Error("Şifre güncellenemedi !");
                return View(model);
            }

            AppUser user = await _userManager.GetUserAsync(User);
            user.PasswordHash = _passwordHasher.HashPassword(user, model.NewPassword);
            IdentityResult result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded) _notifyService.Error("Şifre güncellenemedi !");
            else _notifyService.Success("Şifre Değiştirildi !");

            return View();
        }
    }
}
