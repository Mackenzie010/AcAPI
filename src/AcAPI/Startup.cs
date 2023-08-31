using AcAPI.BLL;
using AcAPI.DAL;
using AcAPI.DAO;
using AcAPI.Helpers;
using Microsoft.OpenApi.Models;

namespace AcAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUsuario, UsuarioBO>();
            services.AddSingleton<IUsuarioDAO, UsuarioDAO>();


            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
                });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(p =>
            {
                p.SwaggerDoc("v1", new OpenApiInfo { Title = "Atividade Contínua", Version = "v1", Description = "Felipe Mackenzie de Campos / Gabriel Marques Fernandes / João Pedro Matias Neves / Matheus Soares Bezerra / Pedro Vysomirsksis Fuentes / Rafael Marques Fernandes " });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger(p =>
            {
                p.SerializeAsV2 = true;
            });

            app.UseSwaggerUI(p =>
            {
                p.RoutePrefix = string.Empty;
                p.SwaggerEndpoint("/swagger/v1/swagger.json", "AcAPI");
                p.DefaultModelExpandDepth(-1);
            });

            app.UseRouting();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("AcAPI", "{areas:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllers();
            });
        }
    }
}