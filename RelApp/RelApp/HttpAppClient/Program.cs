using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using HttpAppClient;
//using System.Text.Json;
using System.Text.Json;


//string raw1 = "{\"sessionsByUser\":{\"f877b96c-9969-4abc-bbe2-54b17d030f8b\":[{\"duration\":41294,\"pages\":[\"\/pages\/a-sad-story\",\"\/pages\/a-big-talk\"],\"startTime\":1512709024000},{\"duration\":0,\"pages\":[\"\/pages\/a-sad-story\"],\"startTime\":1512711000000}],\"d1177368-2310-11e8-9e2a-9b860a0d9039\":[{\"duration\":195000,\"pages\":[\"\/pages\/a-big-river\",\"\/pages\/a-big-river\",\"\/pages\/a-small-dog\"],\"startTime\":1512754436000}]}}";


//string raw = "{\"sessionsByUser\":{\"f877b96c-9969-4abc-bbe2-54b17d030f8b\":[{\"duration\":41294,\"pages\":[\"\/pages\/a-sad-story\",\"\/pages\/a-big-talk\"],\"startTime\":1512709024000},{\"duration\":0,\"pages\":[\"\/pages\/a-sad-story\"],\"startTime\":1512711000000}],\"d1177368-2310-11e8-9e2a-9b860a0d9039\":[{\"duration\":195000,\"pages\":[\"\/pages\/a-big-river\",\"\/pages\/a-big-river\",\"\/pages\/a-small-dog\"],\"startTime\":1512754436000}]}}";

// string eventStr= "{\"events\": [\n    {\n      \"url\": \"/pages/a-big-river\",\n      \"visitorId\": \"d1177368-2310-11e8-9e2a-9b860a0d9039\",\n      \"timestamp\": 1512754583000\n    },\n    {\n      \"url\": \"/pages/a-small-dog\",\n      \"visitorId\": \"d1177368-2310-11e8-9e2a-9b860a0d9039\",\n      \"timestamp\": 1512754631000\n    },\n    {\n      \"url\": \"/pages/a-big-talk\",\n      \"visitorId\": \"f877b96c-9969-4abc-bbe2-54b17d030f8b\",\n      \"timestamp\": 1512709065294\n    },\n    {\n      \"url\": \"/pages/a-sad-story\",\n      \"visitorId\": \"f877b96c-9969-4abc-bbe2-54b17d030f8b\",\n      \"timestamp\": 1512711000000\n    },\n    {\n      \"url\": \"/pages/a-big-river\",\n      \"visitorId\": \"d1177368-2310-11e8-9e2a-9b860a0d9039\",\n      \"timestamp\": 1512754436000\n    },\n    {\n      \"url\": \"/pages/a-sad-story\",\n      \"visitorId\": \"f877b96c-9969-4abc-bbe2-54b17d030f8b\",\n      \"timestamp\": 1512709024000\n    }\n  ]\n}";


string r11 = "\"sessionsByUser\": {\"f877b96c-9969-4abc-bbe2-54b17d030f8b\": [  {    \"duration\": 41294,    \"pages\": [      \"/pages/a-sad-story\",      \"/pages/a-big-talk\"    ],    \"startTime\": 1512709024000  },  {    \"duration\": 0,    \"pages\": [      \"/pages/a-sad-story\"    ],    \"startTime\": 1512711000000  }],\"d1177368-2310-11e8-9e2a-9b860a0d9039\": [  {    \"duration\": 195000,    \"pages\": [      \"/pages/a-big-river\",      \"/pages/a-big-river\",      \"/pages/a-small-dog\"    ],    \"startTime\": 1512754436000  }]\n}\n}";
string r1 = "{\"sessionsByUser\": {\"f877b96c-9969-4abc-bbe2-54b17d030f8b\": [  {    \"duration\": 41294,    \"pages\": [      \"/pages/a-sad-story\",      \"/pages/a-big-talk\"    ],    \"startTime\": 1512709024000  },  {    \"duration\": 0,    \"pages\": [      \"/pages/a-sad-story\"    ],    \"startTime\": 1512711000000  }],\"d1177368-2310-11e8-9e2a-9b860a0d9039\": [  {    \"duration\": 195000,    \"pages\": [      \"/pages/a-big-river\",      \"/pages/a-big-river\",      \"/pages/a-small-dog\"    ],    \"startTime\": 1512754436000  }]\n}\n}";
// Encoding.UTF8 StringContent

