using Gleeman.EffectiveLogger.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Test.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IEffectiveLogger<ValuesController> _effectiveLogger;

        public ValuesController(IEffectiveLogger<ValuesController> effectiveLogger)
        {
            _effectiveLogger = effectiveLogger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _effectiveLogger.Information("Information");
            _effectiveLogger.Debug("Debug");

            var values = new List<string>()
            {
                "Value1",
                "Value2",
                "Value3",
                "Value4",

            };
            _effectiveLogger.Fail("Fail");
            _effectiveLogger.Warning("Warning");

            return Ok(values);
        }
    }
}
