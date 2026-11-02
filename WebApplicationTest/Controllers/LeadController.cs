using BackEndServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationTest.Controllers
{
    [ApiController]
    [Route("/api/leads")]
    public class LeadController : ControllerBase
    {
        private IBackCallService _backCallService;
        public LeadController(IBackCallService backCallService) 
        {
            _backCallService = backCallService;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody]BackCallRequest request)
        {
            try
            {
                await _backCallService.SendBackCall(request.UserName, request.Phone, request.Email, request.UserType);
            }
            catch(ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}
