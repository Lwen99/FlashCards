using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FlashCards.Models
{
    public class Cards
    {
    

        [Key]
        public int CardId { get; set; }

        [DisplayName("Card Question")]
        [MinLength(2, ErrorMessage = "Give me a harder question")]
        public string Question { get; set; }
        [DisplayName("Card Answer")]
        public string Answer { get; set; }

        public int StackId {  get; set; }

        public Stack Stack { get; set; }
    }
}
