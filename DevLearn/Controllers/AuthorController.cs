using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using DevLearn.DatabaseContext;
using DevLearn.Data;
using DevLearn.Models;
using Microsoft.EntityFrameworkCore;

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

            var authors = DbContext.Authors.ToList();
            return Ok(authors);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetById(int id)
        {

            var author = DbContext.Authors.FirstOrDefault(a => a.IdAuthor == id);

            return Ok(author);
        }


        [HttpPost]
        public ActionResult Post([FromBody] AuthorData authorData)
        {
            var author = new Author
            {
                FirstName = authorData.FirstName,
                LastName = authorData.LastName
            };

            DbContext.Add(author);
            DbContext.SaveChanges();

            return Ok("Author added");
        }

    }

}
