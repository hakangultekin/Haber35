using FluentValidation;
using Haber35.UI.Models.VMs.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber35.UI.Models.FluentValidators
{
    public class AdminUpdateVMValidator : AbstractValidator<AdminUpdateVM>
    {
        public AdminUpdateVMValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Lütfen email alanını doldurunuz.").EmailAddress().WithMessage("Lütfen geçerli bir email adresi girin.");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Lütfen kullanıcı adı alanını doldurunuz.");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Lütfen isim alanını doldurunuz.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Lütfen soyisim alanını doldurunuz.");
        }
    }
}

