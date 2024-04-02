using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add HttpClient to the services collection
builder.Services.AddHttpClient();

// Add CoinGeckoService to the services collection
builder.Services.AddScoped<_44_SWAP.Models.CoinGeckoService>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
	options.Cookie.Name = "CoreAuth";
	options.LoginPath = "/RegisterAndLogin/Login";
	options.AccessDeniedPath = "/RegisterAndLogin/Login";
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=HomePage}/{action=Index}/{id?}");

app.Run();
