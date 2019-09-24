using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.dal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        protected UnitOfWork unit = new UnitOfWork();

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(unit.Authors.Get().ToList());
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                Author author = unit.Authors.Get(id);
                if (author == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(author);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        // POST: api/Authors
        [HttpPost]
        public ActionResult Post([FromBody] Author author)
        {
            try
            {
                unit.Authors.Insert(author);
                unit.Save();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT: api/Authors/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Author author)
        {
            try
            {
                unit.Authors.Update(author, id);
                unit.Save();
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
                Author author = unit.Authors.Get(id);
                if (author == null)
                {
                    return NotFound();
                }
                else
                {
                    unit.Authors.Delete(author);
                    unit.Save();
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