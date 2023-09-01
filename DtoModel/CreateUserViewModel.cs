using System.ComponentModel.DataAnnotations;

namespace DtoModel{

    public class CreateUserViewModel {
        
        [Required(ErrorMessage = "First name is required.")]
        [MinLength(2, ErrorMessage = "First name should be atleast 2 characters.")]
        [MaxLength(30, ErrorMessage = "First name should be between 2 and 30 characters.")]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "First name contains the invalid character.")]
        public string FirstName { get; set; } 
        
        [Required(ErrorMessage = "Last name is required.")]
        [MinLength(2, ErrorMessage = "Last name should be atleast 2 characters.")]
        [MaxLength(30, ErrorMessage = "Last name should be between 2 and 30 characters.")]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Last name contains the invalid character.")]
        public string LastName { get; set; } 
        
        [Required(ErrorMessage = "Phone number is required.")]
        [MinLength(7, ErrorMessage = "Phone number cannot be less than 7 digits.")]
        [MaxLength(15, ErrorMessage = "Phone number should be between 7 and 15 digits.")]
        [RegularExpression("^[+][0-9]{1,3}[ ][0-9]{7,15}$", ErrorMessage = "Please enter a valid phone number in the correct format")]
        public string PhoneNumber { get; set; } 
        
        [Required]
        [RegularExpression("^[a-zA-Z]*[@][a-zA-z]*[.][a-zA-Z]*$", ErrorMessage = "Please enter a valid email id")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(5, ErrorMessage = "Password cannot be less than 5 characters.")]
        [MaxLength(15, ErrorMessage = "Password should not be more than 15 characters.")]
        public string Password { get; set; }

    }
}
