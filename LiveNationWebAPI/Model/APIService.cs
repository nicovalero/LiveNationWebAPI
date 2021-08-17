﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveNationWebAPI.Model
{
    public interface IAPIService
    {
        public string CreateRangeResponse(Range range);
        public Dictionary<string, string> GetRuleSummary();
        public void SetRule(Rule rule);
        public void DeleteRule(Rule rule);
    }
    public class APIService: IAPIService
    {
        private IRuleManager _ruleManager;

        public APIService(IRuleManager ruleManager)
        {
            _ruleManager = ruleManager;
        }
        public string CreateRangeResponse(Range range)
        {
            try
            {
                if (range.IsValidRange())
                {
                    List<int> sequence = range.GetSequence();

                    if (sequence != null)
                    {
                        StringBuilder result = new StringBuilder();
                        StringBuilder currentResult;
                        Dictionary<string, string> rules = _ruleManager.GetRules();
                        List<string> ruleKeys = rules.Keys.ToList();
                        int keyInteger;

                        foreach (int number in sequence)
                        {
                            currentResult = new StringBuilder();

                            foreach (string key in ruleKeys)
                            {
                                keyInteger = Convert.ToInt32(key);
                                if (number % keyInteger == 0)
                                    currentResult.Append(rules[key]);
                            }
                            if (currentResult.Length == 0)
                                currentResult.Append(number.ToString());

                            result.Append(currentResult);
                            result.Append(" ");
                        }

                        return result.ToString();
                    }
                    else
                        return null;
                }
                else
                    return null;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public Dictionary<string, string> GetRuleSummary()
        {
            Dictionary<string, string> dictionary = _ruleManager.GetRules();
            dictionary = DictionaryReversion.Reverse<string, string>(dictionary);
            return dictionary;
        }

        public void SetRule(Rule rule)
        {
            _ruleManager.SaveRule(rule);
        }

        public void DeleteRule(Rule rule)
        {
            _ruleManager.DeleteRule(rule);
        }
    }
}
