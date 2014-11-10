using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthDemo
{
    public class Constants
    {
		public static string BaseUrl = "http://pc:49417";
        public static string ApiUrl = BaseUrl + "/api/";
        public static string NoInternetMessage = "Seems like our connection dropped or timed out. Please try again.";
    }
}