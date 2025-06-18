using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using surveyProjectYAS.Models;
using System;

namespace surveyProjectYAS.Controllers
{
    public class SurveyController : Controller
    {
        private readonly SurveyContext _context;
        public SurveyController(SurveyContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var question = _context.Questions.Include(q => q.Options).FirstOrDefault();
            return View(question);
        }

        [HttpPost]
        public async Task<IActionResult> Vote(int optionId)
        {
            var option = await _context.Options.FindAsync(optionId);
            if (option == null)
            {
                TempData["Message"] = "❌ Oy verme işlemi başarısız oldu.";
                return RedirectToAction("Index");
            }

            option.VoteCount++;
            await _context.SaveChangesAsync();

            // Oy kullanıldı bilgisi cookieye yazılır
            Response.Cookies.Append("HasVoted", "true", new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddDays(1)
            });

            TempData["Message"] = "✅ Oy verme işlemi başarılı!";
            return RedirectToAction("Index");
        }

        //[HttpPost]
        //public IActionResult Vote(int optionId)
        //{
        //    var option = _context.Options.Find(optionId);
        //    if (option != null)
        //    {
        //        option.VoteCount++;
        //        _context.SaveChanges();

        //        Response.Cookies.Append("HasVoted", "true", new CookieOptions { Expires = DateTimeOffset.Now.AddDays(1) });
        //    }

        //    return RedirectToAction("Results");
        //}

        public IActionResult Results()
        {
            var question = _context.Questions.Include(q => q.Options).FirstOrDefault();
            return View(question);
        }

    }
}

