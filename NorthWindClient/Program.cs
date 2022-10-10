using Domain.Infrastructure.services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Fast.Components.FluentUI;
using NorthWindClient;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var configFile = "appsettings.json";
var HttpClient = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };
builder.Services.AddScoped(sp => HttpClient);
builder.Services.AddFluentUIComponents();
var ConfigService = new ConfigService(configFile, HttpClient);
await ConfigService.LoadAsync();
builder.Services.AddSingleton(ConfigService);
/****************just some shit to pretend we have a login system in place*******/
var users = builder.Configuration.GetSection("Users").GetChildren();

var userInfos = new List<UserInfo>();
foreach (var user in users)
{
    var userInfo = new UserInfo();
    user.Bind(userInfo);
    userInfos.Add(userInfo);
}
var UserService = new UserService(userInfos);
//builder.Services.AddScoped<IUserService>(us=>UserService);
builder.Services.AddSingleton(UserService);

/*****************end of shit*************************************************/

await builder.Build().RunAsync();
