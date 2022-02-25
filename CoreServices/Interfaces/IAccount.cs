using CoreModels.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace CoreServices.Interfaces
{
    public interface IAccount
    {
        Task<IdentityResult> Register(RegisterModel registerModel);
        Task<string> LogIn(LogInModel signInModel);

    }
}
