using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TPD.Presentation.Controllers
{
    public class SharedController : Controller
    {

        [ChildActionOnly]
        public ActionResult Header()
        {
            return PartialView("_LoginPartial");
        }
    }
}
