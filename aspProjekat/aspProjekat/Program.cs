using aspProjekat.API.DTO;
using aspProjekat.API.JWT;
using aspProjekat.API.JWT.TokenStorage;
using aspProjekat.DataAccess;
using Bugsnag.AspNet.Core;
using aspProjekat.API.Extensions;
using Microsoft.EntityFrameworkCore;
using aspProjekat.Application.Uploads;
using aspProjekat.Application.UseCaseHandling;
using aspProjekat.Implementation.Uploads;
using aspProjekat.Application.Logging;
using aspProjekat.Application.UseCases.Commands;
using aspProjekat.Application.UseCases.Queries;
using aspProjekat.Implementation.Logging;
using aspProjekat.Implementation.UseCases.Commands;
using aspProjekat.Implementation.Validators;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using aspProjekat.Application;
using aspProjekat.Implementation.UseCases.Queries;
using aspProjekat.API.Middleware;
using aspProjekat.DataAccess.Seeders;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var appSettings = new AppSettings();
builder.Configuration.Bind(appSettings);

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("Jwt"));
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("BugSnagKey"));
Console.WriteLine($"Issuer: {appSettings.Jwt?.Issuer}, SecretKey: {appSettings.Jwt?.SecretKey}, DurationSeconds: {appSettings.Jwt?.DurationSeconds}");
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ITokenStorage, InMemoryTokenStorage>();

builder.Services.AddTransient<JwtManager>(x =>
{
    var context = x.GetService<aspProjekatContext>();
    var tokenStorage = x.GetService<ITokenStorage>();
    return new JwtManager(context, appSettings.Jwt.Issuer, appSettings.Jwt.SecretKey, appSettings.Jwt.DurationSeconds, tokenStorage);
});

builder.Services.AddBugsnag(configuration => {
    configuration.ApiKey = appSettings.BugSnagKey;
});

builder.Services.AddLogger();
builder.Services.AddValidators();

builder.Services.AddDbContext<aspProjekatContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddTransient<QueryHandler>();
builder.Services.AddTransient<IBase64FileUploader, Base64FileUploader>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IApplicationUser>(x =>
{
    var accessor = x.GetService<IHttpContextAccessor>();
    var header = accessor.HttpContext.Request.Headers["Authorization"];

    var data = header.ToString().Split("Bearer ");

    if (data.Length < 2)
    {
        return new UnauthorisedUser();
    }

    var handler = new JwtSecurityTokenHandler();

    var tokenObj = handler.ReadJwtToken(data[1].ToString());

    var claims = tokenObj.Claims;

    var email = claims.First(x => x.Type == "Email").Value;
    var id = claims.First(x => x.Type == "Id").Value;
    var useCases = claims.First(x => x.Type == "UseCases").Value;

    List<int> useCaseIds = JsonConvert.DeserializeObject<List<int>>(useCases);

    return new JwtUser
    {
        Email = email,
        AllowedUseCases = useCaseIds,
        Id = int.Parse(id)
    };
});

builder.Services.AddTransient<ISearchAlbumQuery, EfSearchAlbumQuery>();
builder.Services.AddTransient<IGetUsersQuery, EfGetUsersQuery>();
builder.Services.AddTransient<IGetOrdersQuery, EfGetOrdersQuery>();
builder.Services.AddTransient<ICreateOrderCommand, EfCreateOrderCommand>();
builder.Services.AddTransient<ICreateAlbumCommand, EfCreateAlbumCommand>();
builder.Services.AddTransient<IRegisterUserCommand, EfRegisterUserCommand>();
builder.Services.AddTransient<IUseCaseLogger, EfUseCaseLogger>();
builder.Services.AddTransient<ICommandHandler, CommandHandler>();
builder.Services.AddTransient<RegisterUserValidator>();
builder.Services.AddTransient<CreateAlbumValidator>();

builder.Services.AddControllers();

builder.Services.AddJwt(appSettings);

builder.Services.AddTransient<IQueryHandler>(x =>
{
    var user = x.GetService<IApplicationUser>();
    var logger = x.GetService<IUseCaseLogger>();
    var queryHandler = new QueryHandler();
    var timeTrackingHandler = new TimeTrackingQueryHandler(queryHandler);
    var loggingHandler = new LoggingQueryHandler(timeTrackingHandler, user, logger);
    var decoration = new AuthorizationQueryHandler(user, loggingHandler);

    return decoration;
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        Seeder.Initialize(services);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred seeding the DB.");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
