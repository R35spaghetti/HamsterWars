using HamsterWarsApi.Dto;
using Microsoft.AspNetCore.Mvc;
using HamsterWarsApi.Repositories;
using HamsterWarsApi.Models;
using HamsterWarsApi.Repositories.Contracts;

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

        [HttpGet]
        [Route(nameof(GetHamsters))]
        public async Task<ActionResult<IEnumerable<Hamster>>> GetHamsters()
        {
            try
            {
                var hamsters = await HamsterRepository.GetHamsters();
                //dto conversion
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
