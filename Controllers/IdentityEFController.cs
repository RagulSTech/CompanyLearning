using LearningCoreAPI.CQRSMethods.Commands.CreateEmployees;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LearningCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityEFController : ControllerBase
    {
        private readonly IMediator _mediator;

        public IdentityEFController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Create_Employee")]
        public async Task<IActionResult> CreateEmployee([FromQuery] CreateEmployeeCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
