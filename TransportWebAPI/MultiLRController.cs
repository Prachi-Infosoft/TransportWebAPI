using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TransportWebAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class MultiLRController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {

            return Ok("Hello from MultiLRController");
        }

        //http://localhost:5136/api/multilr/listoflories
        [HttpGet]
        [Route("listoflories")]
        public async Task<IActionResult> GetPreviousMultiLRs()
        {
            return Ok(await MongoHelper.GetListOfLoriesAsync());

        }

        //http://localhost:5136/api/multilr/listofexistinglrs
        [HttpGet]
        [Route("listofexistinglrs")]        
        public async Task<IActionResult> GetAllLories() 
        {
            return Ok(await MongoHelper.GetListOfExistingLRAsync() );

        }
    }
}
