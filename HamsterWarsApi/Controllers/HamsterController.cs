using HamsterWarsApi.Dto;
using Microsoft.AspNetCore.Mvc;
using HamsterWarsApi.Repositories;
using HamsterWarsApi.Models;
using HamsterWarsApi.Repositories.Contracts;
using HamsterWarsApi.Extensions;

namespace HamsterWarsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HamsterController : ControllerBase
    {

        private readonly HamsterRepository HamsterRepository;

        public HamsterController(IHamsterRepository HamsterRepository)
        {
            this.HamsterRepository = (HamsterRepository?)HamsterRepository;
        }

        //Hämta alla hamstrar
        [HttpGet]
        [Route(nameof(GetHamsters))]
        public async Task<ActionResult<IEnumerable<HamsterDTO>>> GetHamsters()
        {
            try
            {
                var hamsters = await HamsterRepository.GetHamsters();

                if (hamsters is null)
                {
                    return NotFound();
                }
                else
                {
                    var hamstersDtos = hamsters.ConvertToHamstersDTO();
                    return Ok(hamstersDtos);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Error retrieving data from the database");
            }



        }
        //Hämta en hamster
        [HttpGet("{id:int}")]
        public async Task<ActionResult<HamsterDTO>> GetHamster(int id)
        {
            try
            {
                var hamster = await HamsterRepository.GetHamster(id);

                if (hamster == null)
                {
                    return BadRequest();
                }
                else
                {
                    var hamsterDto = hamster.ConvertToHamsterDTO();
                    return Ok(hamsterDto);
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Error retrieving data from the database");
            }



        }

        //Hämta en slumpmässig hamster
        [HttpGet]
        [Route(nameof(GetRandomHamster))]
        public async Task<ActionResult<HamsterDTO>> GetRandomHamster()
        {
            try
            {
                var hamster = await HamsterRepository.GetRandomHamster();

                if (hamster == null)
                {
                    return BadRequest();
                }
                else
                {
                    var hamsterDto = hamster.ConvertToHamsterDTO();
                    return Ok(hamsterDto);
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Error retrieving data from the database");
            }



        }


        //Skapa hamster
        [HttpPost]
        public async Task<ActionResult<HamsterToCreateDTO>> CreateHamster(string Name, int Age, string FavFood, string Loves, string ImgName, int Wins, int losses, int games, [FromBody] Hamster createHamster)
        {
            //Här funkar create, bryt i en egen metod eller använd autoMapping
            createHamster.Name = Name;
            createHamster.Age = Age;
            createHamster.FavFood = FavFood;
            createHamster.Loves = Loves;
            createHamster.ImgName = ImgName;
            createHamster.Wins = Wins;
            createHamster.Losses = losses;
            createHamster.Games = games;

            var newHamster = await this.HamsterRepository.CreateHamster(createHamster);

            if (createHamster is null)
            {
                return NoContent();

            }


            var newHamsterDTO = newHamster.ConvertToHamsterDTO();

            return CreatedAtAction(nameof(CreateHamster), new {Name = createHamster.Name, Age = createHamster.Age, FavFood = createHamster.FavFood, Loves = createHamster.Loves, ImgName = createHamster.ImgName, Wins = createHamster.Wins, losses = createHamster.Losses, games = createHamster.Games}, createHamster);



        }

        //Ta bort hamster
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<HamsterDTO>> DeleteHamster(int id)
        {
            try
            {
                var hamster = await this.HamsterRepository.DeleteHamster(id);

                if (hamster == null)
                {
                    return NotFound();
                }

                var hamsterDTO = hamster.ConvertToHamsterDTO();

                return Ok(hamsterDTO);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }


        }
        //Uppdatera hamster
        [HttpPut("{id:int}")]
        public async Task<ActionResult<HamsterToUpdateDTO>> UpdateHamster(int id, string Name, int Age, string FavFood, string Loves, string ImgName, int Wins, int losses, int games, [FromBody] Hamster hamsterToUpdate)
        {
            //Bör vara i samma metod som create använder, TODO: använd tuple här
            hamsterToUpdate.Name = Name;
            hamsterToUpdate.Age = Age;
            hamsterToUpdate.FavFood = FavFood;
            hamsterToUpdate.Loves = Loves;
            hamsterToUpdate.ImgName = ImgName;
            hamsterToUpdate.Wins = Wins;
            hamsterToUpdate.Losses = losses;
            hamsterToUpdate.Games = games;

            try
            {
                var hamster = await this.HamsterRepository.UpdateHamster(id, hamsterToUpdate);
                if (hamster == null)
                {
                    return NotFound();
                }


                var hamsterDTO = hamster.ConvertToHamsterDTO();

                return Ok(hamsterDTO);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }
    }

}
