using Azure.Identity;
using MudBlazor.Services;
using Portfolio.Razor.Client.Pages;
using Portfolio.Razor.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddMudServices();

builder.Configuration.AddAzureKeyVault(
    new Uri(builder.Configuration["AzureKeyVault:VaultURI"]!),
    new ClientSecretCredential(
        tenantId: builder.Configuration["AzureKeyVault:TenantId"]!,
        clientId: builder.Configuration["AzureKeyVault:ClientId"]!,
        clientSecret: builder.Configuration["AzureKeyVault:ClientSecret"]!
        ));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Portfolio.Razor.Client._Imports).Assembly);

app.Run();
