using FirstUnitTest.Domain.Model.Constants;
using FirstUnitTest.Domain.Model.Enum;

namespace FirstUnitTest.Domain.Model
{
    public class Person
    {
        public string? Dni { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }
        public float? Weight { get; set; }
        public float? Height { get; set; }
        public Gender? Gender { get; set; }

        public Person(string? name, int? age, float? weight,
            float? height, Gender? gender)
        {
            Dni = GenerateDni();
            Name = name;
            Age = age;
            Weight = weight;
            Height = height;
            Gender = gender;
        }

        private string GenerateDni()
        {
            return $"DNI-{Guid.NewGuid()}";
        }

        private bool IsAdult()
        {
            if (Age >= PersonConstants.MAJOR_AGE_CONSTANT)
                return true;
            return false;
        }

        private bool IsOverWeight()
        {
            if ((Weight / (Height * Height)) >= PersonConstants.MINIMUN_OVERWEIGHT)
                return true;
            return false;
        }
    }
}
