using ControllerApiDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace ControllerApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController : ControllerBase
    {
        private static List<Hero> listOfHeroes = new List<Hero>()
        {
            new Hero() {Id = 1, Name = "Clark Kent", SuperHeroName = "Superman", Team = "DC Universe" },
            new Hero() {Id = 2, Name = "Bruce Wayne", SuperHeroName = "Batman", Team = "DC Universe" },
            new Hero() {Id = 3, Name = "Peter Parker", SuperHeroName = "Spiderman", Team = "Marvel Universe" },
            new Hero() {Id = 4, Name = "Bruce Banner", SuperHeroName = "Hulk", Team = "DC Universe" },
            new Hero() {Id = 5, Name = "Tobias Jäderberg", SuperHeroName = "Big D", Team = "Cloud Universe" }
        };


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(listOfHeroes);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(listOfHeroes.FirstOrDefault(h => h.Id == id));
        }

        [HttpPost]
        public IActionResult PostHero(Hero hero)
        {
            listOfHeroes.Add(hero);
            return Ok("Added new hero");
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteHero(int id)
        {
            var heroToDelete = listOfHeroes.FirstOrDefault(x => x.Id == id);
            if (heroToDelete == null)
            {
                return NotFound();
            }
            listOfHeroes.Remove(heroToDelete);
            return Ok("Hero Deleted");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateHero(Hero hero, int id)
        {
            var heroToUpdate = listOfHeroes.FirstOrDefault(x => x.Id == id);
            if (heroToUpdate == null)
            {
                return NotFound();
            }

            heroToUpdate.Name = hero.Name;
            heroToUpdate.Team = hero.Team;
            heroToUpdate.SuperHeroName = hero.SuperHeroName;
            return Ok("Hero updated");
        }
    }
}
