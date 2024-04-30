using Employee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Employee.Controllers
{
    public class EmployeeController : Controller
    {
        employeeEntities db = new employeeEntities();
        // GET: Employee
        public ActionResult Index()
        {
            var lst = db.employees.ToList();
            return View(lst);
        }
        public ActionResult search(string searching)
        {
            return View(db.employees.Where(x=>x.Name.Contains(searching)||searching==null).ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(employee  modal)
        {
            db.employees.Add(modal);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            employee edt = db.employees.Where(x => x.id == id).FirstOrDefault();
            return View(edt);
        }
        [HttpPost]
        public ActionResult Edit(employee modal)
        {
            employee edt = db.employees.Where(x => x.id == modal.id).FirstOrDefault();
           

            edt.Name = modal.Name;
            edt.Age = modal.Age;
            edt.Phone = modal.Phone;
            edt.Discription = modal.Discription;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Delete(int id)
        {
            employee dlt = db.employees.Where(x => x.id == id).FirstOrDefault();
            db.employees.Remove(dlt);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            employee edt = db.employees.Where(x => x.id == id).FirstOrDefault();
            return View(edt);
        }
    }
}