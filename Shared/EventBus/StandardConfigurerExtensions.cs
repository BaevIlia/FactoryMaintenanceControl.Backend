using Newtonsoft.Json;
using Rebus.Config;
using Rebus.Serialization;
using Rebus.Serialization.Custom;
using Rebus.Serialization.Json;

namespace Shared.EventBus;

public static class StandardConfigurerExtensions
{
    public static StandardConfigurer<ISerializer> ConfigureSerializer(this StandardConfigurer<ISerializer> configurer)
    {
        var messageTypes = AppDomain.CurrentDomain.GetAssemblies()
                                                  .SelectMany(a => a.GetTypes())
                                                  .Where(t => typeof(InternalEvent).IsAssignableFrom(t) && t.IsClass && !t.IsAbstract && t.IsPublic || t.IsArray && typeof(InternalEvent).IsAssignableFrom(t.GetElementType()))
                                                  .ToList();

        configurer.UseNewtonsoftJson(new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            TypeNameHandling = TypeNameHandling.None,
        });

        configurer.UseCustomMessageTypeNames()
                  .AddWithShortNames(messageTypes)
                  .AllowFallbackToDefaultConvention();

        return configurer;
    }
}