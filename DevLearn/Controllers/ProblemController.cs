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
    [Route("problems")]
    public class ProblemController : Controller

    {

        private readonly TestsDataContext DbContext = new TestsDataContext();
        
        [Route("{id}")]
        [HttpGet]
        public ActionResult Get(int id)
        {
            var problem = DbContext.Problems.FirstOrDefault(g => g.IdProblem == id);
            return Ok(problem);
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var problems = DbContext.Problems.ToList();
            return Ok(problems);
        }
        [HttpPost]
        public ActionResult AddProblem([FromBody] ProblemData problemData)
        {

            var problem = new Problem
            {
                Link = problemData.ProblemLink,
                Dificultate = problemData.ProblemDifficulty
            };

            DbContext.Add(problem);
            DbContext.SaveChanges();

            return Ok("Problem added");
        }
        [Route("{id}")]
        [HttpPut]
        public ActionResult UpdateProblem(int id, [FromBody] ProblemData problemData)
        {
            var problem = DbContext.Problems.FirstOrDefault(g => g.IdProblem == id);

            problem.Link = problemData.ProblemLink;
            problem.Dificultate = problemData.ProblemDifficulty;
            
            DbContext.SaveChanges();

            return Ok("Problem information changed");
        }
    }
}
