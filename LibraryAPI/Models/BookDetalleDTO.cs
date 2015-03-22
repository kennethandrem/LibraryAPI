using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryAPI.Models
{
    public class BookDetalleDTO
    {
        public int id { get; set; }
        public string titulo { get; set; }
        public int año { get; set; }
        public decimal precio { get; set; }
        public string autorName { get; set; }
        public string categoriaNombre { get; set; }
    }
}