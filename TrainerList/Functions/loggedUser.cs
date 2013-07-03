using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainerList.Functions
{
    public static class loggedUser
    {

        public static string get_id() 
        { 
            Models.UserModel _loggedUser = (Models.UserModel)HttpContext.Current.Session["loggedUser"]; 
            return _loggedUser._id;
        }

        public static string get_rev()
        { 
            Models.UserModel _loggedUser = (Models.UserModel)HttpContext.Current.Session["loggedUser"]; 
            return _loggedUser._rev;
        }

        public static string get_username() 
        { 
            Models.UserModel _loggedUser = (Models.UserModel)HttpContext.Current.Session["loggedUser"];
            return _loggedUser.UserName;
        }



    }
}