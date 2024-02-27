using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using PDF.Core.Options;
using PDF.Data;
using PDF.Data.Implementation;
using PDF.Data.Interface;
using PDF.Implementations;
using PDF.Implementations.Implementations.Interfaces;
using PDF.Implementations.Interfaces;
using PDF.Implementations.PDFConfigs.PDFFactoryImplementation.GenerationService;
using PDF.Implementations.Reports;
using PDF.Models.Enums;
using PDF.PDFGeneration.AutoMapper;
using PDF.PDFGeneration.ViewRender;
using PDF.Services.Implementations;
using PDF.Services.Interfaces;
using SqlAlias;
using System;
using System.IO.Compression;

namespace PDF.PDFGeneration
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
            services.AddHttpClient();
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddMvc()
                    .AddRazorRuntimeCompilation();

            services.Configure<ConnectOptions>(option => Configuration.GetSection("Connect").Bind(option));
            services.Configure<VerifyOptions>(option => Configuration.GetSection("Verify").Bind(option));
            services.Configure<SelectPdfOptions>(option => Configuration.GetSection("SelectPdf").Bind(option));
            // services.Configure<KeyVaultKeyStoreProviderOptions>(option => Configuration.GetSection("KeyVaultKeyStoreProviderOptions").Bind(option));
            services.Configure<BrotliCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Fastest;
            });

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new PDFMappingProfile());
            });

            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.TryAddSingleton<IPdfGenerationService, PdfGenerationService>();
            services.TryAddSingleton<IReportFactory, ReportFactory>();
            services.TryAddSingleton<IValuationReportService, ValuationReportService>();
            services.TryAddSingleton<ISuitabilityReportService, SuitabilityReportService>();
            services.TryAddSingleton<ITransferReportService, TransferReportService>();
            services.TryAddSingleton<IValuationRepository, ValuationRepository>();
            services.TryAddSingleton<ISuitabilityRepository, SuitabilityRepository>();
            services.TryAddSingleton<ITransferRepository, TransferRepository>();
            services.TryAddSingleton<ICostDisclosureReportService, CostDisclosureReportService>();
            services.TryAddSingleton<ICostDisclosureRepository, CostDisclosureRepository>();
            services.TryAddSingleton<IClientReportService, ClientReportService>();
            services.TryAddSingleton<IClientReportRepository, ClientReportRepository>();
            services.TryAddSingleton<IRenderView, RenderView>();
            services.TryAddSingleton<VerifyReport>();

            services.Configure<RepositoryOptions>(option =>
            {
                option.ConnectionString = Aliases.Map(Configuration.GetConnectionString("DefaultConnection"));
                option.MrConnectionString = Aliases.Map(Configuration.GetConnectionString("MRConnection"));
            });
            services.Configure<CurrentUrl>(Configuration.GetSection("CurrentUrl"));

            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = ApiKeyAuthenticationOptions.DefaultScheme;
            //    options.DefaultChallengeScheme = ApiKeyAuthenticationOptions.DefaultScheme;
            //}).AddApiKeySupport(_ => { });

            // ConfigureSecurity(services);

            services.AddTransient<Func<ReportServiceTypes, IReport>>(serviceProvider => reportType =>
            {
                switch (reportType)
                {
                    case ReportServiceTypes.SuitabilityReport:
                        return serviceProvider.GetService<SuitabilityReport>();
                    case ReportServiceTypes.VerifyReport:
                        return serviceProvider.GetService<VerifyReport>();
                    default:
                        return null;
                }
            });
        }

        //private void ConfigureSecurity(IServiceCollection serviceCollection)
        //{
        //    serviceCollection.AddSingleton<IAuthorizationPolicyProvider, PermissionsPolicyProvider>();
        //    //serviceCollection.AddSingleton<IKeyStoreProvider, KeyVaultKeyStoreProvider>();

        //    serviceCollection.AddSingleton<IAuthorizationHandler, PermissionsAuthorizationHandler>();
        //    serviceCollection.AddSingleton<IAuthorizationHandler, RolesAuthorizationHandler>();
        //    serviceCollection.AddSingleton<IAuthorizationHandler, ScopesAuthorizationHandler>();
        //}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
