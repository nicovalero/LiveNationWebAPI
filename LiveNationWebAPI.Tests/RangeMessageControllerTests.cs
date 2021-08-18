using LiveNationWebAPI.Controllers;
using LiveNationWebAPI.Tests.fake;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LiveNationWebAPI.Tests
{
    [TestClass]
    public class RangeMessageControllerTests
    {
        private FakeAPIService _fakeAPIService;
        private MemoryCache _memoryCache;
        private RangeMessageController _underTests;

        [TestInitialize]
        public void Setup()
        {
            _fakeAPIService = new FakeAPIService();
            _memoryCache = new MemoryCache(new MemoryCacheOptions());
            _underTests = new RangeMessageController(_fakeAPIService, _memoryCache);
        }

        [TestMethod]
        public void JsonIsNotNull_WHEN_startOrEndIsNull()
        {
            string firstStart = null;
            string firstEnd = "any";
            string secondStart = "any";
            string secondEnd = null;

            string firstResult = _underTests.GetRangeResponse(firstStart, firstEnd);
            string secondResult = _underTests.GetRangeResponse(secondStart, secondEnd);

            Assert.IsNotNull(firstResult);
            Assert.IsNotNull(secondResult);
        }

        [TestMethod]
        public void JsonIsRetrieved_WHEN_serviceIsSuccessful_AND_rangeIsValid()
        {
            string start = "1";
            string end = "15";
            Dictionary<string, string> rules = new Dictionary<string, string>();
            rules.Add("3", "Live");
            rules.Add("5", "Nation");
            _fakeAPIService.CreateRangeResponseResult = "1 2 Live 4 Nation Live 7 8 Live Nation 11 Live 13 14 LiveNation";
            _fakeAPIService.GetRuleSummaryResult = rules;
            string expectedResult = "{\"Result\":\"1 2 Live 4 Nation Live 7 8 Live Nation 11 Live 13 14 LiveNation\",\"Summary\":{\"3\":\"Live\",\"5\":\"Nation\"}}";

            string result = _underTests.GetRangeResponse(start, end);

            Assert.AreEqual(expectedResult, result);
        }
    }
}
