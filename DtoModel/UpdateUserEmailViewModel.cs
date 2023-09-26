using System.ComponentModel.DataAnnotations;

namespace DtoModel
{
    public class UpdateUserEmailViewModel
    {

        [Required]
        public string UserId { get; set; }

        [Required]
        public string NewEmail { get; set; }
    }
}