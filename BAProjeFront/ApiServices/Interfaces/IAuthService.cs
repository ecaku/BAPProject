using System.Threading.Tasks;
using BAProjeFront.Models;

namespace BAProjeFront.ApiServices.Interfaces{
    public interface IAuthService{
        Task<bool> Signin(LoginCustomerModel loginCustomerModel);
        Task<bool> Signup(SignupCustomerModel signupCustomerModel);
        bool LogOut();
    }
}