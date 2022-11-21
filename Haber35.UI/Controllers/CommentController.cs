using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Haber35.BLL.Abstracts;
using Haber35.BLL.DTOs;
using Haber35.UI.Models.VMs.Comment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Haber35.UI.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly INotyfService _notifyService;
        private readonly IMapper _mapper;

        public CommentController(ICommentService commentService, INotyfService notifyService, IMapper mapper)
        {
            _commentService = commentService;
            _notifyService = notifyService;
            _mapper = mapper;
        }


        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<List<CommentListVM>>(await _commentService.GetAllComments()));
        }

        public async Task<IActionResult> DeletedComments()
        {
            return View(_mapper.Map<List<CommentListVM>>(await _commentService.GetAllDeletedComments()));
        }

        [AllowAnonymous]
        public async Task<IActionResult> Create(CommentCreateDTO commentCreateDTO)
        {
            bool result = await _commentService.CreateAsync(commentCreateDTO);
            if (result) _notifyService.Success("Yorumunuz eklendi");
            else _notifyService.Error("Yorum ekleme başarısız oldu!");
            return RedirectToAction("ArticleDetail", "Home", new { id = commentCreateDTO.ArticleId });
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            bool result = await _commentService.DeleteAsync(id);
            if(result) _notifyService.Success("Yorum silindi.");
            else _notifyService.Error("Yorum silinirken hata oluştu");
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteAjax(Guid id)
        {
            return Json(new { result = await _commentService.DeleteAsync(id) });
        }
        
        public async Task<IActionResult> Active(Guid id)
        {
            bool result = await _commentService.ActiveAsync(id);
            if (result) _notifyService.Success("Yorum aktifleştirildi.");
            else _notifyService.Error("Yorum aktifleştirilirken hata oluştu");
            return RedirectToAction("DeletedComments");
        }
    }
}
