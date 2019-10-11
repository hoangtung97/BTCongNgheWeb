using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Tutorial.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            var employee = from e in UserDatabase.Users
                           orderby e.ID
                           select e;
            return View(employee);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(/*FormCollection collection*/ Models.Users user)
        {
            try
            {
                // TODO: Add insert logic here
                /*Models.Employee employee = new Models.Employee();
                employee.Name = collection["Name"];
                DateTime jDate;
                DateTime.TryParse(collection["joinDate"], out jDate);
                employee.joinDate = jDate;
                string age = collection["Age"];
                employee.Age = Int32.Parse(age);*/
                UserDatabase.Users.Add(user);
                UserDatabase.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(string userName)
        {
            //List<Models.Employee> employeeList = GetEmployeeList();
            var user = UserDatabase.Users.Single(m => m.ID == userName );
            return View( user );
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(string userName, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                var user = UserDatabase.Users.Single(m => m.ID == userName );
                if(TryUpdateModel(user))
                {
                    UserDatabase.SaveChanges();
                    return RedirectToAction("Index");
                }
                //return RedirectToAction("Index");
                return View(user);
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        /*public static List<MVC_Tutorial.Models.Users> employeeList = new List<Models.Users>
        {
                new Models.Users
                {
                    ID = 1,
                    Name = "Trần Dần",
                    Age = 58,
                    joinDate = DateTime.Parse(DateTime.Today.ToShortDateString())
                },

                new Models.Users
                {
                    ID = 2,
                    Name = "Tiên tri vũ trụ",
                    Age = 1000,
                    joinDate = DateTime.Parse(DateTime.Now.ToShortDateString())
                }
        };*/

        private Models.UserDBContext UserDatabase = new Models.UserDBContext();

    }
}
