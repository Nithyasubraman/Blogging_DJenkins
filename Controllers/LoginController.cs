using BloggingSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.Threading.Tasks;

namespace BloggingSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {

            var client = _context.userSignup.Find(Id);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        [HttpPost("UserSignup")]
        public async Task<IActionResult> UserSignup([FromBody] UserSignup user)
        {
            // Perform validation, hashing passwords, etc.
            // Example: 
            //var user = new UserSignup { Email = model.Email, Password = model.Password };
            _context.userSignup.Add(user);
            await _context.SaveChangesAsync();
            return Ok("Signed up successfully!");
        }


        [HttpPost("checkloginuser")]

        public async Task<IActionResult> checkuser(LoginUser loginUser)
        {
            if (_context.userSignup.Any(s => s.Email == loginUser.Email))
            {
                var checkuser = _context.userSignup.Where(s => s.Email == loginUser.Email).FirstOrDefault();

                if (checkuser.Password == loginUser.Password)
                {
                    return Ok(checkuser.Id);
                }
            }
            return NotFound();



        }


        [HttpPost("checkloginadmin")]

        public async Task<IActionResult> checkadmin(LoginAdmin loginAdmin)
        {
            if (_context.adminsignup.Any(s => s.Email == loginAdmin.Email))
            {
                var checkadmin = _context.adminsignup.Where(s => s.Email == loginAdmin.Email).FirstOrDefault();

                if (checkadmin.Password == loginAdmin.Password)
                {
                    return Ok(checkadmin.Id);
                }
            }
            return NotFound();



        }



        [HttpGet("UserSignup")]
        public async Task<ActionResult<IEnumerable<UserSignup>>> GetUserSignup()
        {
            // Retrieve all user signups from the database
            var userSignups = await _context.userSignup.ToListAsync();

            // If no user signups are found, return a 404 Not Found response
            if (userSignups == null || userSignups.Count == 0)
            {
                return NotFound("No user signups found.");
            }

            // If user signups are found, return a 200 OK response with the user signups
            return Ok(userSignups);
        }


        [HttpPost("AdminSignup")]
        public async Task<IActionResult> AdminSignUp([FromBody] AdminSignup admin)
        {
            // Perform validation, hashing passwords, etc.
            // Example: 
            //var admin = new AdminSignup { Email = model.Email, Password = model.Password };
            _context.adminsignup.Add(admin);
            await _context.SaveChangesAsync();
            return Ok("Signed up successfully!");
        }

        //[HttpPost("Login")]
        //public async Task<IActionResult> Login(Models.Login model)
        //{
        //    var user = await _context.userSignup.FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
        //    if (user != null)
        //    {
        //        return Ok("User logged in successfully!");
        //    }

        //    var admin = await _context.adminsignup.FirstOrDefaultAsync(a => a.Email == model.Email && a.Password == model.Password);
        //    if (admin != null)
        //    {
        //        return Ok("Admin logged in successfully!");
        //    }

        //    return Unauthorized("Invalid credentials");
        //}
    }
}
