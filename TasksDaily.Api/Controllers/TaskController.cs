using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace TasksDaily.Api.Controllers
{
  [ApiController]
  [Route("v{version:apiVersion}/[controller]")]
  [ApiVersion("1.0")]
  [ApiVersion("1.1")]
  public class TaskController : ControllerBase
  {
    [HttpGet("dummy")]
    [Produces(typeof(TaskResponse))]
    public IActionResult Get(ApiVersion version)
    {
      return Ok(new TaskResponse { Message = $"This is the version {version.ToString()}" });
    }
  }

  public class TaskResponse
  {
    public required string Message { get; set; }
  }
}