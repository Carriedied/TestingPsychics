using TestingPsychics.Interfaces;
using TestingPsychics.Models;

namespace TestingPsychics.Services
{
    public class PsychicFactory : IPsychicFactory
    {
        public List<Psychic> CreateDefaultPsychics()
        {
            return new List<Psychic>
            {
                new Psychic { Id = 1, Name = "Экстрасенс 1" },
                new Psychic { Id = 2, Name = "Экстрасенс 2" },
                new Psychic { Id = 3, Name = "Экстрасенс 3" }
            };
        }
    }
}
