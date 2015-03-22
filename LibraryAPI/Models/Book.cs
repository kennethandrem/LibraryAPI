using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models
{
    public class Book
    {
        public int id { get; set; }
        [Required]
        public string titulo { get; set; }
        public int año { get; set; }
        public decimal precio { get; set; }

        // Foreign Key
        public int autorId { get; set; }
        // Navigation property
        public Autor Autor { get; set; }

        // Foreign Key
        public int categoriaId { get; set; }
        // Navigation property
        public Categoria Categoria { get; set; }
    }
}