using Microsoft.AspNetCore.Mvc;
using TestingPsychics.Models;
using TestingPsychics.Services;

namespace TestingPsychics.Controllers
{
    public class PsychicController : Controller
    {
        private readonly PsychicService _psychicService;

        public PsychicController(PsychicService psychicService)
        {
            _psychicService = psychicService;
        }

        public IActionResult Index()
        {
            var sessionData = _psychicService.GetSessionData(HttpContext);

            return View(sessionData);
        }

        [HttpPost]
        public IActionResult StartGuessing()
        {
            _psychicService.GenerateGuesses(HttpContext);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult SubmitNumber(User number)
        {
            if (ModelState.IsValid)
            {
                _psychicService.ProcessUserNumber(number.UserNumber, HttpContext);

                return RedirectToAction("Index");
            }

            var sessionData = _psychicService.GetSessionData(HttpContext);
            ViewBag.UserNumberModel = number;
            return View("Index", sessionData);
        }

        public IActionResult Reset()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index");
        }
    }
}
