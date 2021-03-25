using System.ComponentModel.DataAnnotations;

namespace WebAppExample.Models
{
    public class GridModel
    {
        [Required]
        [Range(1, 50, ErrorMessage = "Please enter a value between 1 and 50")]
        public string Row { get; set; }
        [Required]
        [Range(1, 50, ErrorMessage = "Please enter a value between 1 and 50")]
        public string Column { get; set; }
    }
}
