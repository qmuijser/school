using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Context;
using api.Models;
using api.Auth;
using Microsoft.AspNetCore.Authorization;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private PasswordManager passwordManager;
        private AuthenticationHandler authenticationHandler;
        private JWTHandler jwtHandler;


        public UsersController(DatabaseContext context)
        {
            _context = context;
            passwordManager = new PasswordManager();
            jwtHandler = new JWTHandler();
            authenticationHandler = new AuthenticationHandler(passwordManager,_context,jwtHandler);
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            return await _context.User.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            //Hash password
            user.Password = passwordManager.HashPassword(user.Password);
            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }

        [HttpPost]
        [Route("login"), ActionName("login")]
        public async Task<IActionResult> Login([FromBody] UserLogin login)
        {
            try
            {
                return Ok(new { Token = authenticationHandler.LoginUser(login) });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return Unauthorized();
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register"), ActionName("createAccount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateAccount([FromBody] UserCreate userCreate)
        {
            try
            {
                if (userCreate == null)
                {
                    return BadRequest("Empty body");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Request doesn't pass validation");
                }
                User createdUser = authenticationHandler.CreateUser(userCreate);
                return CreatedAtAction("createAccount", new { id = createdUser.UserId }, createdUser);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, "Internal server error");
            }
        }


        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.UserId == id);
        }
    }
}
