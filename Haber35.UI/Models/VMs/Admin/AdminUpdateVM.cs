using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber35.UI.Models.VMs.Admin
{
    public class AdminUpdateVM
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
        public string ImagePath { get; set; }
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public IFormFile UploadImage { get; set; }
    }
}

