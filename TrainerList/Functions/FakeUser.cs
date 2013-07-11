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
                string userFake = "{'username' : 'GohanMF', 'fistName' : 'Gohan' , 'lastName' : 'MF' , 'email' : 'Gohanmf@gmail.com' , '_id' : '3d391e068f7745e70cccb4a26a0000c9', '_rev' : '1-9942a2e35b1dad7161b194f779620b27' }";
               jUserFake = JObject.Parse(userFake);
            }else{ 
               jUserFake = null;
            }

          return jUserFake;
        }

    }
}