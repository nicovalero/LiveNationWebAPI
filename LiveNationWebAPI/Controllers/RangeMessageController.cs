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
        [HttpGet]
        public string GetRangeResponse(string start, string end)
        {
            Range range = new Range(start, end);
            Response response = new Response();
            response._result = _APIService.CreateRangeResponse(range);
            response._summary = _APIService.GetRuleSummary();
            string json = JsonConvert.SerializeObject(response);

            return json;
        }
    }
}
