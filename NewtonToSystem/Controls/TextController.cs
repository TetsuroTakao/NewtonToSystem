using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NewtonToSystem.Controls
{
    public class TextController
    {
        public string GetJsonString(string json) 
        {
            List<string> result = new List<string>();
            var cards = System.Text.Json.JsonDocument.Parse(json).RootElement.GetProperty("templates");
            // Case 3. Using the System namespace to parse an object as deserializing through prepared type. 
            var templates = JsonSerializer.Deserialize<List<Template>>(cards.ToString());
            foreach (var t in templates)
            {
                result.Add(string.Format("file = [{0}], fullPath = [{1}]", t.file, t.fullPath));
            }
            // Case 4. To parse an object as deserializing that through the 'JsonDocument' of the System namespace.
            // Use this process if you can't prepare the type of the JSON, or the type is not a complex structure.
            foreach (var t in cards.EnumerateArray().ToList())
            {
                result.Add(string.Format("file = [{0}], fullPath = [{1}]", t.GetProperty("file").GetString(), t.GetProperty("fullPath").GetString()));
            }
            return string.Join(Environment.NewLine,result);
        }
    }
}
