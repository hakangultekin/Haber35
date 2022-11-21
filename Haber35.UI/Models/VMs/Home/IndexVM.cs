using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber35.UI.Models.VMs.Home
{
    public class IndexVM
    {
        public List<ArticleVM> Populars { get; set; }
        public List<ArticleVM> Recents { get; set; }
        public List<ArticleVM> Sport { get; set; }
        public List<ArticleVM> Technology { get; set; }

    }
}

