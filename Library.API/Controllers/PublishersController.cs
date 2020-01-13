using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.API.Models;
using Library.dal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : BaseController
    {
        //protected UnitOfWork unit = new UnitOfWork();
        //protected ModelFactory factory= new ModelFactory();

        [HttpGet]
        public IActionResult Get() //ova metoda je direktno adresirana sa rute api/Publishers; ne mora se zvati get, moze i drugacije, prepoznat ce
        {
            return Ok(Unit.Books.Get().Include(x=>x.Publisher));
            //return Ok(Unit.Publishers.Get().Select(x => Factory.Create(x)).ToList());
        }

        [Route("{id}")]
        [HttpGet]
        public ActionResult Get(int id)
        {
            try
            {
                Publisher publisher = Unit.Publishers.Get(id);
                if (publisher == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(publisher);
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
        // POST: api/Publishers
        [HttpPost]
        public ActionResult Post([FromBody] Publisher publisher)
        {
            try
            {
                Unit.Publishers.Insert(publisher);
                Unit.Save();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT: api/Publishers/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Publisher publisher)
        {
            try
            {
                Unit.Publishers.Update(publisher, id);
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
                Publisher publisher = Unit.Publishers.Get(id);
                if (publisher == null)
                {
                    return NotFound();
                }
                else
                {
                    Unit.Publishers.Delete(publisher);
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