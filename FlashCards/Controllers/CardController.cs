using FlashCards.Data;
using FlashCards.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlashCards.Controllers
{
    public class CardController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CardController(ApplicationDbContext db)
        {
               _db = db; 
        }
        public IActionResult Index()
        {
            List<Cards> cards = _db.Cards.ToList();
            return View(cards);
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Cards obj)
        {
            if (obj.Question == obj.Answer)
            {
                ModelState.AddModelError("question", "What are you doing?");
            }

            if (ModelState.IsValid)
            {
                _db.Cards.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();
        }
    }
}
