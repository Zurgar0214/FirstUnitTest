using FirstUnitTest.Domain.Model;
using FirstUnitTest.Domain.Model.Enum;

namespace FirstUnitTest.Application.Validations
{
    public interface ICreatePersonValidate
    {
        public Task ValidatePerson(string? name, int? age, float? weight,float? height, Gender? gender);
    }
}
