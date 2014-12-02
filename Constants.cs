using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pocket_Client
{
    public static class Constants
    {
        //pocker constants
        public const String CONSUMER_KEY = "consumer_key";
        public const String REQUEST_TOKEN = "request_token";
        public const String ACCESS_TOKEN = "access_token";
        public const String CODE = "code";
        public const String REDIRECT_URI = "redirect_uri";

        //URIs
        public const String REQUEST_TOKEN_URI = "requestTokenURI";


        public const String PROTOCOL = "pocket-dsr://";
        public const String REDIRECT_TO = PROTOCOL + "pocketAuth";

        //Resource Files
        public const String KEY_FILE = "Keys";
        public const String RESOURCE_FILE = "Resources";
    }
}
