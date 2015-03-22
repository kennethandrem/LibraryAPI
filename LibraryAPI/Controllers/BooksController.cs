using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using LibraryAPI.Models;

namespace LibraryAPI.Controllers
{
    public class BooksController : ApiController
    {
        private LibraryAPIContext db = new LibraryAPIContext();

        // GET api/Books
        public IQueryable<BookDTO> GetBooks()
        {
            var books = from b in db.Books
                        select new BookDTO()
                        {
                            id = b.id,
                            titulo = b.titulo,
                            autorName = b.Autor.name,
                            categoriaName = b.Categoria.name
                        };

            return books;
        }

        // GET api/Books/5
        [ResponseType(typeof(BookDetalleDTO))]
        public async Task<IHttpActionResult> GetBook(int id)
        {
            var book = await db.Books.Include(b => b.Autor).Select(b =>
                new BookDetalleDTO()
                {
                    id = b.id,
                    titulo = b.titulo,
                    año = b.año,
                    precio = b.precio,
                    autorName = b.Autor.name,
                    categoriaNombre = b.Categoria.name
                }).SingleOrDefaultAsync(b => b.id == id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        // PUT api/Books/5
        public async Task<IHttpActionResult> PutBook(int id, Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != book.id)
            {
                return BadRequest();
            }

            db.Entry(book).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Books
        [ResponseType(typeof(Book))]
        public async Task<IHttpActionResult> PostBook(Book book)
        {
            /*if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            */
            db.Books.Add(book);
            await db.SaveChangesAsync();

            // New code:
            // Load author name
            db.Entry(book).Reference(x => x.Autor).Load();

            var dto = new BookDTO()
            {
                id = book.id,
                titulo = book.titulo,
                autorName = book.Autor.name,
                categoriaName = book.Categoria.name
            };

            return CreatedAtRoute("DefaultApi", new { id = book.id }, dto);
        }

        // DELETE api/Books/5
        [ResponseType(typeof(Book))]
        public async Task<IHttpActionResult> DeleteBook(int id)
        {
            Book book = await db.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            db.Books.Remove(book);
            await db.SaveChangesAsync();

            return Ok(book);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookExists(int id)
        {
            return db.Books.Count(e => e.id == id) > 0;
        }
    }
}