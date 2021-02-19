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

       

    }
}
