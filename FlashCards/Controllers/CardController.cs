using FlashCards.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using FlashCards.Models;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FlashCards.Controllers
{
    public class CardController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CardController(ApplicationDbContext db)
        {
               _db = db; 
        }
        [HttpGet("Card/Index/{stackId}")]
        public IActionResult Index([FromRoute]int stackId)
        {
            Stack stack = _db.Stacks.Include(s => s.FlashCards).FirstOrDefault(s => s.StackId == stackId);

            List<Cards> cards = stack.FlashCards.ToList();
            int cardsLength = 1;


            var cardDto = cards.Select(card => new CardDto
            {
                
                CardId = card.CardId,
                Question = card.Question,
                Answer = card.Answer,
                DisplayCardId = cardsLength ++,
            }).ToList();

            var cardDtoStackId = new CardDtoStackId()
            {
                CardDto = cardDto,
                StackId = stackId
            };
            
        
            return View(cardDtoStackId);
        }
        [HttpGet("Card/Create/{stackId}")]
        public IActionResult Create(int stackId)
        {
            Cards card = new Cards
            {

                StackId = stackId

            };
            return View(card);
        }



        [HttpPost]
        public IActionResult Create(int stackId, string question, string answer)
        {

            if (question == answer)
            {
                ModelState.AddModelError("question", "What are you doing?"); 
            }
            var stack = _db.Stacks.Find(stackId);
            if (stack == null)
            {
                ModelState.AddModelError("StackId", "Invalid Stack ID.");
            }

            if (!ModelState.IsValid)
            {
                var inValidCard = new Cards
                {
                    StackId = stackId
                };
                return View(inValidCard);

            }
         

            var card = new Cards
            {
                Question = question,
                Answer = answer,
                StackId = stackId,
                Stack = stack
            };

       


            _db.Cards.Add(card);
            _db.SaveChanges();
            return RedirectToAction("Index", new { id = card.StackId });

        }

        [HttpPost]
        public IActionResult Delete(int cardId)
        {
            Cards card = _db.Cards.FirstOrDefault(s => s.CardId == cardId);

            if(card != null)
            {
                _db.Cards.Remove(card);
                _db.SaveChanges();
            }
            return RedirectToAction("Index", new { id = card.StackId });
        }
    }
}
