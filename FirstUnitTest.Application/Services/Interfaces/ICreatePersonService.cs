using FirstUnitTest.Domain.Model;
using FirstUnitTest.Domain.Model.Enum;

namespace FirstUnitTest.Application.Services.Interfaces
{
    public interface ICreatePersonService
    {
        public Task<Person> CreatePerson(string? name, int? age, float? weight, float? height, Gender? gender);
    }
}
