using CoreModels.Models;
using CoreServices.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

namespace CoreServices.Interfaces
{
    public interface IAccount
    {
        Task<UserDTO> Register(RegisterModel registerModel, ModelStateDictionary modelState);
        Task<string> LogIn(LogInModel signInModel);

    }
}
