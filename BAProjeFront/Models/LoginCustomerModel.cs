using System.ComponentModel.DataAnnotations;

namespace BAProjeFront.Models{
    public class LoginCustomerModel{
        [Required(ErrorMessage="Name is required")]
        [MaxLength(15,ErrorMessage="must be 4 between 15 character")]
        [MinLength(4,ErrorMessage="must be 4 between 15 character")]
        public string CustomerName{get;set;}
        [Required(ErrorMessage="Password is required")]
        [MaxLength(15,ErrorMessage="must be 4 between 15 character")]
        [MinLength(4,ErrorMessage="must be 4 between 15 character")]
        public string Password{get;set;}
    }
}