using System;
using System.Net.Http;
using BlazorApp.Client;
using BlazorApp.Client.Interfaces;
using BlazorApp.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Radzen;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton<IEmployeeService, EmployeeService>();
builder.Services.AddSingleton<IWarrantGrantCaseService, WarrantGrantCaseService>();

builder.Services.AddSingleton(sp =>
    new HttpClient
        { BaseAddress = new Uri(builder.Configuration["API_Prefix"] ?? builder.HostEnvironment.BaseAddress) });
builder.Services.AddRadzenComponents();
await builder.Build().RunAsync();