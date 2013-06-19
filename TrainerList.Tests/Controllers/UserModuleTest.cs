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

        }


        [TestMethod]
        public void test_getUser()
        {
            UserModel user = new UserModel();

           bool resposta = user.GetUser("/trainer/", "0ddc29d0d97dac7f5c5a8097f4000f58");

           Assert.AreEqual(true, resposta);

        
        }


        [TestMethod]
        public void test_EditUser()
        {
            UserModel user = new UserModel();

            bool resposta = user.GetUser("/trainer/", "0ddc29d0d97dac7f5c5a8097f4000f58");

            string nameTempUser = string.Empty;


            Random my_random = new Random(DateTime.Now.Millisecond);
            int num_random = my_random.Next(0, 99);

            nameTempUser = "tempuser" + num_random;


            user.firstName = nameTempUser;

            if (user.UserSave("/trainer/")) {
            
            
             user.GetUser("/trainer/", "0ddc29d0d97dac7f5c5a8097f4000f58");


             Assert.AreEqual(nameTempUser, user.firstName);
            }

           
            Assert.AreEqual(true, resposta);

        }

    }
}
