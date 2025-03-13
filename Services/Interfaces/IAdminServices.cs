using Admins.Model;

namespace Admin.Services.Interfaces
{
    public interface IAdminServices
    {
        Task<Admins.Model.Administrator> AddAdmin(Admins.Model.Administrator admin);
        Task<string> Login(AdminLoginRequest request);
        Task<bool> ForgotPassword(AdminForgotPass request);
    }
}