using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestsData;
using DevLearn.DatabaseContext;

namespace DevLearn.Controllers
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
        [HttpGet]
        [Route("{id}")]
        public ActionResult GetById(int id)
        {

            var slide = DbContext.Slide.FirstOrDefault(a => a.IdSlide == id);
            return Ok(slide);
        }
    }
}
