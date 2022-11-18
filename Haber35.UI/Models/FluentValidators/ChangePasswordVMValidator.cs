using FluentValidation;
using Haber35.UI.Models.VMs.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber35.UI.Models.FluentValidators
{
    public class ChangePasswordVMValidator : AbstractValidator<ChangePasswordVM>
    {
        public ChangePasswordVMValidator()
        {
            RuleFor(x => x.OldPassword).NotEmpty().WithMessage("Eski şifreniz boş olamaz");
            RuleFor(x => x.NewPassword).NotEmpty().WithMessage("Yeni şifreniz boş olamaz");
        }
    }
}

