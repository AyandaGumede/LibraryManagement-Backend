using Admin.Services.Interfaces;
using Admins.Model;
using Admins.Repos.Interfaces;

namespace Admin.Services
{
    public class AdminServices : IAdminServices
    {
        private readonly IAdminRepository _adminRepository;

        public AdminServices(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<Admins.Model.Administrator> AddAdmin(Admins.Model.Administrator admin)
        {
            if (admin == null || string.IsNullOrWhiteSpace(admin.Email) || string.IsNullOrWhiteSpace(admin.Password))
            {
                throw new Exception("Invalid admin data. Email and password are required.");
            }

            return await _adminRepository.AddAdmin(admin);
        }

        public async Task<string> Login(AdminLoginRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
            {
                throw new Exception("Email and Password are required.");
            }

            var admin = await _adminRepository.Login(request);
            if (admin == null)
            {
                throw new Exception("Invalid Credentials");
            }

            return "Login successful"; 
        }

        public async Task<bool> ForgotPassword(AdminForgotPass request)
        {
            if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
            {
                throw new Exception("Email and new password are required.");
            }

            var admin = await _adminRepository.ForgotPassword(request);
            return admin != null;
        }
    }
}
