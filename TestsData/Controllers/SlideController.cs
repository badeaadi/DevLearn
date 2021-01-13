using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestsData;

namespace Reactnet.Controllers
{
    public class SlideController : Controller
    {
        private readonly TestsDataContext DbContext = new TestsDataContext();

        // GET: LectureController
        /*
        public ActionResult Index()
        {
            //var slides = DbContext.Slide.Include(u => u.IdLecture).ToList();
            //return Ok(slides);
        }

        // GET: LectureController/Details/5
        public ActionResult Details(int id)
        {
            //var slide = DbContext.Slide.Include(u => u.Information).ToList();
           //return Ok(slide);
        }

        // GET: LectureController/Create
        public ActionResult Create()
        {
            return View();
        }*/

    }
}
