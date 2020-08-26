using Hw4_27EFImageProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hw4_27EFImageProject.web.Models
{
    public class ViewImageViewModel
    {
        public Image Image { get; set; }
        public List<int> ImageIdsLiked = new List<int>();
    }
}
