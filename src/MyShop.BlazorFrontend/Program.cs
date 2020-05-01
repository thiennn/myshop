using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MyShop.BlazorFrontend.Services;

namespace MyShop.BlazorFrontend
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            var backendUrl = builder.Configuration["AppSettings:BackendUrl"];

            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(backendUrl) });
            builder.Services.AddTransient<ICategoryApiClient, CategoryApiClient>();

            builder.Services.AddOidcAuthentication(options =>
            {
                options.ProviderOptions.Authority = backendUrl;
                options.ProviderOptions.ClientId = "blazor";
                options.ProviderOptions.DefaultScopes.Add("openid");
                options.ProviderOptions.DefaultScopes.Add("profile");
                options.ProviderOptions.DefaultScopes.Add("api.myshop");
                options.ProviderOptions.ResponseType = "code";
                options.ProviderOptions.PostLogoutRedirectUri = "/";
            });

            await builder.Build().RunAsync();
        }
    }
}
