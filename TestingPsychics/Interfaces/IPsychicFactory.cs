using TestingPsychics.Models;

namespace TestingPsychics.Interfaces
{
    public interface IPsychicFactory
    {
        List<Psychic> CreateDefaultPsychics();
    }
}
