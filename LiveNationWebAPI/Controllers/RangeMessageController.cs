using LiveNationWebAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;

namespace LiveNationWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RangeMessageController : ControllerBase
    {
        private IAPIService _APIService;
        private readonly IMemoryCache _memoryCache;
        private readonly MemoryCacheEntryOptions _cacheOptions;
        public RangeMessageController(IAPIService service, IMemoryCache memoryCache)
        {
            _APIService = service;
            _cacheOptions = new MemoryCacheEntryOptions()
                .SetSize(1)
                .SetPriority(CacheItemPriority.High)
                .SetSlidingExpiration(TimeSpan.FromSeconds(30))
                .SetAbsoluteExpiration(TimeSpan.FromSeconds(60));
            _memoryCache = memoryCache;
        }

        [HttpGet("GetRangeResponse")]
        public string GetRangeResponse(string start, string end)
        {
            
            string cacheKey = start + " " + end;
            string json;
            if (_memoryCache.TryGetValue(cacheKey, out json))
            {
                return json;
            }
            else
            {
                Model.Range range = new Model.Range(start, end);
                Response response = new Response();

                response.Result = _APIService.CreateRangeResponse(range);
                response.Summary = _APIService.GetRuleSummary();
                json = JsonConvert.SerializeObject(response);

                _memoryCache.Set(cacheKey, json, _cacheOptions);

                return json;
            }
        }

        [HttpPost("SaveRule")]
        public void SetRule(string key, string value)
        {
            int isNumber;
            if (int.TryParse(key, out isNumber))
            {
                Rule rule = new Rule(key, value);
                _APIService.SetRule(rule);
            }
        }

        [HttpPost("DeleteRule")]
        public void DeleteRule(string key)
        {
            Rule rule = new Rule(key, null);
            _APIService.DeleteRule(rule);
        }
    }
}
