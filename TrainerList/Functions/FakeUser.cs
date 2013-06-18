using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace TrainerList.Functions
{
    public class FakeUser
    

    {


        public JObject my_fake_login( string username, string password) {
            JObject jUserFake;
            if (username == "GohanMF" && password == "123456")
            {
                string userFake = "{'username' : 'GohanMF', 'fistName' : 'Gohan' , 'lastName' : 'MF' , 'email' : 'Gohanmf@gmail.com' }";
               jUserFake = JObject.Parse(userFake);
            }else{ 
               jUserFake = null;
            }

          return jUserFake;
        }

    }
}