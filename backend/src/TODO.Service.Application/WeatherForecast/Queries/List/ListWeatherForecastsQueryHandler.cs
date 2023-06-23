using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo_List;

namespace Todo.Service.Application.WeatherForecast.Queries.List;

public class ListWeatherForecastsQuery : IRequest<List<WeatherForecastViewModel>> { }

public class ListWeatherForecastsQueryHandler : IRequestHandler<ListWeatherForecastsQuery, List<WeatherForecastViewModel>>
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };


    public readonly ITodoContext _context;

    public ListWeatherForecastsQueryHandler(ITodoContext context)
    {
        _context = context;
    }

    public async Task<List<WeatherForecastViewModel>> Handle(ListWeatherForecastsQuery request, CancellationToken cancellationToken)
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecastViewModel
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        }).ToList();
    }
}
