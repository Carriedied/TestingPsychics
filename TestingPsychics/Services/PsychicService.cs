using System.Text.Json;
using TestingPsychics.Interfaces;
using TestingPsychics.Models;

namespace TestingPsychics.Services
{
    public class PsychicService
    {
        private const string SessionKey = "PsychicSession";

        private readonly IPsychicFactory _psychicFactory;

        public PsychicService(IPsychicFactory psychicFactory)
        {
            _psychicFactory = psychicFactory;
        }

        public SessionData GetSessionData(HttpContext httpContext)
        {
            var session = httpContext.Session;
            var data = session.GetString(SessionKey);

            if (string.IsNullOrEmpty(data))
            {
                var sessionData = InitializeSession();
                SaveSessionData(sessionData, httpContext);

                return sessionData;
            }

            return JsonSerializer.Deserialize<SessionData>(data);
        }

        public void SaveSessionData(SessionData data, HttpContext httpContext)
        {
            var session = httpContext.Session;
            session.SetString(SessionKey, JsonSerializer.Serialize(data));
        }

        private SessionData InitializeSession()
        {
            var SessionData = new SessionData()
            {
                Psychics = _psychicFactory.CreateDefaultPsychics(),
                UserNumbers = new List<int>(),
                HasGuessed = false,
                CurrentGuessRound = 0
            };

            return SessionData;
        }

        public void ProcessUserNumber(int userNumber, HttpContext httpContext)
        {
            var sessionData = GetSessionData(httpContext);
            sessionData.UserNumbers.Add(userNumber);
            sessionData.CurrentGuessRound++;

            foreach (var psychic in sessionData.Psychics)
            {
                if (psychic.LastGuess == userNumber)
                {
                    psychic.Reliability++;
                }
                else
                {
                    psychic.Reliability--;
                }
            }

            sessionData.HasGuessed = false;

            SaveSessionData(sessionData, httpContext);
        }

        public void GenerateGuesses(HttpContext httpContext)
        {
            var sessionData = GetSessionData(httpContext);

            foreach (var psychic in sessionData.Psychics)
            {
                psychic.MakeGuess();
            }

            sessionData.HasGuessed = true;

            SaveSessionData(sessionData, httpContext);
        }
    }
}
