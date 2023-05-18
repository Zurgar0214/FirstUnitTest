using FirstUnitTest.Api.Controllers;
using FirstUnitTest.Application.Services.Implementation;
using FirstUnitTest.Application.Services.Interfaces;
using FirstUnitTest.Application.Validations;
using FirstUnitTest.Domain.Model;
using FirstUnitTest.Domain.Model.Enum;
using FirstUnitTest.Infraestructure.Validations;
using Moq;

namespace FirstUnitTest.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PersonConstructorTest()
        {
            Person person = new Person("Juan Diego", 21, 57, 1.65F, Domain.Model.Enum.Gender.Male);
            Assert.IsNotNull(person);
            Assert.That(person.Name, Is.EqualTo("Juan Diego"));
            Assert.That(person.Age, Is.EqualTo(21));
            Assert.That(person.Weight, Is.EqualTo(57));
            Assert.That(person.Height, Is.EqualTo(1.65F));
            Assert.That(person.Gender, Is.EqualTo(Gender.Male));
            Assert.IsNotNull(person.Dni);
            Assert.That(person.Dni!.StartsWith("DNI-"));
        }

        [Test]
        public void CreatePersonController()
        {
            var serviceMock = new Mock<ICreatePersonService>();
            serviceMock.Setup(mock => mock.CreatePerson("Juan Diego", 21, 57, 1.65F, Gender.Male).Result).Returns(
                new Person("Juan Diego", 21, 57, 1.65F, Gender.Male));
            PersonController controller = new(serviceMock.Object);
            Assert.That(controller.Create("Juan Diego", 21, 57, 1.65F, Gender.Male).Result.Age, Is.EqualTo(21));
        }

        [Test]
        public void CreatePersonValidatorService()
        {
            var validationMock = new Mock<ICreatePersonValidate>();
            validationMock.Setup(mock => mock.ValidatePerson("", 21, 57, 1.65F, Gender.Male))
                .Throws(new Exception("El campo 'Nombre' es requerido"));
            ICreatePersonService createPersonService = new CreatePersonService(validationMock.Object);
            Assert.ThrowsAsync<Exception>(async () => await createPersonService.CreatePerson("", 21, 57, 1.65F, Gender.Male));
        }
    }
}