HttpClient client = new() { BaseAddress = new Uri("https://httpbin.org/post") };
var content = new StringContent(r1, Encoding.UTF8, "application/json");
HttpResponseMessage response = await client.PostAsync("/post", content);
var jsonResponse = await response.Content.ReadAsStringAsync();
Console.WriteLine($"{jsonResponse}\n");
// if(response.IsSuccessStatusCode) {Console.WriteLine(response.StatusCode.ToString());}

// <Root>
dynamic stuff = JsonConvert.DeserializeObject<Root>(jsonResponse);
Console.WriteLine(stuff.data);
var res = JObject.Parse(jsonResponse).Children();
var res1 = res.Children();
// 
Console.WriteLine(res["data"]);

dynamic o1 = JsonConvert.DeserializeObject<RootObject>(r1);
Console.WriteLine(o1.sessionsByUser["f877b96c-9969-4abc-bbe2-54b17d030f8b"][0].duration);
//Console.WriteLine(stuff.data["sessionsByUser"]);
//Console.WriteLine(stuff.data.sessionsByUser["f877b96c-9969-4abc-bbe2-54b17d030f8b"]);
Console.WriteLine(stuff.data.GetType()?.Name);

// Dictionary<string, RootObject1>
response = await client.GetAsync("/get");
jsonResponse = await response.Content.ReadAsStringAsync();
Console.WriteLine($"{jsonResponse}\n");
var cr = JsonConvert.DeserializeObject<Root1>(jsonResponse);
Console.WriteLine(cr.url);


var er = new EventSession().Get();
er.events.Sort();
for (int i1 = 0; i1 < er.events.Count; i1++)
{
    Console.WriteLine($"{er.events[i1].visitorId}    {er.events[i1].timestamp} ");

}



int j1 = 0;
RootObject root = new RootObject();
Session s = null;
string visitorId = "";
long timestamp = 0; //long
while (j1 < er.events.Count)
{
    // new List<string>(){er.events[j1].url}
    s = new Session()
    {
        startTime = er.events[j1].timestamp,
        pages = new List<string>() {  },
        duration = 0
    };
    if (visitorId == "")
    {
        visitorId = er.events[j1].visitorId;
    }
    timestamp = er.events[j1].timestamp;
    while (j1 < er.events.Count && visitorId == er.events[j1].visitorId && (timestamp == 0 || (er.events[j1].timestamp - timestamp) <= (10 * 60 * 1000)))
    {
        // s.startTime - er.events[j1].timestamp
        s.duration = s.startTime - er.events[j1].timestamp;
        timestamp = er.events[j1].timestamp;
        s.pages.Add(er.events[j1].url);
        j1++;
    }
    if (root.sessionsByUser.ContainsKey(visitorId))
    {
        root.sessionsByUser[visitorId].Add(s);

    }
    else
    {
        root.sessionsByUser.Add(visitorId, new List<Session>() { s });

    }
    s = null;
    visitorId = "";
}

var c1 = new StringContent(System.Text.Json.JsonSerializer.Serialize(root), Encoding.UTF8, "application/json");




class Root1 { public object args; public string origin; public string url; }
class RootObject1 { 
    public Dictionary<string, Session> sessionsByUser { get; set; } }

// List<Session>
class RootObject { 
    [JsonProperty("sessionsByUser")] 
    public Dictionary<string, List<Session>> sessionsByUser { get; set; } = new Dictionary<string, List<Session>>();

}
class Session { public long duration { get; set; } public List<string> pages; public long startTime; }
class Root
{
    public object args;
    public object form;
    public string data;
    public RootObject json;
}