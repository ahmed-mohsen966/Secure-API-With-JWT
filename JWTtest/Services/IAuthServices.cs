using System.Threading.Tasks;
using JWTtest.Models;

namespace JWTtest.Services
{
    public interface IAuthServices
    {
        Task<AuthModel> RegisteraAsync(RegisterModel model);
        Task<AuthModel> GetTokenAsync(TokenRequestModel model);
        Task<string> AddRoleAsync(AddRoleModel model);
    }
}
