namespace FlowrouteNumbersAndMessaging.Standard
{
    public partial class Configuration
    {
        //The base Uri for API calls
        public static string BaseUri = "https://api.flowroute.com";

        //The username to use with basic authentication
        //TODO: Replace the BasicAuthUserName with your Flowroute Access Key
        public static string BasicAuthUserName = "FR_ACCESS_KEY";

        //The password to use with basic authentication
        //TODO: Replace the BasicAuthPassword with your Flowroute Secret Key
        public static string BasicAuthPassword = "FR_SECRET_KEY";
    }
}
