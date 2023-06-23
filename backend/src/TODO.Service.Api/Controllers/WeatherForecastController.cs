using MediatR;
using Todo.Service.Api.Controllers;
using Todo.Service.Application.WeatherForecast.Queries.List;

namespace Todo_List.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : BaseController
{
    public WeatherForecastController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<WeatherForecastViewModel>))]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized, Type = typeof(ProblemDetails))]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(ProblemDetails))]
    public async Task<ActionResult<List<WeatherForecastViewModel>>> ListAll()
    {
        return Ok(await _mediator.Send(new ListWeatherForecastsQuery()));
    }
}