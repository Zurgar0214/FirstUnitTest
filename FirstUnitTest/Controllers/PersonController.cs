using FirstUnitTest.Application.Services.Interfaces;
using FirstUnitTest.Domain.Model;
using FirstUnitTest.Domain.Model.Enum;
using Microsoft.AspNetCore.Mvc;

namespace FirstUnitTest.Api.Controllers
{
    [ApiController]
    [Route("api/person")]
    public class PersonController : ControllerBase
    {
        private readonly ICreatePersonService _createPersonService;

        public PersonController(ICreatePersonService createPersonService)
        {
            _createPersonService = createPersonService;
        }
        [HttpPost]
        public Task<Person> Create(string? name, int? age, float? weight, float? height, Gender? gender)
        {
            return _createPersonService.CreatePerson(name, age, weight, height, gender);
        }
    }
}
