﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;

namespace WebChat.Controllers
{
    public class AssignmentController : Controller
    {
        Models.ChatWebsiteEntities database = new Models.ChatWebsiteEntities();
        // GET: Assignment
        public ActionResult Index()
        {
            var users = from user in database.Users
                        select user;
            return View( users );
        }

        // GET: Assignment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Assignment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Assignment/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Assignment/Edit/5
        public ActionResult Edit(int id)
        {
            List<Models.User> userList = DbModuls.DbGet.getUserList();

            var user = userList.Single(m => m.UserID == id);
            return View( user );
        }

        // POST: Assignment/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var user = database.Users.Single(m => m.UserID == id);

                // TODO: Add update logic here
                user.Username = Request["username"];
                user.DisplayName = Request["displayname"];
                user.Password_ = Request["password_"];

                //Debug.WriteLine(Request["password"]);

                database.SaveChanges();

                return RedirectToAction("Index");
            }
            catch( Exception e )
            {
                Debug.WriteLine(e.StackTrace);
                return View();
            }
        }

        // GET: Assignment/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Assignment/Delete/5
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
    }
}
