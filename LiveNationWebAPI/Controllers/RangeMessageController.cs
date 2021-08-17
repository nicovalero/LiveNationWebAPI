using LiveNationWebAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace LiveNationWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RangeMessageController : ControllerBase
    {
        private IAPIService _APIService;
        public RangeMessageController(IAPIService service)
        {
            _APIService = service;
        }

        [HttpGet("GetRangeResponse")]
        public string GetRangeResponse(string start, string end)
        {
            Range range = new Range(start, end);
            Response response = new Response();
            response.Result = _APIService.CreateRangeResponse(range);
            response.Summary = _APIService.GetRuleSummary();
            string json = JsonConvert.SerializeObject(response);

            return json;
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
