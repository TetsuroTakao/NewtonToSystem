using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NewtonToSystem
{
    public class CardModel
    {
        [JsonPropertyName("templates")]
        public List<Template> templates { get; set; }
    }
    public class Template
    {
        [JsonPropertyName("file")]
        public string file { get; set; }
        [JsonPropertyName("fullPath")]
        public string fullPath { get; set; }
    }
}
