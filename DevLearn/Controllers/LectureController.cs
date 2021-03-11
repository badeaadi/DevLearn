using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;

using DevLearn.DatabaseContext;
using DevLearn.Data;
using DevLearn.Models;

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

            var lectures = DbContext.Lectures.Include(l => l.Author).Include(l => l.Problems).Include(l => l.Slides).ToList();
            return Ok(lectures);
        }


        [HttpGet]
        [Route("{id}")]
        public ActionResult GetById(int id)
        {

            var lecture = DbContext.Lectures.Include(l => l.Author).Include(l => l.Slides).FirstOrDefault(l => l.IdLecture == id);

            return Ok(lecture);
        }


        [HttpGet]
        [Route("slides{id}")]
        public ActionResult GetByLectureId(int id)
        {

            var slides = DbContext.Lectures.Include(l => l.Slides).FirstOrDefault(g => g.IdLecture == id).Slides;
            return Ok(slides);
        }


        [Route("{id}")]
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var lecture = DbContext.Lectures.FirstOrDefault(g => g.IdLecture == id);

            if (lecture == null)
            {
                return Ok("Lecture deleted");
            }
            DbContext.Remove(lecture);

            DbContext.SaveChanges();

            return Ok("Lecture deleted");


        }
        [Route("{id}")]
        [HttpPut]
        public ActionResult Put(int id, [FromBody] LectureData lectureData)
        {
            var lecture = DbContext.Lectures.Include(l => l.Author).Include(l => l.Slides).Include(l => l.Problems).FirstOrDefault(l => l.IdLecture == id);
            lecture.Author = DbContext.Authors.FirstOrDefault(g => g.IdAuthor == lectureData.AuthorId);
            DbContext.SaveChanges();

            return Ok("Lecture changed");
        }

        [HttpPost]
        public ActionResult Post([FromBody] LectureData lectureData)
        {

            Author author = DbContext.Authors.FirstOrDefault(g => g.IdAuthor == lectureData.AuthorId);
            if (author == null)
                return NotFound("Author not found");


            var lecture = new Lecture
            {   
                Author = DbContext.Authors.FirstOrDefault(g => g.IdAuthor == lectureData.AuthorId),
                LectureTitle = lectureData.LectureTitle,
                AddedDate = DateTime.Now
            };
            

            DbContext.Add(lecture);
            DbContext.SaveChanges();

            return Ok("Lecture added");
        }


        
    }

}


