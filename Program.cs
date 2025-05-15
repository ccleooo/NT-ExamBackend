using Microsoft.OpenApi.Models;
using NetCore.Enums;

var builder = WebApplication.CreateBuilder(args);

NetCore.Global.NUP.Domain = builder.Configuration.GetValue<string>("NUP:Domain");
NetCore.Global.Server.Root = builder.Configuration.GetValue<string>("Server:Root");
NetCore.Global.Server.Env = builder.Configuration.GetValue<Env>("Server:Env");
NetCore.Global.Connection.NUP.String = builder.Configuration.GetValue<string>("NUP:ConnectionString");
NetCore.Global.Connection.BPM.String = builder.Configuration.GetValue<string>("BPM:ConnectionString");


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API",
        Description = "ASP.NET Core Web API ",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Panel}/{action=Index}/{id?}");

app.UseSwagger(options =>
{
    options.SerializeAsV2 = true;
});
app.UseSwaggerUI(options => // UseSwaggerUI is called only in Development.
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.Run();
