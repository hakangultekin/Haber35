using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber35.UI.Models.VMs.Category
{
    public class PassiveCategoryListVM
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}

