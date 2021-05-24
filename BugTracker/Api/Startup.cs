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
using Application.Commands.CompanyApplicationUserCommands;
using Application.Commands.ProjectApplicationUserCommands;
using Implementation.EfCommands.EfApplicationUserCommands;
using Implementation.EfCommands.EfRoleCommands;
using Implementation.EfCommands.EfCompanyCommands;
using Implementation.EfCommands.EfProjectCommands;
using Implementation.EfCommands.EfTicketCommands;
using Implementation.EfCommands.EfCommentCommands;
using Implementation.EfCommands.EfCompanyApplicationUserCommands;
using Implementation.EfCommands.EfProjectApplicationUserCommands;
using Application.Queries.ApplicationUserQueries;

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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api", Version = "v1" });
            });

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddDbContext<BugTrackerContext>();

            services.AddTransient<IGetRolesCommand, EfGetRolesCommand>();
            services.AddTransient<IGetOneRoleCommand, EfGetOneRoleCommand>();
            services.AddTransient<IAddRoleCommand, EfAddRoleCommand>();
            services.AddTransient<IChangeRoleCommand, EfChangeRoleCommand>();
            services.AddTransient<IRemoveRoleCommand, EfRemoveRoleCommand>();

            services.AddTransient<IGetCompaniesCommand, EfGetCompaniesCommand>();
            services.AddTransient<IGetOneCompanyCommand, EfGetOneCompanyCommand>();
            services.AddTransient<IAddCompanyCommand, EfAddCompanyCommand>();
            services.AddTransient<IChangeCompanyCommand, EfChangeCompanyCommand>();
            services.AddTransient<IRemoveCompanyCommand, EfRemoveCompanyCommand>();

            services.AddTransient<IGetProjectsCommand, EfGetProjectsCommand>();
            services.AddTransient<IGetOneProjectCommand, EfGetOneProjectCommand>();
            services.AddTransient<IAddProjectCommand, EfAddProjectCommand>();
            services.AddTransient<IChangeProjectCommand, EfChangeProjectCommand>();
            services.AddTransient<IRemoveProjectCommand, EfRemoveProjectCommand>();

            services.AddTransient<IAddApplicationUserCommand, EfAddApplicationUserCommand>();
            services.AddTransient<IGetApplicationUserByEmailQuery, EfGetApplicationUserByEmailCommand>();
            services.AddTransient<IGetApplicationUsersQuery, EfGetApplicationUsersCommand>();
            services.AddTransient<IGetOneApplicationUserQuery, EfGetOneApplicationUserCommand>();
            services.AddTransient<IChangeApplicationUserCommand, EfChangeApplicationUserCommand>();
            services.AddTransient<IRemoveApplicationUserCommand, EfRemoveApplicationUserCommand>();

            services.AddTransient<IGetTicketsCommand, EfGetTicketsCommand>();
            services.AddTransient<IGetOneTicketCommand, EfGetOneTicketCommand>();
            services.AddTransient<IAddTicketCommand, EfAddTicketCommand>();
            services.AddTransient<IChangeTicketCommand, EfChangeTicketCommand>();
            services.AddTransient<IRemoveTicketCommand, EfRemoveTicketCommand>();

            services.AddTransient<IGetCommentsCommand, EfGetCommentsCommand>();
            services.AddTransient<IAddCommentCommand, EfAddCommentCommand>();
            services.AddTransient<IGetOneCommentCommand, EfGetOneCommentCommand>();
            services.AddTransient<IChangeCommentCommand, EfChangeCommentCommand>();
            services.AddTransient<IRemoveCommentCommand, EfRemoveCommentCommand>();

            services.AddTransient<IAddCompanyApplicationUserCommand, EfAddCompanyApplicationUserCommand>();
            services.AddTransient<IGetOneCompanyApplicationUserCommand, EfGetOneCompanyApplicationUserCommand>();
            services.AddTransient<IChangeCompanyApplicationUserCommand, EfChangeCompanyApplicationUserCommand>();

            services.AddTransient<IAddProjectApplicationUserCommand, EfAddProjectApplicationUserCommand>();
            services.AddTransient<IGetApplicationUsersForProjectCommand, EfGetApplicationUsersForProjectCommand>();

            services.AddAutoMapper(typeof(DefaultProfile));
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

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
