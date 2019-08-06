using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MySQL.Extensions;
using Pomelo.AspNetCore.Extensions.BlobStorage;
using System;

namespace MySQL.Extensions
{
    public class SessionUploadAuthorization : IBlobUploadAuthorizationProvider
    {
        private IServiceProvider services;

        public SessionUploadAuthorization(IServiceProvider provider)
        {
            services = provider;
        }

        public bool IsAbleToUpload()
        {
            var val = services.GetRequiredService<IHttpContextAccessor>().HttpContext.Session.GetString("Admin");
            if (val == "true")
                return true;
            return false;
        }
    }
}

namespace Microsoft.Extensions.DependencyInjection
{
    public static class SignedUserUploadAuthorizationProviderServiceCollectionExtensions
    {
        public static IBlobStorageBuilder AddSessionUploadAuthorization(this IBlobStorageBuilder self)
        {
            self.Services.AddSingleton<IBlobUploadAuthorizationProvider, SessionUploadAuthorization>();
            return self;
        }
    }
}
