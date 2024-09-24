using Microsoft.AspNetCore.HttpOverrides;
using SaccoOps.Extensions;
using NLog;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(),
"/nlog.config"));


// Add services to the container.
builder.Services.ConfigureCors();
builder.Services.ConfigureIISOptions();
builder.Services.ConfigureLoggerService();
builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureRepositorymanager();
builder.Services.ConfigureserviceManager();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.AddAutoMapper(typeof(Program));


builder.Services.AddControllers()
.AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();
else
    app.UseHsts();


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});
app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
