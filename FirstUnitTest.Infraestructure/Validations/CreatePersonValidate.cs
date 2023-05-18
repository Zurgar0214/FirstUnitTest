using FirstUnitTest.Application.Validations;
using FirstUnitTest.Domain.Model;
using FirstUnitTest.Domain.Model.Enum;
using FirstUnitTest.Infraestructure.Resources;
using FluentValidation;

namespace FirstUnitTest.Infraestructure.Validations
{
    public class CreatePersonValidate : ICreatePersonValidate
    {
        public async Task ValidatePerson(string? name, int? age, float? weight, float? height, Gender? gender)
        {
            var validationResult = await new CreatePersonValidator().ValidateAsync(new CreatePersonModel(name, age, weight, height, gender));
            if (!validationResult.IsValid)
                throw new Exception(validationResult.Errors.First().ErrorMessage);


        }

        public class CreatePersonValidator : AbstractValidator<CreatePersonModel>
        {
            public CreatePersonValidator()
            {
                RuleFor(person => person.Name).NotEmpty().WithMessage(ValidationMessages.PersonNameIsRequired)
                    .NotNull().WithMessage(ValidationMessages.PersonNameIsRequired);

                RuleFor(person => person.Age).NotNull().WithMessage(ValidationMessages.PersonAgeIsRequired)
                    .GreaterThanOrEqualTo(0).WithMessage(ValidationMessages.PersonInvalidAge);

                RuleFor(person => person.Weight).NotEmpty().WithMessage(ValidationMessages.PersonWeightIsRequired)
                    .NotNull().WithMessage(ValidationMessages.PersonWeightIsRequired);

                RuleFor(person => person.Height).NotEmpty().WithMessage(ValidationMessages.PersonHeightIsRequired)
                    .NotNull().WithMessage(ValidationMessages.PersonHeightIsRequired);

                RuleFor(person => person.Gender).NotEmpty().WithMessage(ValidationMessages.PersonGenderIsRequired)
                    .IsInEnum().WithMessage(ValidationMessages.PersonGenderInvalid);
            }
        }
    }
    public class CreatePersonModel
    {
        public string? Name { get; set; }
        public int? Age { get; set; }
        public float? Weight { get; set; }
        public float? Height { get; set; }
        public Gender? Gender { get; set; }

        public CreatePersonModel(string? name, int? age, float? weight,
            float? height, Gender? gender)
        {
            Name = name;
            Age = age;
            Weight = weight;
            Height = height;
            Gender = gender;
        }
    }
}
