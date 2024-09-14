using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Arda_API.Models;

namespace Arda_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharactersController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Character>> GetCharacters()
        {
            // Logique pour récupérer les personnages
            return Ok(new List<Character>());
        }

        [Authorize]
        [HttpPost]
        public ActionResult<Character> AddCharacter([FromBody] Character character)
        {
            // Logique pour ajouter un personnage
            return Ok(character);
        }
    }
}