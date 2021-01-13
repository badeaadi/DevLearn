using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestsData;

namespace Reactnet.Controllers
{
    public class LectureController : Controller
    {
        private readonly TestsDataContext DbContext = new TestsDataContext();

        // GET: LectureController
        public ActionResult Index()
        {
            var lectures = DbContext.Lectures.Include(u => u.IdLecture).ToList();
            return Ok(lectures);
        }

        // GET: LectureController/Details/5
        public ActionResult Details(int id)
        {

            var lectures = DbContext.Lectures.Include(u => u.IdLecture).ToList();
            return Ok(lectures);
        }

        // GET: LectureController/Create
        public ActionResult Create()
        {
            return View();
        }

    }
}
