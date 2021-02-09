using Microsoft.AspNetCore.Mvc;
using MSGraph.IService;
using System.Threading.Tasks;

namespace MSGraph_OAuth.Controllers
{
    [Route("api/[controller]")]
    public class GraphController : Controller
    {
        private readonly IAuthenticationService authenticationService;
        public GraphController(IAuthenticationService _authenticationService)
        {
            authenticationService = _authenticationService;
        }

        [HttpPost("")]
        public async Task<IActionResult> AuthenticateUser([FromBody] string accessToken)
        {
            dynamic authResult = await authenticationService.GetAuthenticationInfo(accessToken);
            return Ok(authResult);
        }
    }
}
