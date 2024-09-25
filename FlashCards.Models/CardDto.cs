using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCards.Models
{
    public class CardDto
    {
        public int CardId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }

        public int DisplayCardId { get; set; }

    }
}
