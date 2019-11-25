using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Web.Builder.ConcreteBuilder;
using Web.Builder.Director;
using Web.Builder.IBuilder;
using Web.Factory.AbstractFactory;
using Web.Models;

namespace Web.Controllers
{
    public class EmployeesController : Controller
    {
        private EmployeePortalEntities db = new EmployeePortalEntities();

        [HttpGet]
        public ActionResult BuildSystem(int? employeeID)
        {
            Employee employee = db.Employee.Find(employeeID);
            if (employee.ComputerDetails.Contains("Laptop"))
                return View("BuildLaptop", employeeID);
            else
                return View("BuildDesktop", employeeID);
        }
        [HttpPost]
        public ActionResult BuildLaptop(FormCollection formCollection)
        {
            Employee employee = db.Employee.Find(Convert.ToInt32(formCollection["employeeID"]));

            //Concrete builder
            ISystemBuilder systemBuilder = new LaptopBuilder();

            //Director
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.BuildSystem(systemBuilder, formCollection);

            ComputerSystem computerSystem = systemBuilder.GetSystem();

            employee.SystemConfigurationDetails =
                string.Format("Ram: {0}, HDDSize: {1}, TouchS: {2}",
                computerSystem.RAM, computerSystem.HDDSize, computerSystem.TouchScreen);
            db.Entry(employee).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult BuildDesktop(FormCollection formCollection)
        {
            Employee employee = db.Employee.Find(Convert.ToInt32(formCollection["employeeID"]));

            //Concrete builder
            ISystemBuilder systemBuilder = new DesktopBuilder();

            //Director
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.BuildSystem(systemBuilder, formCollection);

            //return system
            ComputerSystem computerSystem = systemBuilder.GetSystem();

            employee.SystemConfigurationDetails =
                string.Format("Ram: {0}, HDDSize: {1}, Key: {2}, Mouse: {3}",
                computerSystem.RAM, computerSystem.HDDSize, computerSystem.Keyboard, computerSystem.Mouse);
            db.Entry(employee).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Index()
        {
            var employee = db.Employee.Include(e => e.Employee_Type);
            return View(employee.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeTypeId = new SelectList(db.Employee_Type, "Id", "EmployeeType");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,JobDescription,Number,Department,HourlyPay,Bonus,EmployeeTypeId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                Factory.FactoryMethod.BaseEmployeeFactory empFactory = new Factory.FactoryMethod.EmployeeManagerFactory().CreateFactory(employee);

                empFactory.ApplySalary();

                IComputerFactory computerFactory = new EmployeeSystemFactory().Create(employee);
                EmployeeSystemManager employeeSystemManager = new EmployeeSystemManager(computerFactory);
                employee.ComputerDetails = employeeSystemManager.GetSystemDetails();
                db.Employee.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeTypeId = new SelectList(db.Employee_Type, "Id", "EmployeeType", employee.EmployeeTypeId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeTypeId = new SelectList(db.Employee_Type, "Id", "EmployeeType", employee.EmployeeTypeId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,JobDescription,Number,Department,HourlyPay,Bonus,EmployeeTypeId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeTypeId = new SelectList(db.Employee_Type, "Id", "EmployeeType", employee.EmployeeTypeId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employee.Find(id);
            db.Employee.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
