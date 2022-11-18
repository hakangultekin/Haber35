using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Haber35.BLL.Abstracts;
using Haber35.BLL.DTOs;
using Haber35.UI.Models.VMs.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Haber35.UI.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly INotyfService _notifyService;

        public CategoryController(ICategoryService categoryService, IMapper mapper, INotyfService notifyService)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _notifyService = notifyService;
        }


        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<CategoryListVM>>(await _categoryService.GetAllAsync()));
        }

        public async Task<IActionResult> PassiveCategories()
        {
            return View(_mapper.Map<IEnumerable<PassiveCategoryListVM>>(await _categoryService.GetAllPassivesAsync()));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                _notifyService.Error("Kategori oluşturulamadı. Lütfen isim alanını boş bırakmayınız.");
                return View(model);
            }

            model.CreatorUserId = User.Claims.First(z => z.Type == "Id").Value;
            bool result = await _categoryService.CreateAsync(_mapper.Map<CategoryCreateDTO>(model));

            if(!result)
            {
                _notifyService.Error("Kategori oluşturulamadı. Hata oluştu!");
                return View(model);
            }

            _notifyService.Success("Kategori oluşturuldu");
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            return View(_mapper.Map<CategoryUpdateVM>(await _categoryService.GetByIdAsync(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Update(CategoryUpdateVM model)
        {
            if (!ModelState.IsValid)
            {
                _notifyService.Error("Kategori kaydedilemedi. Lütfen isim alanını boş bırakmayınız.");
                return View(model);
            }

            model.ModifierUserId = User.Claims.First(z => z.Type == "Id").Value;
            bool result = await _categoryService.UpdateAsync(_mapper.Map<CategoryUpdateDTO>(model));

            if (!result)
            {
                _notifyService.Error("Kategori kaydedilemedi. Hata oluştu!");
                return View(model);
            }

            _notifyService.Success("Kategori düzenlendi");
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            bool result = await _categoryService.DeleteAsync(id);
            if (result) _notifyService.Success("Kategori pasif hale getirildi!");
            else _notifyService.Error("Kategori düzenlenirken hata oluştu!");

            return RedirectToAction(controllerName: "Category", actionName: "Index");
        }

        public async Task<IActionResult> Active(Guid id)
        {
            bool result = await _categoryService.ActiveCategoryAsync(id);
            if (result) _notifyService.Success("Kategori aktif hale getirildi!");
            else _notifyService.Error("Kategori düzenlenirken hata oluştu!");

            return RedirectToAction(controllerName: "Category", actionName: "Index");
        }
    }
}
