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
   
    public class ServerComunication
    {
        string url = "http://localhost:8080" ;
        public String DoPost(string path, NameValueCollection reqparm)
        {

            WebClient client = new WebClient();
            byte[] responsebytes = client.UploadValues(url + path, "POST", reqparm);
            UTF8Encoding responsebody = new UTF8Encoding();
            responsebody.GetString(responsebytes);

            return responsebody.ToString();

            /*TO DO
           * Create some execption for errors
           * Create some message to show*/

        }

        public JObject DoGet(string path)
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