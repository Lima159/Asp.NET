using Biblioteca.Business.implementacoes;
using Biblioteca.Business.interfaces;
using Biblioteca.Context;
using Biblioteca.Repository.implementacoes;
using Biblioteca.Repository.interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using Swashbuckle.AspNetCore.Swagger;

namespace Biblioteca
{
    public class Startup
    {
        private readonly ILogger _logger;
        public IConfiguration _configuration { get; }
        public IHostingEnvironment _environment { get; }

        public Startup(IConfiguration configuration, IHostingEnvironment environment, ILogger<Startup> logger)
        {
            _configuration = configuration;
            _environment = environment;
            _logger = logger;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true;
                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("text/xml"));
                options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));

            })
            .AddXmlSerializerFormatters()
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddApiVersioning(option => option.ReportApiVersions = true);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(_configuration["AppConfig:Version"],
                    new Info
                    {
                        Title = _configuration["AppConfig:AppName"],
                        Version = _configuration["AppConfig:Version"]
                    });
            });

            var connectionString = _configuration["ConnectionString:SqlConnectionString"];
            services.AddDbContext<BibliotecaContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IAutorBusiness, AutorBusiness>();
            services.AddScoped<IAutorRepository, AutorRepository>();

            services.AddScoped<ILeitorBusiness, LeitorBusiness>();
            services.AddScoped<ILeitorRepository, LeitorRepository>();

            services.AddScoped<IEditoraBusiness, EditoraBusiness>();
            services.AddScoped<IEditoraRepository, EditoraRepository>();

            services.AddScoped<ILivroBusiness, LivroBusiness>();
            services.AddScoped<ILivroRepository, LivroRepository>();

            services.AddScoped<IEmprestimoBusiness, EmprestimoBusiness>();
            services.AddScoped<IEmprestimoRepository, EmprestimoRepository>();

            services.AddScoped<IGeneroBusiness, GeneroBusiness>();
            services.AddScoped<IGeneroRepository, GeneroRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/{_configuration["AppConfig:Version"]}/swagger.json", _configuration["AppConfig:AppName"]);
            });

            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "DefaultApi",
                    template: "{controller}/{id?}");
            });
        }
    }
}
