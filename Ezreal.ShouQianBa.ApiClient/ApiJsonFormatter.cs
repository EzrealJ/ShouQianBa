using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebApiClient;
using WebApiClient.Defaults;

namespace Ezreal.ShouQianBa.ApiClient
{
    public class ApiJsonFormatter : JsonFormatter
    {
        protected override JsonSerializerSettings CreateSerializerSettings(FormatOptions options)
        {
            JsonSerializerSettings jsonSerializerSettings = base.CreateSerializerSettings(options);
            jsonSerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            var a = jsonSerializerSettings.Converters;
            //jsonSerializerSettings.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
            return jsonSerializerSettings;
        }
    }
}
