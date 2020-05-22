using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NewtonToSystem.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NewtonToSystem
{
    public class Facade
    {
        public string OriginalJSON { get; set; }
        public string QurryAPIUrl { get; set; }
        public string GetCard(bool isNewton) 
        {
            var result = string.Empty;
            var results = new List<string>();
            QurryAPIUrl = $"https://templates.adaptivecards.io/list";
            using (var httpClient = new HttpClient())
            {
                var res = httpClient.GetAsync(QurryAPIUrl).Result;
                string resultJson = res.Content.ReadAsStringAsync().Result;
                if (res.IsSuccessStatusCode)
                {
                    OriginalJSON = resultJson;
                    var cards = JsonConvert.DeserializeObject<JObject>(resultJson)["github.com"].ToString();
                    if (isNewton)
                    {
                        // Case 1. Using the Newtonsoft namespace to parse an object as deserializing through prepared type. 
                        var cardTemplates = JsonConvert.DeserializeObject<CardModel>(cards);
                        foreach (var t in cardTemplates.templates)
                        {
                            results.Add(string.Format("file = [{0}], fullPath = [{1}]", t.file, t.fullPath));
                        }
                        result = string.Join(Environment.NewLine, results);
                        // Case 2. To parse an object as deserializing that through the 'JObect' of the Newtonsoft namespace.
                        // Use this process if you can't prepare the type of the JSON, or the type is not a complex structure.
                        var templates = JsonConvert.DeserializeObject<JObject>(cards);
                        var templatesArray = templates["templates"].ToArray();
                        foreach (var t in templatesArray)
                        {
                            results.Add(string.Format("file = [{0}], fullPath = [{1}]", t["file"].ToString(), t["fullPath"].ToString()));
                        }
                        result = string.Join(Environment.NewLine, results);
                    }
                    else
                    {
                        result = new TextController().GetJsonString(cards);
                    }
                }
            }
            return result;
        }
    }
}
