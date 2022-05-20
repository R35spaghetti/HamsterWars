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
        public async Task<ActionResult<IEnumerable<HamsterDTO>>> GetHamsters()
        {
            try
            {
                var hamsters = await HamsterRepository.GetHamsters();
                //TODO: DTO conversion
                        return Ok(hamsters);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Error retrieving data from the database");
            }

            

        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<HamsterDTO>> GetHamster(int id)
        {
            try
            {
                var hamster = await HamsterRepository.GetHamster(id);
                //TODO: conversion
                if (hamster == null)
                {
                    return BadRequest();
                }
                else
                {
                    return Ok(hamster);
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Error retrieving data from the database");
            }



        }
    }

}
