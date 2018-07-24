using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HomeworkPaul.Areas.Registration.Models
{
    public class RegistrationDetails
    {
        [MaxLength(255)]
        [DisplayName("First Name")]
        [RegularExpression(@"^[a-zA-Záéíóúüñ¿¡ÁÉÍÓÚÜÑ' -]{1,}$", ErrorMessage = "Unsupported characters entered, please try again")]
        public string FirstName { get; set; }
        [MaxLength(255)]
        [RegularExpression(@"^[a-zA-Záéíóúüñ¿¡ÁÉÍÓÚÜÑ' -]{1,}$", ErrorMessage = "Unsupported characters entered, please try again")]
        public string Surname { get; set; }
        [Required]
        [MaxLength(320)]
        [RegularExpression(@"^[a-zA-Z0-9áéíóúÁÉÍÓÚÜÑ¿¡üñ!#$%&'/()""£*+,-.:;<=>?@[\]^_`{|}~-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$", ErrorMessage = "Invalid Email address, please try again")]
        public string Email { get; set; }
        [Required]
        [MinLength(8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[áéíóúÁÉÍÓÚÜÑ¿¡üñ!#$%&'/()""£*+,-.:;<=>?@[\]^_`{|}~£#-])(?i)(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?:([\w\dáéíóúÁÉÍÓÚÜÑ¿¡üñ!#$%&'/()*+,-.:;<=>?@[\]^_`{|}~£#-])(?!\1))+$", ErrorMessage = "Password does not meet the minimum requirements, please try again")]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}