using System.ComponentModel.DataAnnotations;

namespace Dutch_Treat.Models
{
    public class Contact
    {
        [Required]
        [MinLength(2, ErrorMessage = "First Name must have at least 2 characters long.")]
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "First Name cannot contain numbers.")]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Last Name must have at least 2 characters long.")]
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "Last Name cannot contain numbers.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]        
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\+[0-9]{9})|([0-9]{3})[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string Phone { get; set; }

        [Required]
        public string Topic { get; set; }

        [Required]
        [MaxLength(250)]
        public string Message { get; set; }
    }
}
