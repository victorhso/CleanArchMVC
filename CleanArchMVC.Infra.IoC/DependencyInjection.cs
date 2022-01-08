using CleanArchMVC.Application.Interfaces;
using CleanArchMVC.Application.Mappings;
using CleanArchMVC.Application.Services;
using CleanArchMVC.Domain.Account;
using CleanArchMVC.Domain.Interface;
using CleanArchMVC.Infra.Data.Context;
using CleanArchMVC.Infra.Data.Identity;
using CleanArchMVC.Infra.Data.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CleanArchMVC.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //Registrando o contexto (Provedor do BD)
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            //Configurando Cookie do aplicativo
            //Quando o usuário acessar um recurso que não tiver acesso, ele será redirecionado para Login.
            services.ConfigureApplicationCookie(option => option.AccessDeniedPath = "/Account/Login");

            //Registrando os serviços do Identity
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            services.AddScoped<IAuthenticate, AuthenticateService>();
            services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();

            //Registrando os repositórios
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            //Registrando os serviços
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            var myHandlers = AppDomain.CurrentDomain.Load("CleanArchMVC.Application");
            services.AddMediatR(myHandlers);

            return services;
        }
    }
}
