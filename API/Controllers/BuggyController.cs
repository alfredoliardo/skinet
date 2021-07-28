using API.Errors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuggyController : ControllerBase
    {
        [HttpGet("notfound")]
        public ActionResult GetNotFound()
        {
            return NotFound(new ApiErrorResponse(404));
        }

        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            object thing = null;
            var error = thing.ToString();
            return Ok();
        }


        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiErrorResponse(400));
        }
        
        [HttpGet("unauthorized")]
        public ActionResult GetUnauthorized()
        {
            return Unauthorized(new ApiErrorResponse(401));
        }
    }
}