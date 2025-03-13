using Microsoft.AspNetCore.Mvc;
using Admin.Services.Interfaces;
using Admins.Model;

namespace Administrator.Controllers
{
    [Route("admin/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminServices _adminServices;

        public AdminController(IAdminServices adminServices)
        {
            _adminServices = adminServices;
        }

        // Signup
        [HttpPost("signup")]
        public async Task<ActionResult> AddAdmin([FromBody] Admins.Model.Administrator admin)
        {
            if (admin == null)
            {
                return BadRequest("Invalid admin data");
            }

            try
            {
                var newAdmin = await _adminServices.AddAdmin(admin);
                return Ok(new { message = "Admin created successfully", adminId = newAdmin.Id });
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message); 
            }
        }

        // Login
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] AdminLoginRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest("Email and password are required.");
            }

            try
            {
                string message = await _adminServices.Login(request);
                return Ok(new { message });
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        // Forgot Password
        [HttpPost("forgotPassword")]
        public async Task<ActionResult> ForgotPassword([FromBody] AdminForgotPass request)
        {
            if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest("Email and new password are required.");
            }

            try
            {
                bool isReset = await _adminServices.ForgotPassword(request);
                if (!isReset) return NotFound("Invalid email address.");

                return Ok(new { message = "Password reset successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
