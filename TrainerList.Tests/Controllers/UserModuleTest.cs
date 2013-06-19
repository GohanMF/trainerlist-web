using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainerList.Models;

namespace TrainerList.Tests.Controllers
{
    [TestClass]
    public class UserModuleTest
    {
        [TestMethod]
        public void Test_createUser()
        {
            UserModel user = new UserModel();

            user.UserName = "bla" + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second;
            user.firstName ="fn"+ DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second;
            user.lastName = "ln" + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second;
            user.Password="1234567890";
            user.Email = "emailbla@fn.ln";

            Assert.AreEqual(true, user.UserRegister("/trainer"));

     
            bool Recived = user.GetUser("/trainer/", user._id);

            Assert.AreEqual(true, Recived);

            string nameTempUser = string.Empty;

            Random my_random = new Random(DateTime.Now.Millisecond);
            int num_random = my_random.Next(0, 99);

            nameTempUser = "tempuser" + num_random;

            user.firstName = nameTempUser;

            if (user.UserSave("/trainer/")) {
            
            
                user.GetUser("/trainer/", user._id);


                Assert.AreEqual(nameTempUser, user.firstName);
            }


            Assert.IsTrue(user.UserDelete("/trainer/"+user._id+"/delete"));
           
            //Falta o delete Perfil

        }

    }
}
