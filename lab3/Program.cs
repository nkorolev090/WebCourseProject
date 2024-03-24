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


//NinjectKernel.Kernel = new StandardKernel(new NinjectRegistration(), new ReposModule());
// Add services to the container.
builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ModelAutoService>();
builder.Services.AddDbContext<ModelAutoService>();
builder.Services.AddScoped<IDbRepository, DbRepositorySQL>();
builder.Services.AddScoped<IRegistrationService, RegistrationService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IMechanicService, MechanicService>();
builder.Services.AddScoped<IUserService, UserService>();
//builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext =
    scope.ServiceProvider.GetRequiredService<ModelAutoService>();
    await AutoServiseDbSeed.InitializeAsync(dbContext);
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
