using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LiveNationWebAPI.Model
{
    public interface IRuleManager
    {
        public Dictionary<string, string> _rules { get; set; }
        public void GetRulesFromFile();
        public Dictionary<string, string> GetRules();
    }
    public class RuleManager: IRuleManager
    {
        public Dictionary<string, string> _rules { get; set; }
        private readonly string JSONPATH = "Config/Rules.json";

        public void GetRulesFromFile()
        {
            Uri jsonUri = new Uri(Path.GetFullPath(JSONPATH.ToString()));
            string ruleList = CustomFileReader.ReadFile(jsonUri);
            _rules = CustomJSONParser.DeserializeRules(ruleList);
        }

        public Dictionary<string,string> GetRules()
        {
            GetRulesFromFile();
            return _rules;
        }
    }
}
