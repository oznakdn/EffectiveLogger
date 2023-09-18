using Gleeman.EffectiveLogger.Logger;
using Microsoft.AspNetCore.Mvc;

namespace Test.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IEffectiveLog<ValuesController> _log;

        public ValuesController(IEffectiveLog<ValuesController> log)
        {
            _log = log;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _log.Information($"{DateTime.Now} - Information");
            _log.Debug($"{DateTime.Now} - Debug");

            var values = new List<string>()
            {
                "Value1",
                "Value2",
                "Value3",
                "Value4",

            };
            _log.Fail($"{DateTime.Now} - Fail");
            _log.Warning($"{DateTime.Now} - Warning");

            return Ok(values);
        }
    }
}
