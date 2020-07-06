using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheGioiDiDong_v3.Models
{
    public class PaypalConfiguration
    {
        public readonly static string ClientId;
        public readonly static string ClientSecret;

        static PaypalConfiguration()
        {
            var config = Getconfig();
            //clientId = "AVe2MQH77JC_6sOHnxxkPLotNF_0k0-Lpsi88yEE_zV9WFgWVva1nycK3XXH_AUsmeqV_4vIMtY0rkqT";
            //clientSecret = "EN9g_EVjEv6vunVsC5utMk6p785k_06uNBZdBO00_jDCIlW0hyMydiI-XZSDtXf1Regb7kzJPSjLpz0E";
            ClientId = config["clientId"];
            ClientSecret = config["clientSecret"];

        }

        private static Dictionary<string, string> Getconfig()
        {
            return PayPal.Api.ConfigManager.Instance.GetProperties();
        }

        private static string GetAccessToken()
        {
            string accessToken = new OAuthTokenCredential(ClientId, ClientSecret, Getconfig()).GetAccessToken();
            return accessToken;

        }
        public static APIContext GetAPIContext()
        {
            APIContext apiContext = new APIContext(GetAccessToken());
            apiContext.Config = Getconfig();
            return apiContext;
        }
    }
}