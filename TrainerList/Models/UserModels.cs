﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Specialized;
using TrainerList.Functions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;

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

  
        public Boolean UserSave( string path , string id )
        {


            NameValueCollection reqparm = new NameValueCollection();
            reqparm.Add("_id", _id);
            reqparm.Add("_rev", _rev);
            reqparm.Add("email", Email);
            reqparm.Add("username", UserName);
            reqparm.Add("firstName", firstName);
            reqparm.Add("lastName", lastName);
            ServerComunication Server = new ServerComunication();
            String Response = Server.DoPost(path +id , reqparm);
            Console.WriteLine(Response);


            return true;


        }


        public Boolean UserRegister(string path)
        {


            NameValueCollection reqparm = new NameValueCollection();

            reqparm.Add("email", Email);
            reqparm.Add("username", UserName);
            // reqparm.Add("password", Password);
            reqparm.Add("firstName", firstName);
            reqparm.Add("lastName", lastName);
            ServerComunication Server = new ServerComunication();
            String Response = Server.DoPost( path, reqparm);
            
            return true;


        }

        public Boolean UserChangePassword(string path)
        {


            NameValueCollection reqparm = new NameValueCollection();

     
            // reqparm.Add("password", Password);
            reqparm.Add("firstName", firstName);
            reqparm.Add("lastName", lastName);
            ServerComunication Server = new ServerComunication();
            String Response = Server.DoPost(path, reqparm);
            Console.WriteLine(Response);


            return true;


        }


        public void GetUser(string path , string id) {

            ServerComunication server = new ServerComunication();
            Parse(server.DoGet(path + id));
        
        }


        public void GetUsers(string path)
        {

            ServerComunication server = new ServerComunication();
            Parse(server.DoGet(path));

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


    
        


  

    
}