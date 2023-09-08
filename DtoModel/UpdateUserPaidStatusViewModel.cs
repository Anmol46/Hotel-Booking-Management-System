using System.ComponentModel.DataAnnotations;

namespace DtoModel {

    public class UpdateUserPaidStatusViewModel {

        [Required]
        public string UserId { get; set; }

        [Required]
        public bool Paid { get; set; }
    }
}