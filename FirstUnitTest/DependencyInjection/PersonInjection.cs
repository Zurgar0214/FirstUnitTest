using FirstUnitTest.Application.Services.Implementation;
using FirstUnitTest.Application.Services.Interfaces;
using FirstUnitTest.Application.Validations;
using FirstUnitTest.Infraestructure.Validations;
using Microsoft.AspNetCore.Mvc;

namespace FirstUnitTest.Api.DependencyInjection
{
    public static class PersonInjection
    {
        public static void InjectPersonDependencies(this WebApplicationBuilder webApplicationBuilder)
        {
            webApplicationBuilder.Services.AddTransient<ICreatePersonValidate, CreatePersonValidate>();
            webApplicationBuilder.Services.AddScoped<ICreatePersonService, CreatePersonService>();
        }
    }
}
