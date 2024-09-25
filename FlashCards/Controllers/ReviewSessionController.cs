using FlashCards.DataAccess.Data;
using FlashCards.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlashCards.Controllers
{
    public class ReviewSessionController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ReviewSessionController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet("ReviewSession/Index/{stackId}")]
        public IActionResult Index([FromRoute] int stackId)
        {
            Stack stack = _db.Stacks.Include(s=>s.FlashCards).FirstOrDefault(s=>s.StackId == stackId);

            List<Cards> cards = stack.FlashCards.ToList();
            int cardsLength = 1;

            var cardDto = cards.Select(card => new CardDto
            {

                CardId = card.CardId,
                Question = card.Question,
                Answer = card.Answer,
                DisplayCardId = cardsLength++,
            }).ToList();


            List<CardDto> shuffledCards = cardDto.OrderBy(c=> Guid.NewGuid()).Select((card, index) =>
            {

                card.DisplayCardId = index + 1;
                return card;
            }).ToList();    

            return View(shuffledCards);
        }
    }
}
