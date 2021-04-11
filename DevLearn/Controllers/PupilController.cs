using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevLearn.Data;
using DevLearn.DatabaseContext;
using DevLearn.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevLearn.Controllers
{
    [ApiController]
    [Route("pupils")]
    public class PupilController : Controller
    {

        private readonly TestsDataContext DbContext = new TestsDataContext();
        [HttpGet]
        [Route("{username}")]
        public ActionResult GetByUsername(String username)
        {


            var pupil = DbContext.Pupils.FirstOrDefault(p => p.Username == username);
            if (pupil == null)
                return NotFound("Username not found");

            return Ok(pupil);
        }

        [HttpPost]
        public ActionResult PostUsername([FromBody] PupilData pupilData)
        {

            var pupil = new Pupil
            {
                Username = pupilData.Username,
                Password = pupilData.Password,
                SolvedProblems = 0
            };

            DbContext.Add(pupil);
            DbContext.SaveChanges();

            return Ok("User registered");
        }

    }
}
