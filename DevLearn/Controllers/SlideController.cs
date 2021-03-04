using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestsData;

namespace Reactnet.Controllers
{

    [ApiController]
    [Route("slides")]
    public class SlideController : Controller
    {
        private readonly TestsDataContext DbContext = new TestsDataContext();

        [HttpGet]
        public ActionResult Get()
        {

            var slides = DbContext.Slide.ToList();
            return Ok(slides);
        }

    }
}
