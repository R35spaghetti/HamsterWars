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
        //TODO: Fixa med "parameters"
        //Skapa hamster
        [HttpPost]
        public async Task<ActionResult<HamsterDTO>> CreateHamster([FromBody] Hamster createHamster)
        {

            var newHamster = await this.HamsterRepository.CreateHamster(createHamster);

            if (createHamster is null)
            {
                return NoContent();

            }
          

            //var newHamsterDTO = newHamster.ConvertToHamsterDTO();

            return CreatedAtAction(nameof(CreateHamster), new {id = createHamster.Id}, createHamster);



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
        [HttpPatch("{id:int}")]
        public async Task<ActionResult<HamsterDTO>> UpdateHamster(int id, Hamster hamsterToUpdate)
        {
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
