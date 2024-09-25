using FlashCards.DataAccess.Data;
using FlashCards.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlashCards.Controllers
{
    public class StackController : Controller
    {
        private readonly ApplicationDbContext _db;

        public StackController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Stack()
        {
            List<Stack> stacks = _db.Stacks.ToList();
            return View(stacks);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(string name, string description)
        {
           
            if (ModelState.IsValid)
            {
                Stack stack = new Stack
                {
                    CreatedAt = DateTime.Now,
                    Name = name,
                    Description = description,
                    FlashCards = new List<Cards>()
                };
                _db.Stacks.Add(stack);
                _db.SaveChanges();
                return RedirectToAction("Stack");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int stackId)
        {
            var stack = _db.Stacks.FirstOrDefault( s=>s.StackId == stackId);
            if (stack != null)
            {
                _db.Stacks.Remove(stack);
                _db.SaveChanges();
            }
            return RedirectToAction("Stack");
        }
    }
}
