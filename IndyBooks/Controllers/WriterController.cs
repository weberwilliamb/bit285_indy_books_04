using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IndyBooks.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IndyBooks.Controllers
{
    [Route("api/[controller]")]
    public class WriterController : Controller
    {
        private IndyBooksDataContext _db;
        public WriterController(IndyBooksDataContext db) { _db = db; }
        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            return Json (_db.Writers);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            Writer writer = _db.Writers.Find(id);

            if (writer != null)
                return Json(writer);

            return NotFound ();            
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]Writer w)
        {
            _db.Writers.Add(w);
            _db.SaveChanges();
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody]Writer w)
        {
            Writer writer = _db.Writers.Find(id);
            if (writer != null)
            {
                writer.Name = w.Name;
                _db.Writers.Update(writer);
                _db.SaveChanges();
                return (Ok());
            }
            return NotFound();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
