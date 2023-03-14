using CleanArquitecture.Application.Features.Streamers.Commands.CreateStreamer;
using CleanArquitecture.Application.Features.Streamers.Commands.DeleteStreamer;
using CleanArquitecture.Application.Features.Streamers.Commands.UpdateStreamer;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CleanArchitecture.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class StreamerController : ControllerBase
    {
        private IMediator _mediator;

        public StreamerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "CreateStreamer")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateStreamer([FromBody] CreateStreamerCommand createStreamer)
        {
            return await _mediator.Send(createStreamer); 
        }

        [HttpPut(Name = "UpdateStreamer")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateStreamer([FromBody] UpdateStreamerCommand updateStreamer)
        {
            await _mediator.Send(updateStreamer);
            return NoContent();
        }

        [HttpDelete("{id:int}",Name = "DeleteStreamer")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Deletestreamer(int id)
        {
            DeleteStreamerCommand deleteStreamer = new DeleteStreamerCommand { Id = id};
            await _mediator.Send(deleteStreamer);
            return NoContent();
        }

    }
}
