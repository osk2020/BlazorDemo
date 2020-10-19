using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;

namespace BlazorWasmDemo
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            
            ConfigureLogging(builder);

            await builder.Build().RunAsync();
        }

        private static void ConfigureLogging(WebAssemblyHostBuilder builder, string section = "Logging")
        {
            builder.Logging.AddConfiguration(builder.Configuration.GetSection(section));
        }
    }

    
}
