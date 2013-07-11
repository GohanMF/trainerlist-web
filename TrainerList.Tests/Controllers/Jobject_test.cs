using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainerList.Models;
using Newtonsoft.Json.Linq;

namespace TrainerList.Tests.Controllers
{
    [TestClass]
    public class Jobject_test
    {
       
        [TestMethod]
        public void Test_single()
        {
            String single = "{\"_id\":\"3d391e068f7745e70cccb4a26a0000c9\",\"_rev\":\"1-9942a2e35b1dad7161b194f779620b27\",\"username\":\"GohanMF\",\"email\":\"teste@teste.teste\",\"firstName\":\"teste\",\"lastName\":\"teste\"}";

            try
            {

             
                dynamic myjObject = JValue.Parse(single);
                
                
                
                Assert.IsNotNull(myjObject);
            }
            catch (Exception ex)
            {

                Assert.Fail(ex.Message.ToString() + "/n" + ex.InnerException.ToString());
            }
        }

         [TestMethod]
        public void Test_multi()
        {
            String multi = "[\n  {\n    \"_id\": \"3d391e068f7745e70cccb4a26a00423c\",\n    \"_rev\": \"1-bd7a28408ab1a0af56133a3905915411\",\n    \"timestamp\": \"2013-07-21T19:53:32Z\",\n    \"description\": \"21654444354\"\n  },\n  {\n    \"_id\": \"3d391e068f7745e70cccb4a26a0058b8\",\n    \"_rev\": \"1-8fe1d2fd5e645dbabebfccaa567f68b4\",\n    \"timestamp\": \"2013-07-28T10:47:17Z\",\n    \"description\": \"magnific\"\n  }\n]";

            try
            {


                dynamic myjObject = JValue.Parse(multi);
                Assert.IsNotNull(myjObject);
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }

        }


         [TestMethod]
         public void Test_multi2()
         {
             String multi = "[\n   {\n    \"_id\": \"3d391e068f7745e70cccb4a26a00423c\",\n    \"_rev\": \"1-bd7a28408ab1a0af56133a3905915411\",\n    \"timestamp\": \"2013-07-21T19:53:32Z\",\n    \"description\": \"21654444354\"\n  },\n  {\n    \"_id\": \"3d391e068f7745e70cccb4a26a0058b8\",\n    \"_rev\": \"1-8fe1d2fd5e645dbabebfccaa567f68b4\",\n    \"timestamp\": \"2013-07-28T10:47:17Z\",\n    \"description\": \"magnific\"\n  }\n]";

             try
             {

               JArray myjObject = JArray.Parse(multi);
                  
                 Assert.IsNotNull(myjObject);
             }
             catch (Exception ex)
             {
                 Assert.Fail();
             }

         }
    }

       
 
}
