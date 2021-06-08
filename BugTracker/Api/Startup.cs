using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using DataAccess;
using AutoMapper;
using Domain;
using Application.MapperProfiles;
using Application.Commands.Roles;
using Application.Commands.CompanyCommands;
using Application.Commands.ProjectCommands;
using Application.Commands.ApplicationUserCommands;
using Application.Commands.TicketCommands;
using Application.Commands.CommentCommands;
using Application.Commands.CompanyApplicationUserRoleCommands;
using Application.Commands.ProjectApplicationUserCommands;
using Implementation.EfCommands.EfApplicationUserCommands;
using Implementation.EfCommands.EfRoleCommands;
using Implementation.EfCommands.EfCompanyCommands;
using Implementation.EfCommands.EfProjectCommands;
using Implementation.EfCommands.EfTicketCommands;
using Implementation.EfCommands.EfCommentCommands;
using Implementation.EfCommands.EfCompanyApplicationUserRoleCommands;
using Implementation.EfCommands.EfProjectApplicationUserCommands;
using Application.Queries.CommentQueries;
using Application.Queries.ApplicationUserQueries;
using Application.Queries.CompanyApplicationUserQueries;
using Application.Queries.CompanyQueries;
using Application.Queries.ProjectApplicationUserQueries;
using Application.Queries.ProjectQueries;
using Application.Queries.RoleQueries;
using Application.Queries.TicketQueries;
using Implementation.Queries.ApplicationUserQueries;
using Implementation.Queries.CommentQueries;
using Implementation.Queries.CompanyApplicationUserQueries;
using Implementation.Queries.CompanyQueries;
using Implementation.Queries.ProjectApplicationUserQueries;
using Implementation.Queries.ProjectCommandsQueries;
using Implementation.Queries.RoleQueries;
using Implementation.Queries.TicketCommandsQueries;
using Application;
using Application.Interfaces;
using Implementation.Logging;
using Api.Core;
using Implementation.Validators;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Application.Queries.ApplicationUserCaseQueries;
using Implementation.Queries.ApplicationUserCaseQueries;
using Application.Commands.ApplicationUserCaseCommands;
using Implementation.EfCommands.EfApplicationUserCaseCommands;
using Application.Settings;
using Application.Email;
using Implementation.Email;
using Application.Queries.UseCaseQueries;
using Implementation.Queries.UseCaseLogQueries;
using Application.Commands.AttachmentCommands;
using Implementation.EfCommands.EfAttachmentCommands;
using Application.Queries.AttachmentQueries;
using Implementation.Queries.AttachmentQueries;

