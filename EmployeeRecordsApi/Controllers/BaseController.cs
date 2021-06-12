using Microsoft.AspNetCore.Mvc;

namespace EmployeeRecordsApi.Controllers
{
    [Route("v{v:apiVersion}/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
    }
}
