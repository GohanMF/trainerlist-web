using Newtonsoft.Json.Linq;
using System;
using System.Collections.Specialized;
using System.Web;
using System.ComponentModel.DataAnnotations;
using TrainerList.Functions;

namespace TrainerList.Models
{
    public class EventModel
    {

        public string _id { get; set; }
        public string _rev { get; set; }

        
        [Display(Name = "Event Date")]
        [DataType(DataType.DateTime)]   
        public DateTime Timestamp { get; set; }

        [Required]
        [StringLength(40)]
        [DataType(DataType.Text)]
        [Display(Name = "Description")]
        public string description { get; set; }


        public Boolean eventNew(string userId) {
            string path = "/events/" +userId+ "/create";
            NameValueCollection reqparm = new NameValueCollection();
            reqparm.Add("timestamp", Timestamp.Ticks.ToString());
            reqparm.Add("descriptio", description);

            ServerComunication.DoPost(path,reqparm);

            return true; 
        }

      

        
        public Boolean Parse(JObject jObject)
        {
            try
            {
              TimestampAttribute my_timestamp = new TimestampAttribute();
                _id = (String)jObject["_id"];
                _rev =   (String)jObject["_rev"];
                //Timestamp.AddTicks( (long)jObject["timestamp"]); 'i have to convert string o time (yyyy-mm-ddThh:MM:mmmmZ)
                description = (String)jObject["description"];
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}