using Microsoft.AspNetCore.Identity;
using TaskManagement.Infrastructure.DbContext;
using TaskManagement.Core.Entities.Identity;
using TaskManagement.Infrastructure.ServiceExtension;
using TaskManagement.Services;
using TaskManagement.Services.Interfaces;
using TaskManagement.Services.Map;

var builder = WebApplication.CreateBuilder(args);

// DbContext setup
builder.Services.AddDIServices(builder.Configuration);

// Service DI
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITaskItemService, TaskItemService>();

// register identity with applicationUser
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(option =>
{
    option.Password.RequiredLength = 4;
    option.Password.RequireUppercase = false;
    option.Password.RequireLowercase = false;
    option.Password.RequireDigit = false;
    option.Password.RequireNonAlphanumeric = false;
    option.User.RequireUniqueEmail = true;

}).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

// AutoMapper DI
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

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

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=TaskItem}/{action=Index}/{id?}");

app.Run();
