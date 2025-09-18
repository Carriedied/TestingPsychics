using System.ComponentModel.DataAnnotations;

namespace TestingPsychics.Validate
{
    public class ValidateDigitNumbers : ValidationAttribute
    {
        public ValidateDigitNumbers()
        {
            ErrorMessage = "Число должно быть двузначным (от 10 до 99)";
        }

        public override bool IsValid(object value)
        {
            if (value is int number)
            {
                return number >= 10 && number <= 99;
            }

            return false;
        }
    }
}
