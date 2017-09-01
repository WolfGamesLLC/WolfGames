using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WGCodeLanguageAPI.System.Collections.Generic;

namespace WGMicrosoftAPITest.Controllers
{
    [Produces("application/json")]
    [Route("api/TestList")]
    public class TestListController : Controller
    {
        private WGGenericCollectionsFactory wGGenericCollectionsFactory;

        public TestListController(WGGenericCollectionsFactory collectionsFactory)
        {
            wGGenericCollectionsFactory = collectionsFactory;
        }

        // GET: api/TestList
        [HttpGet]
        public IEnumerable<string> Get()
        {
            IList<string> data = wGGenericCollectionsFactory.CreateList<string>();
            data.Add("Key");
            data.Add("Value");

            return (IEnumerable<string>)data;
//            return new string[] { "value1", "value2" };
        }

        // GET: api/TestList/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/TestList
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/TestList/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
