using HamsterWarsApi.Data;
using HamsterWarsApi.Dto;
using HamsterWarsApi.Models;
using HamsterWarsApi.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace HamsterWarsApi.Repositories
{
    public class HamsterRepository : IHamsterRepository
    {

        private readonly HamsterWarsDbContext hamsterDbContext;

        public HamsterRepository(HamsterWarsDbContext hamsterDbContext)
        {
            this.hamsterDbContext = hamsterDbContext;
        }

        public Task CreateHamster(Hamster hamster)
        {
            throw new NotImplementedException();
        }

        public Task DeleteHamster(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Hamster> GetHamster(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Hamster>> GetHamsters()
        {

            return await this.hamsterDbContext.Hamsters.ToArrayAsync();
            //var hamsters = await this.hamsterDbContext.Hamsters.ToArrayAsync();

            //return hamsters;
        }

        public Task<Hamster> GetRandomHamster(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateHamster(int id, Hamster hamsterToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
