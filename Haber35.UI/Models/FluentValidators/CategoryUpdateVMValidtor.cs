using FluentValidation;
using Haber35.UI.Models.VMs.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber35.UI.Models.FluentValidators
{
    public class CategoryUpdateVMValidtor : AbstractValidator<CategoryUpdateVM>
    {
        public CategoryUpdateVMValidtor()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori ismi boş olamaz");
        }
    }
}

