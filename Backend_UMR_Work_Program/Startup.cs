using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Backend_UMR_Work_Program.Models;
using Backend_UMR_Work_Program.Services;
using System.Net;
using System.Text;
using Microsoft.Extensions.Azure;
using Azure.Core.Extensions;
using Azure.Storage.Blobs;
using Azure.Storage.Queues;
using Backend_UMR_Work_Program.Controllers;
using Backend_UMR_Work_Program.Helpers.AutoMapperSettings;
using Backend_UMR_Work_Program.Helpers;
using Backend_UMR_Work_Program.Controllers.Authentications;
using Backend_UMR_Work_Program.DataModels;
using Rotativa.AspNetCore;
using WKP.Application;
using WKP.Infrastructure;

namespace Backend_UMR_Work_Program
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddCors(options => options.AddPolicy("ApiCorsPolicy", builder =>
            // {
            //    builder.WithOrigins("https://milaxebox.z13.web.core.windows.net", "https://localhost:4200", "http://localhost:8100", "https://localhost:5001", "http://localhost:5001", "10.0.2.2:3000").AllowAnyMethod().AllowAnyHeader();
            // }));


            //services.AddCors(options => options.AddPolicy("ApiCorsPolicy", builder =>
            //{
            //    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            //}));
            services.AddAutoMapper(typeof(MappingProfiles));

            services.AddMvc();
            //AddJsonOptions(opt => { opt.JsonSerializerOptions.IgnoreNullValues = true; });
            
            services.AddControllers();

            //Register Project DependencyInjection files
            services.AddApplication()
                    .AddInfrastructure((ConfigurationManager)Configuration);

            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            ElpsServices._elpsAppEmail = Configuration.GetSection("ElpsKeys").GetSection("elpsAppEmail").Value.ToString();
            ElpsServices._elpsBaseUrl = Configuration.GetSection("ElpsKeys").GetSection("elpsBaseUrl").Value.ToString();
            ElpsServices.public_key = Configuration.GetSection("ElpsKeys").GetSection("PK").Value.ToString();
            ElpsServices._elpsAppKey = Configuration.GetSection("ElpsKeys").GetSection("elpsSecretKey").Value.ToString();

            services.AddTransient<EvaluationController>();
            services.AddTransient<Account>();
            services.AddTransient<AuthController>();
            services.AddTransient<Connection>();
            services.AddTransient<HelpersController>();
            services.AddTransient<Presentation>();
            services.AddTransient<WorkProgrammeController>();
            services.AddTransient<AdminController>();
            services.AddTransient<DashboardController>();
            services.AddTransient<TypeOfPaymentController>();
            services.AddTransient<DatabaseService>();
            services.AddTransient<BlobService>();
            services.AddTransient<ElpsUtility>();
            services.AddTransient<Seeder>();
            services.AddTransient<PaymentService>();
            services.AddTransient<WorkProgrammeService>();
            services.AddTransient<ApplicationService>();
            services.AddTransient<AppProcessFlowService>();
            services.AddTransient<HelperService>();
            services.AddTransient<AccountingService>();
            services.AddTransient<FeeService>();
            services.AddTransient<TypeOfPaymentService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped(x => new BlobServiceClient(Configuration.GetValue<string>("AzureBlobStorage")));

            services.AddDbContext<WKP_DBContext>(options =>
                options.UseSqlServer(Configuration["Data:Wkpconnect:ConnectionString"],
                options => options.EnableRetryOnFailure(
                    maxRetryCount: 6,
                    maxRetryDelay: System.TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null)
                ));
            services.Configure<SmtpSettings>(Configuration.GetSection("SmtpSettings"));
            //services.AddTransient<PaymentService>();
            services.AddSingleton<IMailer, Mailer>();
            services.AddAzureClients(builder =>
            {
                builder.AddBlobServiceClient(Configuration["ConnectionStrings:AzureBlobStorage:blob"], preferMsi: true);
                builder.AddQueueServiceClient(Configuration["ConnectionStrings:AzureBlobStorage:queue"], preferMsi: true);
            });
            var scope = services.BuildServiceProvider().GetService<IServiceScopeFactory>();
            using (var sc = scope.CreateScope())
            {
                var serv = sc.ServiceProvider.GetService<Seeder>();
                serv.Seed();
            }

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // global cors policy
            //app.UseCors(x => x
            //    .AllowAnyOrigin()
            //    .AllowAnyMethod()
            //    .SetIsOriginAllowed((host) => true)
            //    .AllowAnyHeader());

            //app.UseCors("ApiCorsPolicy");
            //app.UseMiddleware(typeof(CorsMiddleware));

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
                app.UseHsts();
            }

            RotativaConfiguration.Setup((Microsoft.AspNetCore.Hosting.IHostingEnvironment)env);

            //app.UseExceptionHandler(
            //    options =>
            //    {
            //        options.Run(
            //            async context =>
            //            {
            //                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            //                context.Response.ContentType = "text/html";
            //                var ex = context.Features.Get<IExceptionHandlerFeature>();
            //                if (ex != null)
            //                {
            //                    var err = $"<h1>Error: {ex.Error.Message}</h1>{ex.Error.StackTrace }";
            //                    await context.Response.WriteAsync(err).ConfigureAwait(false);
            //                }
            //            });
            //    }
            //);



        }
    }

    public class CorsMiddleware
    {
        private readonly RequestDelegate _next;

        public CorsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            context.Response.Headers.Add("Access-Control-Allow-Credentials", "true");
            // Added "Accept-Encoding" to this list
            context.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, X-CSRF-Token, X-Requested-With, Accept, Accept-Version, Accept-Encoding, Content-Length, Content-MD5, Date, X-Api-Version, X-File-Name");
            context.Response.Headers.Add("Access-Control-Allow-Methods", "POST,GET,PUT,PATCH,DELETE,OPTIONS");
            // New Code Starts here
            if (context.Request.Method == "OPTIONS")
            {
                context.Response.StatusCode = (int)HttpStatusCode.OK;
                await context.Response.WriteAsync(string.Empty);
            }
            // New Code Ends here

            await _next(context);
        }
    }
    internal static class StartupExtensions
    {
        public static IAzureClientBuilder<BlobServiceClient, BlobClientOptions> AddBlobServiceClient(this AzureClientFactoryBuilder builder, string serviceUriOrConnectionString, bool preferMsi)
        {
            if (preferMsi && Uri.TryCreate(serviceUriOrConnectionString, UriKind.Absolute, out Uri serviceUri))
            {
                return builder.AddBlobServiceClient(serviceUri);
            }
            else
            {
                return builder.AddBlobServiceClient(serviceUriOrConnectionString);
            }
        }
        public static IAzureClientBuilder<QueueServiceClient, QueueClientOptions> AddQueueServiceClient(this AzureClientFactoryBuilder builder, string serviceUriOrConnectionString, bool preferMsi)
        {
            if (preferMsi && Uri.TryCreate(serviceUriOrConnectionString, UriKind.Absolute, out Uri serviceUri))
            {
                return builder.AddQueueServiceClient(serviceUri);
            }
            else
            {
                return builder.AddQueueServiceClient(serviceUriOrConnectionString);
            }
        }
    }
}


