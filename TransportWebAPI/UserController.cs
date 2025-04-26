using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace TransportWebAPI
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {


        [HttpGet]
        public IActionResult Get()
        {
        
            return Ok("Hello from UserController");
        }
        //http://localhost:5136/api/user/validateuser?myname=tushar&mypw=1234&companyno=transporttrial
        [HttpGet]
        [Route("validateuser")]
        public async Task<IActionResult> ValidateUser([FromQuery] string myname, [FromQuery] string mypw, [FromQuery] string companyno = "transporttrial")
        {
            var tdduser = await MongoHelper.GetUserAsync(myname, mypw, companyno);



            var responseData = JsonConvert.SerializeObject(tdduser, Newtonsoft.Json.Formatting.Indented);

            return Content(responseData, "application/json");
        }
    }
}
