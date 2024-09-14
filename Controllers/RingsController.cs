using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Arda_API.Models;

namespace Arda_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RingsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Ring>> GetRings()
        {
            // Logique pour récupérer les anneaux
            return Ok(new List<Ring>());
        }

        [Authorize]
        [HttpPost]
        public ActionResult<Ring> AddRing([FromBody] Ring ring)
        {
            // Logique pour ajouter un anneau
            return Ok(ring);
        }
    }
}
