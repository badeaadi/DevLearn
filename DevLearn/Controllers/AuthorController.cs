using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestsData;

namespace Reactnet.Controllers
{

    [ApiController]
    [Route("authors")]
    public class AuthorController : Controller
    {

        private readonly TestsDataContext DbContext = new TestsDataContext();
        [HttpGet]
        public ActionResult Get()
        {

            var authors = DbContext.Author.ToList();
            return Ok(authors);
        }
    }
}
