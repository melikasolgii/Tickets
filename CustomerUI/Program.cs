using Blazored.LocalStorage;
using CustomerUI.Components;
using CustomerUI.Components.Pages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Services;
using Share;
using Tickets.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddRazorComponents().AddInteractiveWebAssemblyComponents().AddInteractiveServerComponents();/*.AddInteractiveServerComponents()*/;

builder.Services.AddBlazoredLocalStorage();

#region Db context

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserService, UserService>();
#endregion

#region Mapping
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();
app.MapRazorPages(); // Maps Razor Pages (if any)
app.MapBlazorHub();  // Maps the Blazor Hub for SignalR communication


app.MapRazorComponents<App>().AddInteractiveWebAssemblyRenderMode().AddInteractiveServerRenderMode();

app.UseAntiforgery();



app.Run();
