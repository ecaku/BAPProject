using System.ComponentModel.DataAnnotations;

namespace BAProjeFront.Models{
    public class SignupCustomerModel{
        [Required(ErrorMessage="Name is required")]
        [MaxLength(15,ErrorMessage="must be 4 between 15 character")]
        [MinLength(4,ErrorMessage="must be 4 between 15 character")]
        public string CustomerName{get;set;}


        [Required(ErrorMessage="Emailsword is required")]
        [EmailAddress(ErrorMessage="Not a valid email")]       
        public string Email{get;set;}

        
        [MaxLength(15,ErrorMessage="must be 4 between 15 character")]
        [MinLength(4,ErrorMessage="must be 4 between 15 character")]
        public string Password{get;set;}
    }
}