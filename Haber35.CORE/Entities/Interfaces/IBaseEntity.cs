using Haber35.CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber35.CORE.Entities.Interfaces
{
    public interface IBaseEntity : IEditable, IDeleteable
    {
        public bool Status { get; set; }
    }
}
