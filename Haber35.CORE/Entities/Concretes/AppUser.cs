using Haber35.CORE.Entities.Interfaces;
using Haber35.CORE.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber35.CORE.Concretes
{
    public class AppUser : IdentityUser, IBaseEntity
    {
        public AppUser()
        {
            Articles = new HashSet<Article>();
            Categories = new HashSet<Category>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string ImagePath { get; set; } = "/images/users/account-add-photo.svg";
        public string Adress { get; set; }
        public bool Status { get; set; } = true;
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public ICollection<Article> Articles { get; set; }
        public ICollection<Category> Categories { get; set; }

        public string ModifierUserId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string DeletoryUserId { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
