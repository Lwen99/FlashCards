using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCards.Models
{
 
    public class Stack
    {
  
        [Key]
        public int StackId { get; set; }

        [DisplayName("Stack Name")]
        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }
        [DisplayName("Stack Description")]
        public string Description { get; set; }

        public List<Cards> FlashCards { get; set; }
    }
}
