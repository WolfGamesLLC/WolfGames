using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WolfGamesSite.DAL.Models.SimpleGameModels;
using WolfGamesSite.DAL.Data;

namespace WolfGamesSite.API.Controllers
{
    /// <summary>
    /// Controller for the Marble Motion table
    /// </summary>
    [Route("api/[controller]")]
    public class MarbleMotionController : Controller
    {
        private readonly MarbleMotionDBContext _context;

        /// <summary>
        /// Default contructor for the MarbleMotion API controller 
        /// </summary>
        /// <param name="context">The marble motion db context</param>
        public MarbleMotionController(MarbleMotionDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// The basic read operation of all the records
        /// </summary>
        /// <returns>the list of all the records</returns>
        // GET api/MarbleMotion
        [HttpGet]
        public IEnumerable<MarbleMotion> Get()
        {
            return _context.MarbleMotionRecords.ToList();
        }

        /// <summary>
        /// The basic read operation of a single record
        /// </summary>
        /// <param name="id">The record id to be retrieved</param>
        /// <returns>the requested record</returns>
        // GET api/MarbleMotion/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = _context.MarbleMotionRecords.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        /// <summary>
        /// The basic create operation
        /// </summary>
        /// <param name="value">the record to create</param>
        // POST api/MarbleMotion
        [HttpPost]
        public void Post([FromBody]string value)
        {
            var a = 1;
        }

        /// <summary>
        /// The basic update operation
        /// </summary>
        /// <param name="id">the id of the record to be updated</param>
        /// <param name="value">the new record values</param>
        // PUT api/MarbleMotion/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        /// <summary>
        /// The basic delete operation
        /// </summary>
        /// <param name="id">the id of the record to be deleted</param>
        // DELETE api/MarbleMotion/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
