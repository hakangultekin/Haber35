using Haber35.CORE.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber35.CORE.Interfaces
{
    public interface IDeleteable
    {
        public string DeletoryUserId { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
