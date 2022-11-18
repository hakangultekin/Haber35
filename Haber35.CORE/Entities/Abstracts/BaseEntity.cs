using Haber35.CORE.Concretes;
using Haber35.CORE.Entities.Interfaces;
using Haber35.CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber35.CORE.Abstracts
{
    public class BaseEntity : IBaseEntity
    {
        public bool Status { get; set; } = true;

        public string ModifierUserId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string DeletoryUserId { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
