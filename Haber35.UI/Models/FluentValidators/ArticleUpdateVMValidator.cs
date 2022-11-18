using FluentValidation;
using Haber35.UI.Models.VMs.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber35.UI.Models.FluentValidators
{
    public class ArticleUpdateVMValidator : AbstractValidator<ArticleUpdateVM>
    {
        public ArticleUpdateVMValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş olamaz");
            RuleFor(x => x.Content).NotEmpty().WithMessage("İçerik boş olamaz");
            RuleFor(x => x.SelectedCategoriesIDs).NotNull().WithMessage("Lütfen en az 1 kategori seçin");
        }
    }
}

