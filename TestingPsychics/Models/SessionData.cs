using TestingPsychics.Validate;

namespace TestingPsychics.Models
{
    public class SessionData
    {
        public List<Psychic> Psychics { get; set; }
        public List<int> UserNumbers { get; set; }
        public bool HasGuessed { get; set; }
        public int CurrentGuessRound { get; set; }

        public SessionData()
        {
            Psychics = new List<Psychic>();
            UserNumbers = new List<int>();
            HasGuessed = false;
            CurrentGuessRound = 0;
        }
    }
}
