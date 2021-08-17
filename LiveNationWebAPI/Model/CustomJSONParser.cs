using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LiveNationWebAPI.Model
{
    public static class CustomJSONParser
    {
        public static Dictionary<string,string> DeserializeRules(string json)
        {
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
        }

        public static string SerializeRules(Dictionary<string,string> rules)
        {
            return JsonConvert.SerializeObject(rules);
        }
    }
}
