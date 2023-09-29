using AcAPI.BLL;
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
            services.AddScoped<IUsuarioDAO, UsuarioDAO>();
            services.AddScoped<ILab, LabBO>();
            services.AddScoped<ILabDAO, LabDAO>();
            

            services.AddCors(op =>
            {
                op.AddPolicy("teste", policy =>
                {
                    policy.AllowAnyOrigin();
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                });
            });

            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
                });

            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(p =>
            {
                p.SwaggerDoc("v1", new OpenApiInfo { Title = "Atividade Contínua", Version = "v1", Description = "Felipe Mackenzie de Campos / Gabriel Marques Fernandes / João Pedro Matias Neves / Matheus Soares Bezerra / Pedro Vysomirsksis Fuentes / Rafael Marques Fernandes " });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(p =>
            {
                p.RoutePrefix = string.Empty;
                p.SwaggerEndpoint("/swagger/v1/swagger.json", "AcAPI");
            });                       

            app.UseRouting();

            app.UseCors("teste");

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