namespace Api
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api", Version = "v1" });
            });

            //services.AddControllersWithViews()
            //    .AddNewtonsoftJson(options =>
            //    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            //);

            services.AddDbContext<BugTrackerContext>();

            services.AddTransient<IGetRolesQuery, EfGetRolesQuery>();
            services.AddTransient<IGetOneRoleQuery, EfGetOneRoleQuery>();
            services.AddTransient<IAddRoleCommand, EfAddRoleCommand>();
            services.AddTransient<IChangeRoleCommand, EfChangeRoleCommand>();
            services.AddTransient<IRemoveRoleCommand, EfRemoveRoleCommand>();

            services.AddTransient<IGetCompaniesQuery, EfGetCompaniesQuery>();
            services.AddTransient<IGetOneCompanyQuery, EfGetOneCompanyQuery>();
            services.AddTransient<IAddCompanyCommand, EfAddCompanyCommand>();
            services.AddTransient<IChangeCompanyCommand, EfChangeCompanyCommand>();
            services.AddTransient<IRemoveCompanyCommand, EfRemoveCompanyCommand>();

            services.AddTransient<IGetProjectsQuery, EfGetProjectsQuery>();
            services.AddTransient<IGetOneProjectQuery, EfGetOneProjectQuery>();
            services.AddTransient<IAddProjectCommand, EfAddProjectCommand>();
            services.AddTransient<IChangeProjectCommand, EfChangeProjectCommand>();
            services.AddTransient<IRemoveProjectCommand, EfRemoveProjectCommand>();

            services.AddTransient<IAddApplicationUserCommand, EfAddApplicationUserCommand>();
            services.AddTransient<IGetApplicationUserByEmailQuery, EfGetApplicationUserByEmailQuery>();
            services.AddTransient<IGetApplicationUsersQuery, EfGetApplicationUsersQuery>();
            services.AddTransient<IGetOneApplicationUserQuery, EfGetOneApplicationUserQuery>();
            services.AddTransient<IChangeApplicationUserCommand, EfChangeApplicationUserCommand>();
            services.AddTransient<IRemoveApplicationUserCommand, EfRemoveApplicationUserCommand>();

            services.AddTransient<IGetTicketsQuery, EfGetTicketsQuery>();
            services.AddTransient<IGetOneTicketQuery, EfGetOneTicketQuery>();
            services.AddTransient<IAddTicketCommand, EfAddTicketCommand>();
            services.AddTransient<IChangeTicketCommand, EfChangeTicketCommand>();
            services.AddTransient<IRemoveTicketCommand, EfRemoveTicketCommand>();

            services.AddTransient<IGetCommentsQuery, EfGetCommentsQuery>();
            services.AddTransient<IAddCommentCommand, EfAddCommentCommand>();
            services.AddTransient<IGetOneCommentQuery, EfGetOneCommentQuery>();
            services.AddTransient<IChangeCommentCommand, EfChangeCommentCommand>();
            services.AddTransient<IRemoveCommentCommand, EfRemoveCommentCommand>();

            services.AddTransient<IAddCompanyApplicationUserRoleCommand, EfAddCompanyApplicationUserRoleCommand>();
            services.AddTransient<IGetOneCompanyApplicationUserRoleQuery, EfGetOneCompanyApplicationUserRoleQuery>();
            services.AddTransient<IChangeCompanyApplicationUserRoleCommand, EfChangeCompanyApplicationUserRoleCommand>();

            services.AddTransient<IAddProjectApplicationUserCommand, EfAddProjectApplicationUserCommand>();
            services.AddTransient<IGetApplicationUsersForProjectQuery, EfGetApplicationUsersForProjectQuery>();

            services.AddTransient<IGetCasesByApplicationUserIdQuery, EfGetCasesByApplicationUserIdQuery>();
            services.AddTransient<IAddApplicationUserCaseCommand, EfAddApplicationUserCaseCommand>();
            services.AddTransient<IGetOneApplicationUserCaseQuery, EfGetOneApplicationUserCaseQuery>();
            services.AddTransient<IRemoveApplicationUserCaseCommand, EfRemoveApplicationUserCaseCommand>();

            services.AddTransient<IGetUseCaseLogsQuery, EfGetUseCaseLogsQuery>();

            services.AddTransient<IAddAttachmentCommand, EfAddAttachmentCommand>();
            services.AddTransient<IChangeAttachmentCommand, EfChangeAttachmentCommand>();
            services.AddTransient<IRemoveAttachmentCommand, EfRemoveAttachmentCommand>();
            services.AddTransient<IGetAttachmentsByTicketIdQuery, EfGetAttachmentsByTicketIdQuery>();
            services.AddTransient<IGetOneAttachmentQuery, EfGetOneAttachmentQuery>();

            services.AddTransient<IEmailSender, SmtpEmailSender>();

            services.AddTransient<IApplicationActor, AdminFakeApiActor>();
            services.AddHttpContextAccessor();
            services.AddTransient<IApplicationActor>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();
                var user = accessor.HttpContext.User;

                if (user.FindFirst("ActorData") == null)
                {
                    return new AnonymousActor();
                }

                var actorString = user.FindFirst("ActorData").Value;

                var actor = JsonConvert.DeserializeObject<JwtActor>(actorString);

                return actor;
            });

            services.AddTransient<UseCaseExecutor>();
            services.AddTransient<IUseCaseLogger, ConsoleUseCaseLogger>();
            services.AddTransient<IUseCaseLogger, DatabaseUseCaseLogger>();

            services.AddTransient<AddApplicationUserValidator>();
            services.AddTransient<ChangeApplicationUserValidator>();
            services.AddTransient<LoginValidator>();
            services.AddTransient<AddCommentValidator>();
            services.AddTransient<ChangeCommentValidator>();
            services.AddTransient<AddCompanyApplicationUserRoleValidator>();
            services.AddTransient<ChangeCompanyApplicationUserRoleValidator>();
            services.AddTransient<AddCompanyValidator>();
            services.AddTransient<ChangeCompanyValidator>();
            services.AddTransient<AddProjectApplicationUserValidator>();
            services.AddTransient<AddProjectValidator>();
            services.AddTransient<ChangeProjectValidator>();
            services.AddTransient<AddRoleValidator>();
            services.AddTransient<ChangeRoleValidator>();
            services.AddTransient<AddTicketValidator>();
            services.AddTransient<ChangeTicketValidator>();
            services.AddTransient<AddApplicationUserCaseValidator>();
            services.AddTransient<RemoveApplicationUserCaseValidator>();
            services.AddTransient<AddAttachmentValidator>();
            services.AddTransient<ChangeAttachmentValidator>();

            services.AddTransient<JwtManager>();

            services.AddAutoMapper(typeof(DefaultProfile));

            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = Configuration["JwtSettings:Issuer"],
                    ValidateIssuer = true,
                    ValidAudience = Configuration["JwtSettings:Audience"],
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtSettings:Secret"])),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.Configure<JwtSettings>(Configuration.GetSection("JwtSettings"));
            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1"));
            }

            app.UseCors(x =>
            {
                x.AllowAnyOrigin();
                x.AllowAnyMethod();
                x.AllowAnyHeader();
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
