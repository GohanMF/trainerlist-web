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
                string userFake = "{'username' : 'GohanMF', 'fistName' : 'Gohan' , 'lastName' : 'MF' , 'email' : 'Gohanmf@gmail.com' , '_id' : '5f17834f62bd7a316748f59833001606', '_rev' : '1-b8d67b3cb328b7425020b9ad91834d1d' }";
               jUserFake = JObject.Parse(userFake);
            }else{ 
               jUserFake = null;
            }

          return jUserFake;
        }

    }
}