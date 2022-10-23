using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PlastikMarketim.EntityFrameworkCore;
using PlastikMarketim.Localization;
using PlastikMarketim.Web.Menus;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Account.Web;
using Volo.Abp.AspNetCore.Authentication.JwtBearer;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Autofac;
using Volo.Abp.AutoMapper;
using Volo.Abp.Identity.Web;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.SettingManagement.Web;
using Volo.Abp.Swashbuckle;
using Volo.Abp.TenantManagement.Web;
using Volo.Abp.UI.Navigation;
using Volo.Abp.UI.Navigation.Urls;
using Volo.Abp.VirtualFileSystem;

namespace PlastikMarketim.Web
{
    [DependsOn(
        typeof(PlastikMarketimHttpApiModule),
        typeof(PlastikMarketimApplicationModule),
        typeof(PlastikMarketimEntityFrameworkCoreModule),
        typeof(AbpAutofacModule),
        typeof(AbpIdentityWebModule),
        typeof(AbpSettingManagementWebModule),
        typeof(AbpAccountWebIdentityServerModule),
        typeof(AbpAspNetCoreMvcUiBasicThemeModule),
        typeof(AbpAspNetCoreAuthenticationJwtBearerModule),
        typeof(AbpTenantManagementWebModule),
        typeof(AbpAspNetCoreSerilogModule),
        typeof(AbpSwashbuckleModule)
        )]
    public class PlastikMarketimWebModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
            {
                options.AddAssemblyResource(
                    typeof(PlastikMarketimResource),
                    typeof(PlastikMarketimDomainModule).Assembly,
                    typeof(PlastikMarketimDomainSharedModule).Assembly,
                    typeof(PlastikMarketimApplicationModule).Assembly,
                    typeof(PlastikMarketimApplicationContractsModule).Assembly,
                    typeof(PlastikMarketimWebModule).Assembly
                );
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var hostingEnvironment = context.Services.GetHostingEnvironment();
            var configuration = context.Services.GetConfiguration();

            context.Services.AddAntiforgery(options =>
            {
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                options.Cookie.HttpOnly = true;
                options.SuppressXFrameOptionsHeader = true;
            });

