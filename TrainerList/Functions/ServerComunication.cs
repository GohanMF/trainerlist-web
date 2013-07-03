using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

 


namespace TrainerList.Functions
{
   
    public static class ServerComunication
    {
        static string url = "http://localhost:8080" ;
        public static String DoPost(string path, NameValueCollection reqparm  )
        {

            WebClient client = new WebClient();
            byte[] responsebytes = client.UploadValues(url + path, "POST" , reqparm );
            string responsebody = client.Encoding.GetString(responsebytes);

            return responsebody.ToString();

            

            /*TO DO
           * Create some execption for errors
           * Create some message to show*/

        }

        public static JObject DoGet(string path)
        {             


            WebClient client = new WebClient();
            Stream stream =  client.OpenRead(url + path);
            StreamReader streamReader = new StreamReader (stream);
            JObject myjObject = JObject.Parse(streamReader.ReadLine());
            client.Dispose();

            /*TO DO
             * Create some execption for errors
             * Create some message to show*/
          

            return myjObject; 
             
            
        }

    }
}