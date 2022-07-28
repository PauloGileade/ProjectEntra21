using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ProjectEntra21.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class Entra21Controller : ControllerBase
    {
        protected IMediator _mediator;

        protected Entra21Controller(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
