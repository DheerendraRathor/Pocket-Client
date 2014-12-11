using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pocketo
{
    public static class Constants
    {

        //Application specific
        public const String APP_NAME = "POCKETO";


        //pocker constants
        public const String CONSUMER_KEY = "consumer_key";
        public const String REQUEST_TOKEN = "request_token";
        public const String ACCESS_TOKEN = "access_token";
        public const String CODE = "code";
        public const String REDIRECT_URI = "redirect_uri";
        public const String USERNAME = "username";

        //URIs
        public const String REQUEST_TOKEN_URI = "https://getpocket.com/v3/oauth/request";
        public const String AUTH_URI = "https://getpocket.com/auth/authorize?mobile=1&request_token={0}&redirect_uri={1}";
        public const String ACCESS_TOKEN_URI = "https://getpocket.com/v3/oauth/authorize";
        public const String RETRIEVE_URI = "https://getpocket.com/v3/get";


        public const String PROTOCOL = "pocket-dsr://";
        public const String REDIRECT_TO = PROTOCOL + "pocketAuth/";

        //Resource Files
        public const String KEY_FILE = "Keys";

        //User messages
        public const String CONFIG_MSG = "Initializing Authentication, Please wait";
        public const String AUTH_MSG = "Authorize to Pocket";
        public const String LOGGING_MSG = "Authenticating...";

        
    }
}
