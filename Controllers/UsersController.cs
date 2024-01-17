using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InternetStore.Context;
using InternetStore.Models;
using InternetStore.Services.IRepositories;
using InternetStore.DTOs;
using InternetStore.Converters;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace InternetStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly InternetStoreContext _context;
        private readonly UserConverter userConverter = new UserConverter();

        public UsersController(IUnitOfWork unitOfWork, IConfiguration configuration, InternetStoreContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _configuration = configuration;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(decimal id)
        {
          if (_unitOfWork.Users == null)
          {
              return NotFound();
          }
            var user = await _unitOfWork.Users.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserDTO>> PostUser(UserDTO userDTO)
        {
          if (_context.Users == null)
          {
              return Problem("Entity set 'InternetStoreContext.Users'  is null.");
          }

            var passwordHasher = new PasswordHasher<UserDTO>();

            var user = new User()
            {
                UserNickname = userDTO.UserNickname,
                UserName = userDTO.UserName,
                UserSurname = userDTO.UserSurname,
                UserEmail = userDTO.UserEmail,
                UserNumber = userDTO.UserNumber,
                UserPassword = passwordHasher.HashPassword(userDTO, userDTO.UserPassword),
                UserCreationDate = DateTime.Now
        };

            await _unitOfWork.Users.Insert(user);
            await _unitOfWork.CompleteAsync();
            var cart = new Cart()
            {
                UserId = user.UserId
            };
            await _unitOfWork.Carts.Insert(cart);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction("GetUser", new { id = user.UserId }, userConverter.Convert(user));
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(decimal id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("login")]
        public async Task<ActionResult<TokenDTO>> Login(LoginDTO login)
        {
            if (login != null && login.UserEmail != null && login.UserPassword != null)
            {
              
                var user = await _unitOfWork.Users.GetUser(login);
                var passwordHasher = new PasswordHasher<LoginDTO>();

                if (user != null && passwordHasher.VerifyHashedPassword(login, user.UserPassword, login.UserPassword) == PasswordVerificationResult.Success)
                {

                    //create claims details based on the user information
                    var claims = new[] {
                        new Claim("UserId", user.UserId.ToString()),
                        new Claim("Nickname", user.UserNickname),
                        new Claim("Name", user.UserName),
                        new Claim("Surname", user.UserSurname),
                        new Claim("Email", user.UserEmail)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    UserConverter userConverter = new UserConverter();
                    var userDTO = userConverter.Convert(user);
                    userDTO.UserPassword = user.UserId.ToString();

                    TokenDTO tokenDTO = new TokenDTO()
                    {
                        Token = new JwtSecurityTokenHandler().WriteToken(token),
                        User = userDTO,
                        expiresIn = token.ValidTo
                   
                    };

                    return Ok(tokenDTO);
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
