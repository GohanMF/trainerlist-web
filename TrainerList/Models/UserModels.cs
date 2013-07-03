using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;
using TrainerList.Functions;

namespace TrainerList.Models
{


    public class UserModel
    {
        public string _id { get; set; }
        public string _rev { get; set; }

        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        [DataType(DataType.Text)]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }

        [Required]
        [StringLength(20)]
        [DataType(DataType.Text)]
        [Display(Name = "First Name")]
        public string firstName { get; set; }


        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }


        public Boolean UserSave()
        {
            string path = "/trainer/";

            NameValueCollection reqparm = new NameValueCollection();
            reqparm.Add("_id", _id);
            reqparm.Add("_rev", _rev);
            reqparm.Add("email", Email);
            reqparm.Add("username", UserName);
            reqparm.Add("firstName", firstName);
            reqparm.Add("lastName", lastName);
            String Response = ServerComunication.DoPost(path + _id, reqparm);
            


            return true;


        }


        public Boolean UserRegister()
        {
            string path = "/trainer";
            try
            {
                NameValueCollection reqparm = new NameValueCollection();

                reqparm.Add("email", Email);
                reqparm.Add("username", UserName);
                reqparm.Add("password", Password);
                reqparm.Add("firstName", firstName);
                reqparm.Add("lastName", lastName);
                String Response = ServerComunication.DoPost(path, reqparm);
                JObject myjObject = JObject.Parse(Response);

                return Parse(myjObject);
            }
            catch (Exception ex)
            {
                
                string message = ex.Message;
                return false;
            } 

        }

        public Boolean UserChangePassword(string path)
        {


            NameValueCollection reqparm = new NameValueCollection();

     
            // reqparm.Add("password", Password);
            reqparm.Add("firstName", firstName);
            reqparm.Add("lastName", lastName);
            String Response = ServerComunication.DoPost(path, reqparm);



            return true;


        }


        public bool GetUser(string id) {
            string path = "/trainer/";
            try {
              return  Parse(ServerComunication.DoGet(path + id));

            }catch(Exception ex){
                return false;
            }
        }


        public void GetUsers(string path)
        {

            Parse(ServerComunication.DoGet(path));

        }

        public bool UserDelete(string id)
        {
            string path = "/trainer/" + id + "/delete";
            NameValueCollection reqparm = new NameValueCollection();
            ServerComunication.DoPost(path, reqparm);
            return true;

        }
  


        public Boolean Parse(JObject jObject)
        {
            try
            {
                _id = (String)jObject["_id"];
                _rev = (String)jObject["_rev"];
                Email = (String)jObject["email"];
                UserName = (String)jObject["username"];
                firstName = (String)jObject["firstName"];
                lastName = (String)jObject["lastName"];
                 
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }



        public Boolean parsemulti(JObject jObject)
        {

            try
            {


                _id = (String)jObject["_id"];
                _rev = (String)jObject["_rev"];
                Email = (String)jObject["email"];
                UserName = (String)jObject["username"];
                firstName = (String)jObject["firstName"];
                lastName = (String)jObject["lastName"];



               return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        
        }

        
              

    }



    public class UserLogin {

        public  string _id { get; private set; }

        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }


        public bool isValid(string validate_username, string validate_password, bool rememberMe)
        {

            UserModel UserOnline = new UserModel();

            FakeUser accessfakeuser = new FakeUser();

            JObject user;

            user = accessfakeuser.my_fake_login(validate_username, validate_password);
            try
            {

                if (user == null)
                {

                    return false;

                }
                else
                {
                    UserModel loggedUser = new UserModel();
                    loggedUser.Parse(user);
                    _id = loggedUser._id;
                    CreateCookie(loggedUser, rememberMe);
                    HttpContext.Current.Session.Add("loggedUser", loggedUser);
                    return true;

                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void CreateCookie(UserModel user , bool rememberMe ) {

            var serializer = new JavaScriptSerializer();
            string userData = serializer.Serialize(user);

            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, user.UserName, DateTime.Now, DateTime.Now.AddYears(1), rememberMe, userData);
            string encryptedTicket = FormsAuthentication.Encrypt(ticket);

            HttpCookie mycookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            if (ticket.IsPersistent)
            {
                mycookie.Expires = ticket.Expiration;
                mycookie.HttpOnly = true;
            }
            HttpContext.Current.Response.Cookies.Add(mycookie);
        } 
    } 
}