using FirstUnitTest.Application.Services.Interfaces;
using FirstUnitTest.Application.Validations;
using FirstUnitTest.Domain.Model;
using FirstUnitTest.Domain.Model.Enum;

namespace FirstUnitTest.Application.Services.Implementation
{
    public class CreatePersonService : ICreatePersonService
    {
        private readonly ICreatePersonValidate _createPersonValidate;

        public CreatePersonService(ICreatePersonValidate createPersonValidate)
        {
            _createPersonValidate = createPersonValidate;
        }

        public async Task<Person> CreatePerson(string? name, int? age, float? weight, float? height, Gender? gender)
        {
            await _createPersonValidate.ValidatePerson(name, age, weight, height, gender);
            return new Person(name, age, weight, height, gender);
        }
    }
}
