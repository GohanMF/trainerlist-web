using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Collections.Specialized;
using TrainerList.Functions;

namespace TrainerList.Models
{
    public class EventModels
    {


        public string _id { get; set; }
        public string _rev { get; set; }

        [Display(Name = "Event Date")]
        public DateTime Timestamp { get; set; }

        [Display(Name = "Description")]
        [DataType(DataType.Text)]
        [StringLength(40)]
        public string description { get; set; }


        public Boolean eventNew(string userId) {
            string = "/events/" +userId+ "/create";
            NameValueCollection reqparm = new NameValueCollection();
            reqparm.Add("timestamp", Timestamp.Ticks.ToString());
            reqparm.Add("descriptio", description);



            return true; 
        }

      


        public Boolean Parse(JObject jObject)
        {
            try
            {
              TimestampAttribute my_timestamp = new TimestampAttribute();
                _id = (String)jObject["_id"];
                _rev = (String)jObject["_rev"];
                Timestamp.AddTicks( (long)jObject["timestamp"]);
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