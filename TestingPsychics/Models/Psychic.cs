namespace TestingPsychics.Models
{
    public class Psychic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Reliability { get; set; }
        public List<int> GuessHistory { get; set; }
        public int LastGuess { get; set; }

        public Psychic()
        {
            GuessHistory = new List<int>();
            Reliability = 0;
            LastGuess = 0;
        }

        public void MakeGuess()
        {
            Random random = new Random(Id + DateTime.Now.Millisecond);

            LastGuess = random.Next(10, 100);

            GuessHistory.Add(LastGuess);
        }
    }
}
