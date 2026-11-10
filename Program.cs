using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RaceDay.Data;
using RaceDay.Models.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// FIXED: Look for the environment variable first (Docker), then fallback to appsettings.json (Local)
var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection")
    ?? builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddScoped<IProfileImageService, ProfileImageService>();
builder.Services.AddSingleton<RaceDay.Services.IBlobStorageService, RaceDay.Services.BlobStorageService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    // This will now safely apply migrations to the SQL Server container, not LocalDB

        // Retry loop to wait for SQL Server to be ready
        var retries = 10;
        while (retries > 0)
        {
            try
            {
                db.Database.Migrate();
                break; // Success! Exit the loop.
            }
            catch (Exception ex)
            {
                retries--;
                Console.WriteLine($"Database not ready yet. Retrying in 5 seconds... ({retries} attempts left)");
                if (retries == 0) throw; // If we run out of retries, crash the app.
                Thread.Sleep(5000); // Wait 5 seconds before trying again
            }
        }


        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var roles = new[] { "Admin", "Organiser", "Participant" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }

    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    string email = "admin@gmail.com";
    string password = "Admin@123";

    if (await userManager.FindByEmailAsync(email) == null)
    {
        var user = new ApplicationUser();

        user.UserName = email;
        user.Email = email;
        user.EmailConfirmed = true;

        await userManager.CreateAsync(user, password);
        await userManager.AddToRoleAsync(user, "Admin");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapRazorPages()
   .WithStaticAssets();

app.Run();