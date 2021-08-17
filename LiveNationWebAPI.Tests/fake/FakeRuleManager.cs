using LiveNationWebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveNationWebAPI.Tests.fake
{
    public class FakeRuleManager: IRuleManager
    {
        private Dictionary<string, string> _getRulesResult;
        public Dictionary<string, string> GetRulesResult
        {
            get { return _getRulesResult; }
            set { _getRulesResult = value; }
        }

        public Dictionary<string, string> GetRules()
        {
            return _getRulesResult;
        }

        public void DeleteRule(Rule rule)
        {
        }

        public void ReadRulesFromFile()
        {
        }

        public void SaveRule(Rule rule)
        {
        }

        public void SaveRulesToFile()
        {
        }
    }
}
