using System.Collections;
using System.Linq;
using Serilog.Core;
using Serilog.Events;

namespace Astro.Inftrastructure.Serilog.Enrichers
{
    public class InstanceIdEnricher : ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            if (logEvent.Exception == null ||
                logEvent.Exception.Data == null ||
                logEvent.Exception.Data.Count == 0)
            {
                return;
            }

            var instanceIdData = logEvent.Exception.Data
            .Cast<DictionaryEntry>()
            .Where(e => e.Key.ToString() == "InstanceId");

            var property = propertyFactory.CreateProperty(
                "InstanceId",
                instanceIdData.First().Value);

            logEvent.AddPropertyIfAbsent(property);
        }
    }
}