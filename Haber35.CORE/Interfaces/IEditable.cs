using Haber35.CORE.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber35.CORE.Interfaces
{
    public interface IEditable
    {
        public string ModifierUserId { get; set; }
        public AppUser ModifierUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
