using System.ComponentModel.DataAnnotations;

namespace DtoModel {

    public class DeleteUserViewModel {

        [Required]
        public string Email { get; set; }
    }
}