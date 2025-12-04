using Microsoft.AspNetCore.Mvc;

namespace Bank.Controllers
{
    [ApiController]
    [Route("api/test")]
    public class TestController : ControllerBase
    {
        // Endpoint SANS description (déclenchera operation-description)
        // Endpoint SANS tags (déclenchera operation-tags)
        // Endpoint SANS operationId (déclenchera operation-operationId)
        [HttpPost("bad-endpoint")]
        public IActionResult BadEndpoint([FromBody] object request)
        {
            return Ok();
        }

        // Endpoint avec réponse SANS description (déclenchera operation-response-description)
        [HttpGet("no-response-description")]
        public IActionResult NoResponseDescription()
        {
            // Retourne une réponse 200 mais sans description dans OpenAPI
            return Ok(new { message = "test" });
        }

        // Endpoint avec paramètre de chemin non documenté (déclenchera path-params-defined)
        [HttpGet("{userId}/posts/{postId}")]
        public IActionResult ComplexPath(Guid userId, int postId)
        {
            // Les paramètres sont dans le chemin mais peuvent ne pas être bien documentés
            return Ok();
        }
    }
}

