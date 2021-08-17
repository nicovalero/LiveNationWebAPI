using LiveNationWebAPI.Model;
using LiveNationWebAPI.Tests.fake;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LiveNationWebAPI.Tests
{
    [TestClass]
    public class APIServiceTests
    {
        private FakeRuleManager _ruleManager;
        private APIService _underTests;

        [TestInitialize]
        public void Setup()
        {
            _ruleManager = new FakeRuleManager();
            _underTests = new APIService(_ruleManager);
        }

        [TestMethod]
        public void NullIsRetrieved_WHEN_rangeIsNull()
        {
            Range range = null;

            string result = _underTests.CreateRangeResponse(range);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void NullIsRetrieved_WHEN_rangeIsNotValid()
        {
            FakeRange range = new FakeRange();
            range.IsValidRangeResult = false;

            string result = _underTests.CreateRangeResponse(range);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void NullIsRetrieved_WHEN_rangeIsValid_AND_sequenceReturnsNull()
        {
            FakeRange range = new FakeRange();
            range.IsValidRangeResult = true;
            range.GetSequenceResult = null;

            string result = _underTests.CreateRangeResponse(range);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void NullIsRetrieved_WHEN_rangeIsValid_AND_sequenceIsNotNull_AND_rulesBecomesNull()
        {
            FakeRange range = new FakeRange();
            range.IsValidRangeResult = true;
            range.GetSequenceResult = new List<int>();
            _ruleManager.GetRulesResult = null;

            string result = _underTests.CreateRangeResponse(range);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void StringIsNotNull_WHEN_rangeIsValid_AND_sequenceIsNotNull_AND_rulesIsNotNull()
        {
            FakeRange range = new FakeRange();
            range.IsValidRangeResult = true;
            range.GetSequenceResult = new List<int>(new int[]{ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 });
            Dictionary<string, string> rules = new Dictionary<string, string>();
            rules.Add("3","Live");
            rules.Add("5", "Nation");
            _ruleManager.GetRulesResult = rules;
            string expectedResult = "1 2 Live 4 Nation Live 7 8 Live Nation 11 Live 13 14 LiveNation";

            string result = _underTests.CreateRangeResponse(range);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void DictionaryIsNull_WHEN_managerReturnsNull()
        {
            _ruleManager.GetRulesResult = null;

            Dictionary<string, string> actualResult = _underTests.GetRuleSummary();

            Assert.IsNull(actualResult);
        }

        [TestMethod]
        public void DictionaryIsNotNull_WHEN_managerIsSuccessful_AND_reversionIsSuccessful()
        {
            Dictionary<string, string> originalDictionary = new Dictionary<string, string>();
            originalDictionary.Add("1", "Live Nation");
            string expectedKey = "Live Nation";
            string expectedValue = "1";
            int expectedSize = 1;
            _ruleManager.GetRulesResult = originalDictionary;

            Dictionary<string, string> actualResult = _underTests.GetRuleSummary();

            Assert.AreEqual(expectedSize, actualResult.Count);
            Assert.IsTrue(actualResult.ContainsKey(expectedKey));
            Assert.AreEqual(expectedValue, actualResult[expectedKey]);
        }
    }
}
