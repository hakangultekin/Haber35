using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Haber35.BLL.Abstracts;
using Haber35.BLL.DTOs;
using Haber35.UI.Models.VMs.Article;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Haber35.UI.Controllers
{
    [Authorize]
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly INotyfService _notifyService;

        public ArticleController(IArticleService articleService, ICategoryService categoryService, IMapper mapper, INotyfService notifyService)
        {
            _articleService = articleService;
            _categoryService = categoryService;
            _mapper = mapper;
            _notifyService = notifyService;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ArticleListVM>>(await _articleService.GetAllAsync()));
        }

        
        public async Task<IActionResult> PassiveArticles()
        {
            return View(_mapper.Map<IEnumerable<PassiveArticleVM>>(await _articleService.GetAllPassivesAsync()));
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _categoryService.GetAllAsync();
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(ArticleCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = await _categoryService.GetAllAsync();
                _notifyService.Error("Haber oluşturulamadı!");
                return View(model);
            }

            model.CreatorUserId = User.Claims.First(z => z.Type == "Id").Value;

            // Write photo
            if (model.UploadImage != null)
            {
                using var image = Image.Load(model.UploadImage.OpenReadStream());
                
                string fileName = $"{model.Id}.jpg";
                image.Save($"wwwroot/Images/Post/{fileName}");

                model.ImagePath = $"/Images/Post/{fileName}";
            }

            bool result = await _articleService.CreateAsync(_mapper.Map<ArticleCreateDTO>(model));
            if (!result)
            {
                ViewBag.Categories = await _categoryService.GetAllAsync();
                _notifyService.Error("Haber oluşturulamadı!");
                return View(model);
            }

            _notifyService.Success("Haber Oluşturuldu!");
            return RedirectToAction(controllerName:"Admin", actionName:"Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            ViewBag.Categories = await _categoryService.GetAllAsync();
            return View(_mapper.Map<ArticleUpdateVM>(await _articleService.GetByIdAsync(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Update(ArticleUpdateVM model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = await _categoryService.GetAllAsync();
                _notifyService.Error("Haber oluşturulamadı!");
                return View(model);
            }

            // Write photo
            if (model.UploadImage != null)
            {
                using var image = Image.Load(model.UploadImage.OpenReadStream());

                string fileName = $"{model.Id}.jpg";
                image.Save($"wwwroot/Images/Post/{fileName}");

                model.ImagePath = $"/Images/Post/{fileName}";
            }

            model.ModifierUserId = User.Claims.First(z => z.Type == "Id").Value;
            bool result = await _articleService.UpdateAsync(_mapper.Map<ArticleUpdateDTO>(model));
            if (!result)
            {
                _notifyService.Error("Haber kaydedilemedi!");
                return View(model);
            }

            _notifyService.Success("Haber kaydedildi!");
            return RedirectToAction(controllerName: "Admin", actionName: "Index");

        }

        
        public async Task<IActionResult> Delete(Guid id)
        {
            bool result = await _articleService.DeleteAsync(id);
            if (result) _notifyService.Success("Haber silindi!");
            else _notifyService.Error("Haber silinirken hata oluştu!");

            return RedirectToAction(controllerName:"Admin", actionName:"Index");
        }

        
        public async Task<IActionResult> Active(Guid id)
        {
            bool result = await _articleService.ActiveArticleAsync(id);
            if (result) _notifyService.Success("Haber aktif hale getirildi!");
            else _notifyService.Error("Haber düzenlenirken hata oluştu!");

            return RedirectToAction(controllerName: "Admin", actionName: "Index");
        }

        
        public async Task<IActionResult> GetByCategory(Guid catgoryId)
        {
            CategoryDTO cat = await _categoryService.GetByIdAsync(catgoryId);
            if(cat == null)
            {
                _notifyService.Error("Kategori bulunamadı !");
                return RedirectToAction("Index");
            }

            ViewBag.Category = cat.CategoryName;
            return View(_mapper.Map<IEnumerable<ArticleListVM>>(await _articleService.GetArticlesByCategory(cat.Id)));
        }

    }
}
