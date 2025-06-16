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
        public IActionResult Vote(int optionId)
        {
            var option = _context.Options.Find(optionId);
            if (option != null)
            {
                option.VoteCount++;
                _context.SaveChanges();

                Response.Cookies.Append("HasVoted", "true", new CookieOptions { Expires = DateTimeOffset.Now.AddDays(1) });
            }

            return RedirectToAction("Results");
        }

        public IActionResult Results()
        {
            var question = _context.Questions.Include(q => q.Options).FirstOrDefault();
            return View(question);
        }
    }
}

