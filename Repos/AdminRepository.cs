using Microsoft.EntityFrameworkCore;
using Admins.Repos.Interfaces;
using Admins.Model;

namespace Admins.Repos
{
    public class AdminRepository : IAdminRepository
    {
        private readonly AppDbContext.Namespace.AppDbContext _context;

        public AdminRepository(AppDbContext.Namespace.AppDbContext context)
        {
            // Database connection
            _context = context;
        }

        // Admin sign up 
        public async Task<Admins.Model.Administrator> AddAdmin(Admins.Model.Administrator admin)
        {
            if (admin == null)
            {
                throw new Exception("Invalid admin data");
            }

            // Check - email exists
            var existingAdmin = await _context.Admins.FirstOrDefaultAsync(a => a.Email == admin.Email);
            if (existingAdmin != null)
            {
                throw new Exception("Admin with this email already exists");
            }

            _context.Admins.Add(admin);
            await _context.SaveChangesAsync();

            admin.Password = null;
            return admin;
        }

        // Admin log in
        public async Task<Admins.Model.Administrator> Login(AdminLoginRequest request)
        {
            var admin = await _context.Admins.FirstOrDefaultAsync(a => a.Email == request.Email);

            if (admin == null || admin.Password != request.Password)
            {
                throw new Exception("Invalid Credentials");
            }

            admin.Password = null;
            return admin;
        }

        // Password reset
        public async Task<Admins.Model.Administrator> ForgotPassword(AdminForgotPass request)
        {
            var admin = await _context.Admins.FirstOrDefaultAsync(a => a.Email == request.Email);

            if (admin == null)
            {
                throw new Exception("Invalid Email Address");
            }

            admin.Password = request.Password;
            await _context.SaveChangesAsync();

            admin.Password = null;
            return admin;
        }
    }
}
