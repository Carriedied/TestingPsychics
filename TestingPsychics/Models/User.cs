using System.ComponentModel.DataAnnotations;
using TestingPsychics.Validate;

namespace TestingPsychics.Models
{
    public class User
    {
        [ValidateDigitNumbers(ErrorMessage = "Число должно быть двузначным (от 10 до 99)")]
        [Required(ErrorMessage = "Введите число")]
        public int UserNumber { get; set; }
    }
}
