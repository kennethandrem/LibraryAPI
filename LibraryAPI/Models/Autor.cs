using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models
{
    public class Autor
    {
        public int id { get; set; }
        public string name { get; set; }
        public int año { get; set; }
        public string bio { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}