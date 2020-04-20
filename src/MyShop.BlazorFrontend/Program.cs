using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace MyShop.BlazorFrontend
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddSingleton(new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddOidcAuthentication(options =>
            {
                options.ProviderOptions.Authority = "https://localhost:44349";
                options.ProviderOptions.ClientId = "blazor";
                options.ProviderOptions.DefaultScopes = new List<string> { "openid", "profile" };
                options.ProviderOptions.ResponseType = "code";
                options.ProviderOptions.PostLogoutRedirectUri = "/";
            });

            ConfigureCommonServices(builder.Services);

            await builder.Build().RunAsync();
        }

        public static void ConfigureCommonServices(IServiceCollection services)
        {
            
        }
    }
}
