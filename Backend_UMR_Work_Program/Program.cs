using Backend_UMR_Work_Program;
using Backend_UMR_Work_Program.Services;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);
var startup = new Startup(builder.Configuration);
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy
                          .AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .SetIsOriginAllowed((host) => true);
                      });
});

startup.ConfigureServices(builder.Services);


// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHostedService<DatabaseService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//RotativaConfiguration.Setup(env);

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthentication();
app.UseAuthorization();
//app.MapControllers();

app.MapControllers();
app.Run();
//"ConnectionString": "Server=.\\SQLEXPRESS;Trusted_Connection=True; Initial Catalog=workprogram;Trusted_Connection=True;MultipleActiveResultSets=true"