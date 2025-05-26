using Microsoft.EntityFrameworkCore;
using PatientRecordCURDWebApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region My hardcoded service registration section.
builder.Services.AddDbContext<AppDbContext>(options =>
{
    // Configure AppDbContext to connect to an Oracle database.
    // The connection string named "DefaultConnection" will be read from appsettings.json.
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection"));
});
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Patient}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
