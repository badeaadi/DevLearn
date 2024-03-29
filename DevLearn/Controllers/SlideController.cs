﻿using System.Linq;
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

        [Route("{id}")]
        [HttpPut]
        public ActionResult ChangeDescription(int id, [FromBody] SlideData slideData)
        {
            var slide = DbContext.Slides.FirstOrDefault(s => s.IdSlide == id);
            slide.Title = slideData.Title;
            slide.Description = slideData.Description;

            DbContext.SaveChanges();
            return Ok("Lecture changed");
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

        [Route("{id}")]
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var slide = DbContext.Slides.FirstOrDefault(g => g.IdSlide == id);

            if (slide == null)
            {
                return Ok("Slide deleted");
            }
            DbContext.Remove(slide);

            DbContext.SaveChanges();

            return Ok("Slide deleted");
        }
    }
}
