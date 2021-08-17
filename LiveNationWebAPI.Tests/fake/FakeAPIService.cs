using LiveNationWebAPI.Model;
using System.Collections.Generic;

namespace LiveNationWebAPI.Tests.fake
{
    public class FakeAPIService : IAPIService
    {
        private string _createRangeResponseResult;
        private Dictionary<string, string> _getRuleSummaryResult;
        public string CreateRangeResponseResult
        {
            get { return _createRangeResponseResult; }
            set { _createRangeResponseResult = value; }
        }
        public Dictionary<string, string> GetRuleSummaryResult
        {
            get { return _getRuleSummaryResult; }
            set { _getRuleSummaryResult = value; }
        }

        public string CreateRangeResponse(IRange range)
        {
            return _createRangeResponseResult;
        }

        public Dictionary<string, string> GetRuleSummary()
        {
            return _getRuleSummaryResult;
        }

        public void SetRule(Rule rule)
        {
        }

        public void DeleteRule(Rule rule)
        {
        }
    }
}
