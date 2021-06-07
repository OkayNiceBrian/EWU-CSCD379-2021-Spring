using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using SecretSanta.Business;

namespace SecretSanta.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiftsController : ControllerBase
    {
        private IGiftRepository GroupRepository { get; }

        public GiftsController(IGiftRepository repository)
        {
            GiftRepository = repository ?? throw new System.ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public IEnumerable<Dto.Gift> Get()
        {
            return GiftRepository.List().Select(x => Dto.Group.ToDto(x)!);
        }

        [HttpGet("{id}")]
        public ActionResult<Dto.Gift?> Get(int id)
        {
            return GiftRepository.List(id).Select(item => Dto.Gift.ToDto(item)!);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public ActionResult Delete(int id)
        {
            if (GiftRepository.Remove(id))
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Dto.Gift), (int)HttpStatusCode.OK)]
        public ActionResult<Dto.Gift?> Post([FromBody] Dto.Gift gift)
        {
            return Dto.Gift.ToDto(GiftRepository.Create(Dto.Gift.FromDto(gift)!));
        }
    }
}
