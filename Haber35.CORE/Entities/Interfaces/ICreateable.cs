using Haber35.CORE.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber35.CORE.Interfaces
{
    public interface ICreateable
    {
        public string CreatorUserId { get; set; }
        public AppUser CreatorUser { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
