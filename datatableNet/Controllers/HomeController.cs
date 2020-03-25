using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace datatableNet.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            using (CRUDDbContext db = new CRUDDbContext())
            {
                List<Employee> employees = db.Employees.ToList<Employee>();
                return Json(new { data = employees },JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            return View(new Employee());
        }

        [HttpPost]
        public ActionResult AddOrEdit()
        {
            return View();
        }
        public ActionResult Kendo()
        {
            return View();
        }
        public JsonResult ListStudent()
        {
            using (CRUDDbContext db = new CRUDDbContext())
            {
                
                return Json(db.Employees.ToList(), JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult StudentByID(int? id)
        {
            using (CRUDDbContext db = new CRUDDbContext())
            {
                return Json(db.Employees.Where(x=>x.EmployeeID == id).ToList(), JsonRequestBehavior.AllowGet);
            }
        }
    }
}