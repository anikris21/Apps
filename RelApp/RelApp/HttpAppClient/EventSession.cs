using Newtonsoft.Json;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpAppClient
{
    // JsonProperty
    class EventRoot { [JsonProperty("events")] public List<Event> events; }

    // :IComparable<Event>
    class Event : IComparable<Event>
    { 
        public string url; 
        public string visitorId; 
        public long timestamp;
        public int CompareTo(Event e)
        {
            if (e.visitorId == visitorId) { return timestamp.CompareTo(e.timestamp) ; }
            else { return visitorId.CompareTo(e.visitorId); }
        }
    }
    internal class EventSession
    {
        string eventStr = "{\"events\": [ {   \"url\": \"/pages/a-big-river\",   \"visitorId\": \"d1177368-2310-11e8-9e2a-9b860a0d9039\",   \"timestamp\": 1512754583000 }, {   \"url\": \"/pages/a-small-dog\",   \"visitorId\": \"d1177368-2310-11e8-9e2a-9b860a0d9039\",   \"timestamp\": 1512754631000 }, {   \"url\": \"/pages/a-big-talk\",   \"visitorId\": \"f877b96c-9969-4abc-bbe2-54b17d030f8b\",   \"timestamp\": 1512709065294 }, {   \"url\": \"/pages/a-sad-story\",   \"visitorId\": \"f877b96c-9969-4abc-bbe2-54b17d030f8b\",   \"timestamp\": 1512711000000 }, {   \"url\": \"/pages/a-big-river\",   \"visitorId\": \"d1177368-2310-11e8-9e2a-9b860a0d9039\",   \"timestamp\": 1512754436000 }, {   \"url\": \"/pages/a-sad-story\",   \"visitorId\": \"f877b96c-9969-4abc-bbe2-54b17d030f8b\",   \"timestamp\": 1512709024000 }\n  ]\n}";


        public EventSession() { }

        

        public EventRoot Get() { return JsonConvert.DeserializeObject<EventRoot>(eventStr); }
    }
}
