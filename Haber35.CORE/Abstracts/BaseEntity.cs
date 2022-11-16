using Haber35.CORE.Concretes;
using Haber35.CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber35.CORE.Abstracts
{
    public class BaseEntity : ICreateable, IEditable, IDeleteable
    {
        public Guid Id { get; set; }
        public bool Status { get; set; }

        public string ModifierUserId { get; set; }
        public AppUser ModifierUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatorUserId { get; set; }
        public AppUser CreatorUser { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string DeletoryUserId { get; set; }
        public AppUser DeletoryUser { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
