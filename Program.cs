using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Assignment_02.Services; // Include the namespace for your service

namespace Assignment_02
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            // Registering the HttpClient service
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            // Registering the RecipeService
            builder.Services.AddSingleton<RecipeService>(); // Use Singleton or Scoped based on your needs

            await builder.Build().RunAsync();
        }
    }
}
