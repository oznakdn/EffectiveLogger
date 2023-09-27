using Microsoft.AspNetCore.Mvc;

namespace Test.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
           
            var values = new List<string>()
            {
                "Value1",
                "Value2",
                "Value3",
                "Value4",

            };
         
            return Ok(values);
        }
    }
}
