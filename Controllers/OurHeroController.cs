using DotNetWebAPI.Model;
using DotNetWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DotNetWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OurHeroController : ControllerBase
    {
        public readonly IOurHeroService _heroService;

        public OurHeroController(IOurHeroService heroService) {
            _heroService = heroService;
        }
        [HttpGet]
        public IActionResult Get([FromQuery] bool? isActive = null)
        {
            return Ok(_heroService.GetAllHeros(isActive));
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id) {
            var hero = _heroService.GetHeroById(id);
                if (hero == null)
                {
                    return NotFound();
                }
                return Ok(hero);
        }
        [HttpPost]
        public IActionResult Post(AddUpdateOurHero heroObjet) {
        var hero =_heroService.AddOurHero(heroObjet);
            if (hero == null)
            {
                return BadRequest();
            }
            return Ok(new { 
            message = "Super Hero Created suessfully!!!",
            id = hero!.Id
            });
        
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Put([FromRoute]int id, [FromBody]AddUpdateOurHero heroObjet) {
            var hero = _heroService.UpdateOurHero(id, heroObjet);
            if (hero == null) {
                return NotFound();
            }
            return Ok(
                new { 
                message = "Super Hero Updated suessfully!!!",
                id = hero!.Id});
        }
        [HttpDelete]
        public IActionResult Delete([FromRoute] int id) {
            if (!_heroService.DeleteHerosByID(id)) {
                return NotFound();
            }
            return Ok(
                new {
                    message = "Super Hero Deleted suessfully!!!",
                    id = id
                });
        }
    }
}
