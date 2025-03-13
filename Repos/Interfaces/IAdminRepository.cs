using System;
using System.Threading.Tasks;
using Admins.Model;  

namespace Admins.Repos.Interfaces
{
    public interface IAdminRepository
    {
        Task<Admins.Model.Administrator> AddAdmin(Admins.Model.Administrator admin); 
        Task<Admins.Model.Administrator> Login(AdminLoginRequest request);
        Task<Admins.Model.Administrator> ForgotPassword(AdminForgotPass admin);
    }
}
