﻿using Microsoft.AspNetCore.Http;

namespace Birthday.Bot.Client.Settings
{
    public class AppHttpContext
    {
        private static IHttpContextAccessor _httpContextAccessor;

        public static HttpContext Current => _httpContextAccessor.HttpContext;

        public static string AppBaseUrl => $"{Current.Request.Scheme}://{Current.Request.Host}{Current.Request.PathBase}";

        public static void Configure(IHttpContextAccessor contextAccessor)
        {
            _httpContextAccessor = contextAccessor;
        }
    }
}
