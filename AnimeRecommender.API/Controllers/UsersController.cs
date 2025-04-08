using AnimeRecommender.API.Models;
using AnimeRecommender.Application.Services;
using AnimeRecommender.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AnimeRecommender.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _userService.GetAllUsersAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            return user == null ? NotFound() : Ok(user);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateUserRequest request)
        {
            var user = new User(
                request.Nome,
                request.DataNascimento,
                request.Cpf,
                request.Rg
            );

            _userService.CreateUserAsync(user); 

            return Ok(user); 
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] CreateUserRequest request)
        {
            var existingUser = await _userService.GetUserByIdAsync(id);
            if (existingUser == null)
                return NotFound();

            existingUser.Update(
                request.Nome,
                request.DataNascimento,
                request.Cpf,
                request.Rg
            );

            await _userService.UpdateUserAsync(existingUser);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
    }

}
