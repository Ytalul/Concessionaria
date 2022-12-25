using Microsoft.EntityFrameworkCore;
using Veiculo.Data;
using Veiculo.Helper;
using Veiculo.Repositorio;

namespace Veiculo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<BancoContext>
                (options => options.UseSqlServer("Data Source=YTALO;Initial Catalog=CRUD;Integrated Security=False;User ID=sa;Password=4869;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False"));

            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            builder.Services.AddScoped<IVeiculoRepositorio, VeiculoRepositorio>();
            builder.Services.AddScoped<IMotoRepositorio, MotoRepositorio>();
            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            builder.Services.AddScoped<ISessao, Sessao>();

            builder.Services.AddSession(o => o.Cookie.IsEssential = true);
            builder.Services.AddSession(o => o.Cookie.HttpOnly= true);
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=IndexDeslogado}/{id?}");

            app.Run();
        }
    }
}