            context.Services.ConfigureApplicationCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromDays(365 * 1000);
            });

            //ConfigureAppSetting(context, configuration);
            ConfigureUrls(configuration);
            ConfigureBundles();
            ConfigureAuthentication(context, configuration);
            ConfigureAutoMapper();
            ConfigureVirtualFileSystem(hostingEnvironment);
            ConfigureLocalizationServices();
            ConfigureNavigationServices();
            ConfigureAutoApiControllers();
            //ConfigureSwaggerServices(context.Services);
            ConfigureRedirectStrategy(context);
            context.Services.AddLogging();
        }

        private void ConfigureRedirectStrategy(ServiceConfigurationContext context)
        {
            context.Services
                .ConfigureApplicationCookie(options =>
                    options.Events.OnRedirectToLogin = context =>
                    {
                        if (context.Request.Path.StartsWithSegments("/api"))
                        {
                            context.Response.Headers["Location"] = context.RedirectUri;
                            context.Response.StatusCode = 401;
                        }
                        else
                        {
                            context.Response.Redirect(context.RedirectUri);
                        }
                        return Task.CompletedTask;
                    });
        }

        private void ConfigureAppSetting(ServiceConfigurationContext context, IConfiguration configuration)
        {
            //context.Services.Configure<ConstraintSettings>(configuration.GetSection("ConstraintSettings"));
            //context.Services.Configure<DefaultSettings>(configuration.GetSection("DefaultSettings"));
            //context.Services.Configure<FtpSettings>(configuration.GetSection("FtpSettings"));
            //context.Services.Configure<SftpSettings>(configuration.GetSection("SftpSettings"));
            //context.Services.Configure<SmtpSettings>(configuration.GetSection("SmtpSettings"));
            //context.Services.Configure<SftpMatchSettings>(configuration.GetSection("SftpMatchSettings"));
            //context.Services.Configure<ItsServiceSettings>(configuration.GetSection("ItsServiceSettings"));
            //configuration.GetSection("ConstraintSettings").Bind(XmlToDtoHelper.ConstraintSettings);
        }

        private void ConfigureUrls(IConfiguration configuration)
        {
            Configure<AppUrlOptions>(options =>
            {
                options.Applications["MVC"].RootUrl = configuration["App:SelfUrl"];
            });
        }

        private void ConfigureBundles()
        {
            Configure<AbpBundlingOptions>(options =>
            {
                options.StyleBundles.Configure(
                    "css_files",
                    bundle =>
                    {
                        bundle.AddFiles("/global_assets/css/icons/icomoon/styles.min.css");
                        bundle.AddFiles("/global_assets/css/icons/material/styles.min.css");
                        bundle.AddFiles("/assets/css/bootstrap.min.css");
                        bundle.AddFiles("/assets/css/bootstrap_limitless.min.css");
                        bundle.AddFiles("/assets/css/layout.min.css");
                        bundle.AddFiles("/assets/css/components.min.css");
                        bundle.AddFiles("/assets/css/colors.min.css");
                        bundle.AddFiles("/libs/abp/aspnetcore-mvc-ui-theme-shared/datatables/datatables-styles.css");
                        bundle.AddFiles("/libs/bootstrap-datepicker/bootstrap-datepicker.min.css");
                        bundle.AddFiles("/global_assets/css/icons/fontawesome/styles.min.css");
                        bundle.AddFiles("/libs/toastr/toastr.min.css");
                        bundle.AddFiles("/libs/datatables.net-bs4/css/dataTables.bootstrap4.css");
                        bundle.AddFiles("/assets/css/custom.css");
                    });
            });

            Configure<AbpBundlingOptions>(options =>
            {
                options.StyleBundles.Configure(
                    "custom_js_files",
                    bundle =>
                    {
                        bundle.AddFiles("/assests/js/custom.js");
                    });
            });
        }

        private void ConfigureAuthentication(ServiceConfigurationContext context, IConfiguration configuration)
        {
            var key = Encoding.ASCII.GetBytes(configuration["AppSettings:SecretKey"]);

            context.Services.AddAuthentication().AddCookie(options =>
            {
                options.CookieManager = new ChunkingCookieManager();
                options.Cookie.HttpOnly = true;
                options.Cookie.SameSite = SameSiteMode.None;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                //options.ExpireTimeSpan = TimeSpan.MaxValue;
            }).AddJwtBearer(options =>
                {
                    options.Authority = configuration["AuthServer:Authority"];
                    options.RequireHttpsMetadata = Convert.ToBoolean(configuration["AuthServer:RequireHttpsMetadata"]);
                    options.Audience = "PlastikMarketim";
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
        }

        private void ConfigureAutoMapper()
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<PlastikMarketimWebModule>();
            });
        }

        private void ConfigureVirtualFileSystem(IWebHostEnvironment hostingEnvironment)
        {
            if (hostingEnvironment.IsDevelopment())
            {
                Configure<AbpVirtualFileSystemOptions>(options =>
                {
                    options.FileSets.ReplaceEmbeddedByPhysical<PlastikMarketimDomainSharedModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}PlastikMarketim.Domain.Shared"));
                    options.FileSets.ReplaceEmbeddedByPhysical<PlastikMarketimDomainModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}PlastikMarketim.Domain"));
                    options.FileSets.ReplaceEmbeddedByPhysical<PlastikMarketimApplicationContractsModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}PlastikMarketim.Application.Contracts"));
                    options.FileSets.ReplaceEmbeddedByPhysical<PlastikMarketimApplicationModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}PlastikMarketim.Application"));
                    options.FileSets.ReplaceEmbeddedByPhysical<PlastikMarketimWebModule>(hostingEnvironment.ContentRootPath);
                });
            }
        }

        private void ConfigureLocalizationServices()
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                //options.Languages.Add(new LanguageInfo("en", "en", "English"));
                options.Languages.Add(new LanguageInfo("tr", "tr", "Türkçe"));
            });
        }

        private void ConfigureNavigationServices()
        {
            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new PlastikMarketimMenuContributor());
            });
        }

        private void ConfigureAutoApiControllers()
        {
            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.ConventionalControllers.Create(typeof(PlastikMarketimApplicationModule).Assembly);
            });
        }

        private void ConfigureSwaggerServices(IServiceCollection services)
        {
            services.AddAbpSwaggerGen(
                options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo { Title = "PlastikMarketim API", Version = "v1" });
                    options.DocInclusionPredicate((docName, description) => true);
                    options.CustomSchemaIds(type => type.FullName);
                    options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        In = ParameterLocation.Header,
                        Description = "Please insert JWT with Bearer into field",
                        Name = "Authorization",
                        Type = SecuritySchemeType.ApiKey
                    });
                    options.AddSecurityRequirement(new OpenApiSecurityRequirement {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] { }
                        }
                    });
                }
            );
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAbpRequestLocalization();

            if (!env.IsDevelopment())
            {
                app.UseErrorPage();
            }

            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("X-Frame-Options", "DENY");
                await next();
            });

            app.UseCookiePolicy(new CookiePolicyOptions
            {
                HttpOnly = HttpOnlyPolicy.Always,
                Secure = CookieSecurePolicy.Always,
            });

            app.UseCorrelationId();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseJwtTokenMiddleware();

            //if (MultiTenancyConsts.IsEnabled)
            //{
            //    app.UseMultiTenancy();
            //}

            app.UseUnitOfWork();
            app.UseIdentityServer();
            app.UseAuthorization();
            //app.UseSwagger();
            //app.UseAbpSwaggerUI(options =>
            //{
            //    options.SwaggerEndpoint("/swagger/v1/swagger.json", "PlastikMarketim API");
            //});
            app.UseAuditing();
            app.UseAbpSerilogEnrichers();
            app.UseConfiguredEndpoints();
        }
    }
}
