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
        public void ReadRulesFromFile();
        public void SaveRulesToFile();
        public Dictionary<string, string> GetRules();
        public void SaveRule(string key, string value);
        public void DeleteRule(string key);
    }
    public class RuleManager: IRuleManager
    {
        public Dictionary<string, string> _rules { get; set; }
        private readonly string RULESPATH = "Config/Rules.json";

        public void ReadRulesFromFile()
        {
            Uri jsonUri = new Uri(Path.GetFullPath(RULESPATH.ToString()));
            string ruleList = CustomFileReader.ReadFile(jsonUri);
            _rules = CustomJSONParser.DeserializeRules(ruleList);
        }

        public void SaveRulesToFile()
        {
            string json = CustomJSONParser.SerializeRules(_rules);
            Uri jsonUri = new Uri(Path.GetFullPath(RULESPATH.ToString()));
            CustomFileReader.WriteToFile(jsonUri, json);
        }

        public Dictionary<string,string> GetRules()
        {
            ReadRulesFromFile();
            return _rules;
        }

        public void SaveRule(string key, string value)
        {
            ReadRulesFromFile();
            if (_rules.ContainsKey(key))
                _rules[key] = value;
            else
                _rules.Add(key, value);
            SaveRulesToFile();
        }

        public void DeleteRule(string key)
        {
            ReadRulesFromFile();
            if (_rules.ContainsKey(key))
                _rules.Remove(key);
            SaveRulesToFile();
        }
    }
}
