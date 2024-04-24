using DAL;
using Microsoft.AspNetCore.Identity;
using BLL.Services;
using Interfaces.Services;
using Interfaces.Repository;
using DAL.Repository;
using DomainModel;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });    
});

// Add services to the container.
builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ModelAutoService>();
builder.Services.AddDbContext<ModelAutoService>();
builder.Services.AddScoped<IDbRepository, DbRepositorySQL>();
builder.Services.AddScoped<IRegistrationService, RegistrationService>();
builder.Services.AddScoped<ISlotService, SlotService>();
builder.Services.AddScoped<IBreakdownService, BreakdownService>();
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IMechanicService, MechanicService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = "AutoServiceApp";
    options.LoginPath = "/";
    options.AccessDeniedPath = "/";
    options.LogoutPath = "/";
    options.Events.OnRedirectToLogin = context =>
    {
        context.Response.StatusCode = 401;
        return Task.CompletedTask;
    };
    // Возвращать 401 при вызове недоступных методов для роли
    options.Events.OnRedirectToAccessDenied = context =>
    {
        context.Response.StatusCode = 401;
        return Task.CompletedTask;
    };
});

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext =
    scope.ServiceProvider.GetRequiredService<ModelAutoService>();
    await AutoServiseDbSeed.InitializeAsync(dbContext);
    await AutoServiseDbSeed.CreateUserRoles(scope.ServiceProvider);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
