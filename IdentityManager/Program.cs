using IdentityManager.Models.IdentityEntityy;
using IdentityManager.StartupExtensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.ServiceConfiguration(builder.Configuration);


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await DbInitializer.SeedAdminAndRolesAsync(services);
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

const string identityManagerPath = "IdentityManager";
app.Run();
