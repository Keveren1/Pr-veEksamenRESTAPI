using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using PrøveEksamenRESTAPI.Manager;
using PrøveEksamenRESTAPI.Models;

namespace PrøveEksamenRESTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestSitesController : Controller
    {
        private TestSitesManager _testSitesManager = new TestSitesManager();
        [EnableCors(Startup.AllowAllCorsPolicy)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public ActionResult<IEnumerable<TestSite>> GetAll([FromQuery] string? nameFilter,
            [FromQuery] int? waitingTimeFilter)
        {
            IEnumerable<TestSite>
                testSites = _testSitesManager.GetAll(nameFilter, waitingTimeFilter);
            if (!testSites.Any())
            {
                return NotFound("Dumb Fuck");
            }
            else
            {
                return Ok(testSites);
            }
        }

        // PUT api/<ItemsController>/5
        [HttpPut("{id}")]
        public TestSite Put(int id, [FromBody] TestSite value)
        {
            return _testSitesManager.Update(id, value);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            TestSite test = _testSitesManager.GetById(id);
            if (test == null) return NotFound("no such thing you big dumdum" + id);
            return Ok(test);
        }

        [HttpPost]
        public TestSite Post([FromBody] TestSite newTest)
        {
            return _testSitesManager.AddTestSite(newTest);
        }

        [HttpDelete("{id}")]
        public TestSite Delete(int id)
        {
            TestSite car = _testSitesManager.GetById(id);
            return _testSitesManager.DeleteTestSite(id);
        }

    }
}
