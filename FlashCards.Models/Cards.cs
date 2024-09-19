using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FlashCards.Models
{
    public class Cards
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Card Question")]
        [MinLength(2, ErrorMessage = "Give me a harder question")]
        public string Question { get; set; }
        [Required]
        [DisplayName("Card Answer")]
        public string Answer { get; set; }
    }
}
