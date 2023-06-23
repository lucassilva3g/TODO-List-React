using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using System.Globalization;

namespace Todo.Service.UnitTest._Configs;

public class MessagesConfig
{
    public static Messages Build()
    {
        var options = Options.Create(new LocalizationOptions { ResourcesPath = "Resources" });
        var factory = new ResourceManagerStringLocalizerFactory(options, NullLoggerFactory.Instance);

        Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-br");
        Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-br");

        return new Messages(factory);
    }
}

