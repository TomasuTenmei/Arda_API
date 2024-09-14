using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Arda_API.Models;

namespace Arda_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeaponsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Weapon>> GetWeapons()
        {
            // Logique pour récupérer les armes
            return Ok(new List<Weapon>());
        }

        [Authorize]
        [HttpPost]
        public ActionResult<Weapon> AddWeapon([FromBody] Weapon weapon)
        {
            // Logique pour ajouter une arme
            return Ok(weapon);
        }
    }
}