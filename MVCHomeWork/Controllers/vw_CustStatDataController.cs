using MVCHomeWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCHomeWork.Controllers
{
    public class vw_CustStatDataController : Controller
    {
        private CustomerEntities db = new CustomerEntities();

        // GET: vw_CustStatData
        public ActionResult Index()
        {
            return View(db.vw_CustStatData.ToList());
        }
    }
}