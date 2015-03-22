namespace LibraryAPI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using LibraryAPI.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<LibraryAPI.Models.LibraryAPIContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LibraryAPI.Models.LibraryAPIContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Autors.AddOrUpdate(x => x.id,
              new Autor() { id = 1, name = "Paulo Coelho", año = 1947, bio = "Paulo Coelho de Souza es un novelista, dramaturgo y letrista brasileño. Es uno de los escritores más leídos del mundo con más de 150 millones de libros vendidos en más de 150 países, traducidos a 80 lenguas." },
              new Autor() { id = 2, name = "Margaret Stohl", año = 1967, bio = "Margaret Stohl was born in Pasadena, California in 1967. She is the co-author, along with her friend Kami Garcia of the 'Caster Chronicles' book series, starting with Beautiful Creatures. " },
              new Autor() { id = 3, name = "Stephen King", año = 1947, bio = "Stephen Edwin King es un escritor estadounidense conocido por sus novelas de terror. Los libros de King han estado muy a menudo en las listas de superventas." }
           );

            context.Categorias.AddOrUpdate(x => x.id,
               new Categoria() { id = 1, name = "Reflexion", descripcion = "Te hace Reflaccionar" },
               new Categoria() { id = 2, name = "Fantasia", descripcion = "Te hace soñar" },
               new Categoria() { id = 3, name = "Terror", descripcion = "Te hacer llorar de miedo" }
            );

            context.Books.AddOrUpdate(x => x.id,
                new Book() { id = 1, titulo = "El Alquimista", año = 1988, autorId = 1, precio = 9.99M, categoriaId = 1 },
                new Book() { id = 2, titulo = "Hermosas Creaturas", año = 2008, autorId = 2, precio = 20.99M, categoriaId = 2 },
                new Book() { id = 3, titulo = "La cupula", año = 2004, autorId = 3, precio = 19.99M, categoriaId = 3 }
            );
        }
    }
}
