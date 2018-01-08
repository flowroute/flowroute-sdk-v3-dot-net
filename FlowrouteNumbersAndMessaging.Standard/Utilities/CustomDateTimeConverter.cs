using Newtonsoft.Json.Converters;

namespace FlowrouteNumbersAndMessaging.Standard.Utilities
{
    public class CustomDateTimeConverter : IsoDateTimeConverter
    {
        public CustomDateTimeConverter(string format)
        {
            DateTimeFormat = format;
        }
    }
}