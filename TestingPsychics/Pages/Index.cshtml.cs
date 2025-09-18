using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestingPsychics.Models;
using TestingPsychics.Services;

namespace TestingPsychics.Pages
{
    public class IndexModel : PageModel
    {
        private readonly PsychicService _psychicService;

        public IndexModel(PsychicService psychicService)
        {
            _psychicService = psychicService;
        }

        public SessionData SessionData { get; set; }

        public void OnGet()
        {
            SessionData = _psychicService.GetSessionData(HttpContext);
        }

        public IActionResult OnPostStartGuessing()
        {
            _psychicService.GenerateGuesses(HttpContext);
            return RedirectToPage();
        }

        public IActionResult OnPostSubmitNumber([FromForm] User model)
        {
            if (ModelState.IsValid)
            {
                _psychicService.ProcessUserNumber(model.UserNumber, HttpContext);
            }
            return RedirectToPage();
        }

        public IActionResult OnPostReset()
        {
            HttpContext.Session.Clear();
            return RedirectToPage();
        }
    }
}
