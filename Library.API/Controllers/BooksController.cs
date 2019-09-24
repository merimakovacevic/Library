using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.dal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Controllers
{//prekopirano iz publishers, promijeniti za books
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : BaseController
    {
        //protected UnitOfWork unit = new UnitOfWork();
        //protected ModelFactory factory= new ModelFactory();

        [HttpGet]
        public IActionResult Get() //ova metoda je direktno adresirana sa rute api/Publishers; ne mora se zvati get, moze i drugacije, prepoznat ce
        {
            return Ok(Unit.Books.Get().Include(x=>x.Publisher).ToList());
        }

        [Route("{id}")]
        [HttpGet]
        public ActionResult Get(int id)
        {
            try
            {
                Book book = Unit.Books.Get().FirstOrDefault(x=>x.Id==id);
                if (book == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(book);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        // POST: api/Publishers
        [HttpPost]
        public ActionResult Post([FromBody] Book book)
        {
            try
            {
                book.Publisher = Unit.Publishers.Get(book.Publisher.Id);
                Unit.Books.Insert(book);
                Unit.Save();
                return Ok(book);
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT: api/Publishers/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Book book)
        {
            try
            {
                book.Publisher = Unit.Publishers.Get(book.Publisher.Id);
                //OVDJE FALI LINIJA KODA
                Unit.Books.Update(book, id);
                Unit.Save();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                Book book = Unit.Books.Get(id);
                if (book == null)
                {
                    return NotFound();
                }
                else
                {
                    Unit.Books.Delete(book);
                    Unit.Save();
                    return NoContent();
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
    }
}