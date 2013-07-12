using Newtonsoft.Json.Linq;
using System;
using System.Collections.Specialized;
using System.Web;
using System.ComponentModel.DataAnnotations;
using TrainerList.Functions;
using System.Collections.Generic;

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
            reqparm.Add("timestamp", Timestamp.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ"));
            reqparm.Add("description", description);

            ServerComunication.DoPost(path,reqparm);

            return true; 
        }

        public List<EventModel> upcoming(string userId, int limit = 30) {

            string path = "/events/upcoming/";
            try
            {
                return ParseMulti(ServerComunication.DoGet(path + userId + "? limit=" + limit.ToString()));

            }
            catch (Exception ex)
            {
                return null;
            }
        
        }

        public List<EventModel> Old(string userId, int limit = 30)
        {

            string path = "/events/upcoming/";
            try
            {
                return ParseMulti(ServerComunication.DoGet(path + userId + "?limit=" + limit.ToString()));

            }
            catch (Exception ex)
            {
                return null;
            }

        }


        
        public Boolean Parse(JObject jObject)
        {
            try
            {
                _id = (String)jObject["_id"];
                _rev =   (String)jObject["_rev"];
                Timestamp = (DateTime)jObject["timestamp"];
                description = (String)jObject["description"];
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public List<EventModel> ParseMulti(JArray jObject)
        {
            try
            {
                List<EventModel> Events = new List<EventModel>();

                foreach (JObject item in jObject)
                {
                    EventModel newEvent = new EventModel();

                    newEvent._id = (String)item["_id"];
                    newEvent._rev = (String)item["_rev"];
                    newEvent.Timestamp = (DateTime)item["timestamp"];
                    newEvent.description = (String)item["description"];
                    Events.Add(newEvent);
                }
                return Events;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}