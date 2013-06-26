

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;
using TrainerList.Models;

namespace TrainerList
{
    public class authRequest
    {
        public static void my_AuthenticateRequest()
        {
            HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                // Get the forms authentication ticket.
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                var identity = new GenericIdentity(authTicket.Name, "Forms");

                // Get the custom user data encrypted in the ticket.
                string userData = ((FormsIdentity)(HttpContext.Current.User.Identity)).Ticket.UserData;

                // Deserialize the json data and set it on the custom principal.
                var serializer = new JavaScriptSerializer();
                UserModel loginUser = (UserModel)serializer.Deserialize(userData, typeof(UserModel));

                UserModel loggedUser = new UserModel();
                loggedUser.GetUser(loginUser._id);

                HttpContext.Current.Session.Add("loggedUser", loggedUser);
                // Set the context user.
               
            }
        }
    }
}