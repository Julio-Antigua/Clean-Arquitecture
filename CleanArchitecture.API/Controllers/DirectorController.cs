using CleanArquitecture.Application.Constans;
using CleanArquitecture.Application.Features.Directors.Commands.CreateDirector;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CleanArchitecture.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DirectorController : ControllerBase
    {
        private IMediator _mediator;

        public DirectorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "CreateDirector")]
        [Authorize(Roles = nameof(CustomRoles.Administrator))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateDirector([FromBody] CreateDirectorCommand command) => await _mediator.Send(command);
    }
}
