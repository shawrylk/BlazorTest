using BlazorApp;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


buidler.Services.AddCors(options =>
     {
         options.AddPolicy("NewPolicy", builder =>
          builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader());
     });
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


var app = builder.Build();
app.UseCors("CorsAllowAll");
await app.RunAsync();
