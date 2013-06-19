using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
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
            user.GetUser("/trainer/", id);

            return View(user);
        }

        //
        // GET: /User/Create2

        public ActionResult New()
        {
            return View();
        }

        //
        // POST: /User/Create

        [HttpPost]
        [AllowAnonymous]
        public ActionResult New(UserModel User)
        {
            try
            {

                if (User.UserRegister("/trainer"))
                {
                    return Redirect("Home");
                }
                else
                {
                    return View(User);
                }


            }
            catch
            {
                return Redirect("Home");
            }
        }




        //
        // GET: /User/Edit/5

        [AllowAnonymous]
        public ActionResult Edit(string id)
        {

            UserModel user = new UserModel();
            user.GetUser("/trainer/", id);

            return View(user);

        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Edit(string id, UserModel user)
        {
            try
            {
                // TODO: Add update logic here
                if (user.UserSave("/trainer/"))
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


        // GET: /user/Login

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();    
                
         }
        


        // POST: /User/Login

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin user)
        {
            if (ModelState.IsValid)
            {

                if (user.isValid(user.UserName, user.Password))
                {

                    FormsAuthentication.SetAuthCookie(user.UserName, user.RememberMe);
                    return Redirect("/Home/index");
                }
              
                
            }
          

                ModelState.AddModelError("Erro", "Forget the password ? want to recover it ? no cant do ... do a new regiter we need items");
                return View(user);
            

        }

        // POST LOGOFF
        
        
        public ActionResult LogOff()
        {

            FormsAuthentication.SignOut();
            

            return Redirect("/Home/index");
        }



        [HttpGet]
        public ActionResult Delete()
        {
            UserModel User = new UserModel(); 
            User = (UserModel)Session["loggedUser"];
            FormsAuthentication.SignOut();
            User.UserDelete("/trainer/" + User._id + "/delete");
            return Redirect("Home/index");
        }
           


    }
}
