using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryAPI.Models
{
    public class BookDTO
    {
        public int id { get; set; }
        public string titulo { get; set; }
        public string autorName { get; set; }
        public string categoriaName { get; set; }
    }
}