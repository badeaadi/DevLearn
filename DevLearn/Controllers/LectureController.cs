using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestsData;

namespace Reactnet.Controllers
{
    [ApiController]
    [Route("lectures")]
    public class LectureController : Controller
    {
        private readonly TestsDataContext DbContext = new TestsDataContext();

        [HttpGet]
        public ActionResult Get()
        {

            var lectures = DbContext.Lectures.ToList();
            return Ok(lectures);
        }

    }
}
