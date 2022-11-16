using Haber35.CORE.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber35.CORE.Concretes
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
            Articles = new HashSet<Article>();
            Categories = new HashSet<Category>();
            DeletedComments = new HashSet<Comment>();
            ModifiedComments = new HashSet<Comment>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImagePath { get; set; }
        public string Adress { get; set; }
        public bool Status { get; set; } = true;

        public ICollection<Article> Articles { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<Comment> DeletedComments { get; set; }
        public ICollection<Comment> ModifiedComments { get; set; }

    }
}
