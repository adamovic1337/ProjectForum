using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using ProjectForum.Api.Core;
using ProjectForum.API.Core.JWT;
using ProjectForum.Application;
using ProjectForum.Application.Commands;
using ProjectForum.Application.Email;
using ProjectForum.Application.Queries;
using ProjectForum.EfDataAccess;
using ProjectForum.Implementation.Commands;
using ProjectForum.Implementation.Email;
using ProjectForum.Implementation.Logging;
using ProjectForum.Implementation.Profiles;
using ProjectForum.Implementation.Queries;
using ProjectForum.Implementation.Validators;

namespace ProjectForum.API.Core
{
    public static class ApiExtensions
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddTransient<ProjectForumContext>();
            services.AddTransient<IFakerData, FakerData>();
            services.AddAutoMapper(typeof(RoleProfile).Assembly);
            services.AddTransient<IUseCaseLogger, DatabaseUseCaseLogger>();
            services.AddTransient<UseCaseExecutor>();
            services.AddTransient<IEmailSender, SmtpEmailSender>();
            services.AddControllers();
        }

        public static void AddSwaggerToProject(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProjectForum", Version = "v1" });
                    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = "Bearer"
                    });

                    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                },
                                Scheme = "oauth2",
                                Name = "Bearer",
                                In = ParameterLocation.Header,

                            },
                            new List<string>()
                        }
                    });
                }
            );
        }

        public static void AddApplicationActor(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddTransient<IApplicationActor>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();

                var user = accessor.HttpContext.User;

                if (user.FindFirst("ActorData") == null)
                {
                    throw new InvalidOperationException("Actor data doesn't exist in token.");
                }

                var actorString = user.FindFirst("ActorData").Value;

                var actor = JsonConvert.DeserializeObject<JwtActor>(actorString);

                return actor;

            });
        }

        public static void AddJwt(this IServiceCollection services)
        {
            services.AddTransient<JwtManager>();
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
                    ValidIssuer = "asp_api",
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsMyVerySecretKey")),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }

        public static void AddAllValidators(this IServiceCollection services)
        {
            services.AddTransient<CreateCategoryValidator>();
            services.AddTransient<CreateCountryValidator>();
            services.AddTransient<CreateQuestionValidator>();
            services.AddTransient<CreateReplyValidator>();
            services.AddTransient<CreateRoleValidator>();
            services.AddTransient<CreateTagValidator>();
            services.AddTransient<CreateUserValidator>();

            services.AddTransient<UpdateCategoryValidator>();
            services.AddTransient<UpdateCountryValidator>();
            services.AddTransient<UpdateQuestionValidator>();
            services.AddTransient<UpdateReplyValidator>();
            services.AddTransient<UpdateRoleValidator>();
            services.AddTransient<UpdateTagValidator>();
            services.AddTransient<UpdateUserValidator>();
        }

        public static void AddAllCommands(this IServiceCollection services)
        {
            services.AddTransient<ICreateCategoryCommand, EfCreateCategoryCommand>();
            services.AddTransient<ICreateCountryCommand, EfCreateCountryCommand>();
            services.AddTransient<ICreateQuestionCommand, EfCreateQuestionCommand>();
            services.AddTransient<ICreateReplyCommand, EfCreateReplyCommand>();
            services.AddTransient<ICreateRoleCommand, EfCreateRoleCommand>();
            services.AddTransient<ICreateTagCommand, EfCreateTagCommand>();
            services.AddTransient<ICreateUserCommand, EfCreateUserCommand>();
            services.AddTransient<ICreateRoleUserCaseCommand, EfCreateRoleUseCaseCommand>();

            services.AddTransient<IUpdateCategoryCommand, EfUpdateCategoryCommand>();
            services.AddTransient<IUpdateCountryCommand, EfUpdateCountryCommand>();
            services.AddTransient<IUpdateQuestionCommand, EfUpdateQuestionCommand>();
            services.AddTransient<IUpdateReplyCommand, EfUpdateReplyCommand>();
            services.AddTransient<IUpdateRoleCommand, EfUpdateRoleCommand>();
            services.AddTransient<IUpdateTagCommand, EfUpdateTagCommand>();
            services.AddTransient<IUpdateUserCommand, EfUpdateUserCommand>();
            services.AddTransient<IUpdateRoleUseCaseCommand, EfUpdateRoleUseCaseCommand>();

            services.AddTransient<IDeleteCategoryCommand, EfSoftDeleteCategoryCommand>();
            services.AddTransient<IDeleteCountryCommand, EfSoftDeleteCountryCommand>();
            services.AddTransient<IDeleteQuestionCommand, EfSoftDeleteQuestionCommand>();
            services.AddTransient<IDeleteReplyCommand, EfSoftDeleteReplyCommand>();
            services.AddTransient<IDeleteRoleCommand, EfSoftDeleteRoleCommand>();
            services.AddTransient<IDeleteTagCommand, EfSoftDeleteTagCommand>();
            services.AddTransient<IDeleteUserCommand, EfSoftDeleteUserCommand>();
            services.AddTransient<IDeleteRoleUseCaseCommand, EfDeleteRoleUseCaseCommand>();
        }

        public static void AddAllQueries(this IServiceCollection services)
        {
            services.AddTransient<IGetCategoriesQuery, EfGetCategoriesQuery>();
            services.AddTransient<IGetCategoryQuery, EfGetCategoryQuery>();

            services.AddTransient<IGetCountriesQuery, EfGetCountriesQuery>();
            services.AddTransient<IGetCountryQuery, EfGetCountryQuery>();

            services.AddTransient<IGetQuestionsQuery, EfGetQuestionsQuery>();
            services.AddTransient<IGetQuestionQuery, EfGetQuestionQuery>();

            services.AddTransient<IGetRepliesQuery, EfGetRepliesQuery>();
            services.AddTransient<IGetReplyQuery, EfGetReplyQuery>();

            services.AddTransient<IGetRolesQuery, EfGetRolesQuery>();
            services.AddTransient<IGetRoleQuery, EfGetRoleQuery>();

            services.AddTransient<IGetTagsQuery, EfGetTagsQuery>();
            services.AddTransient<IGetTagQuery, EfGetTagQuery>();

            services.AddTransient<IGetUsersQuery, EfGetUsersQuery>();
            services.AddTransient<IGetUserQuery, EfGetUserQuery>();

            services.AddTransient<IGetUseCaseLogQuery, EfGetUseCaseLogsQuery>();

            services.AddTransient<IGetRoleUseCaseQuery, EfGetRoleUseCaseQuery>();

        }
    }
}
