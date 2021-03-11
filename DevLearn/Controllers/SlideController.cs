using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestsData;
using DevLearn.DatabaseContext;
using DevLearn.Data;
using DevLearn.Models;

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

            var slides = DbContext.Slides.ToList();
            return Ok(slides);
        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult GetById(int id)
        {

            var slide = DbContext.Slides.FirstOrDefault(a => a.IdSlide == id);
            return Ok(slide);
        }


        [HttpPost]
        public ActionResult PostSlide(SlideData slideData)
        {
            var slide = new Slide
            {
                Title = slideData.Title,
                Description = slideData.Description,
                LectureIdLecture = slideData.LectureId
            };

            DbContext.Add(slide);
            DbContext.SaveChanges();

            return Ok("Slide added");
        }
    }
}
