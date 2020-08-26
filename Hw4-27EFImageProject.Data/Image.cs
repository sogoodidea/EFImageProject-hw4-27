using System;
using System.Collections.Generic;
using System.Text;

namespace Hw4_27EFImageProject.Data
{
    public class Image
    {
        public int Id { get; set; }
        public string URL { get; set; }
        public string Title { get; set; }
        public DateTime DateUploaded { get; set; }
        public int Likes { get; set; }
    }
}
