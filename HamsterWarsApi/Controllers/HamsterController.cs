using HamsterWarsApi.Dto;
using Microsoft.AspNetCore.Mvc;
using HamsterWarsApi.Repositories;
using HamsterWarsApi.Models;

namespace HamsterWarsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HamsterController : ControllerBase
    {

        private readonly HamsterRepository HamsterRepository;

        public HamsterController(HamsterRepository hamsterRepository)
        {
            this.HamsterRepository = hamsterRepository;
        }

        [HttpGet]
        [Route(nameof(GetHamsters))]
        public async Task<ActionResult<IEnumerable<Hamster>>> GetHamsters()
        {
            try
            {
                var hamsters = await HamsterRepository.GetHamsters();
                        return Ok(hamsters);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Error retrieving data from the database");
            }

            

        }

    }

}
