﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TwitterClone.UI.Models;
using TwitterClone.BusinessLayer;
using TwitterClone.DataLayer;
using TwitterClone.DataLayer.Models;

namespace TwitterClone.UI.Controllers
{
    public class UserController : Controller
    {
        UserBL obj = new UserBL();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(PersonVM item)
        {
            if (ModelState.IsValid)
            {
                Person p = new Person()
                {
                    UserId = item.UserId,
                    Password = item.Pwd,
                    Email = item.Email,
                    FullName = item.Name,
                    Active = true,
                    Joined = DateTime.Now
                };
                obj.AddUser(p);
                return RedirectToAction("Login");

            }
            else
                return View();
        }
        public ViewResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string uname, string pwd)
        {
            Person p = obj.Validate(uname, pwd);
            if (p != null)
            {
                return RedirectToAction("Details", p);
            }
            else
            {
                TempData["err"] = "Invalid Login Details";
                return View();
            }
        }
        public ViewResult Details(Person p)
        {
            return View(p);
        }

    }
}