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
            Dictionary<string,string> list = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

            return list;
        }
    }
}
