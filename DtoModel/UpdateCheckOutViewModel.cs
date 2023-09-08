using System.ComponentModel.DataAnnotations;

namespace DtoModel {

    public class UpdateCheckOutViewModel {

        [Required]
        public string UserId { get; set; }

        [Required]
        public DateTime CheckOut { get; set; }
    }
}