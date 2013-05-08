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

        }

        public String DoGet(string path )
        {             


             WebClient client = new WebClient();

         
            Stream stream =  client.OpenRead(url + path);
            
            StreamReader streamReader = new StreamReader (stream);
            /*
            string text = streamReader.ReadToEnd();

            streamReader.
            */
            JObject jObject = JObject.Parse(streamReader.ReadLine());



          


            
         /*

            while (JsonReader.Read()) {

                if (JsonReader.Value != null) { Console.WriteLine(" token: {0} , value:  {1}", JsonReader.ValueType, JsonReader.Value); }
                else { Console.WriteLine(" token: {0}", JsonReader.ValueType); }
             }


    
            */


            return jObject.ToString() ;

            
        }

    }
}