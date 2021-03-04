using System.Linq;
using DevLearn.Data;
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

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetById(int id)
        {

            var lecture = DbContext.Lectures.FirstOrDefault(l => l.IdLecture == id);
            return Ok(lecture);
        }


        [Route("{id}")]
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var lecture = DbContext.Lectures.FirstOrDefault(g => g.IdLecture == id);

            if (lecture == null) {
                return Ok("Lecture deleted");
            }
                DbContext.Remove(lecture);

                DbContext.SaveChanges();

                return Ok("Lecture deleted");


         }
        [Route("{id}")]
        [HttpPost]
        public ActionResult Post([FromBody] LectureData lectureData)
        {
            var lecture = new Lecture
            {
                IdLecture = lectureData.IdLecture,
                Author = lectureData.Author,
                AddedDate = lectureData.AddedDate
            };

            DbContext.Add(lecture);
            DbContext.SaveChanges();

            return Ok(lecture);
        }
    }

}


