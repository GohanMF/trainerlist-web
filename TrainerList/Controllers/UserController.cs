using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainerList.Models;

namespace TrainerList.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            UserModel user = new UserModel();
            user.GetUsers("/trainer");

            return View(user);
        }

        //
        // GET: /User/Details/5

        public ActionResult Details(string id)
        {

            UserModel user = new UserModel();
            user.GetUser("/trainer/" ,  id);

            return View(user);
        }

        //
        // GET: /User/Create2

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /User/Create

        [HttpPost]
        public ActionResult Create(UserModel User)
        {
            try
            {

                if (User.UserRegister("/trainer"))
                {
                    return Redirect("Home");
                }
                else
                {
                    return View("/user/Create" , User);
                }
                 
                
            }
            catch
            {
                return Redirect("Home");
            }
        }

        
        
        
        //
        // GET: /User/Edit/5

        public ActionResult Edit(string id)
        {

            UserModel user = new UserModel();
            user.GetUser("/trainer/" , id);

            return View(user);
            
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        public ActionResult Edit(string id, UserModel  user)
        {
            try
            {
                // TODO: Add update logic here
                if (user.UserSave("/trainer/" , id))
                {
                    return RedirectToAction("/Home/index");
                }
                else
                {
                    return View("/user/Create", User);
                }
                 
                
            }
            catch
            {
                return View();
            }
        }

    
    }
}
