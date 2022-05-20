using HamsterWarsApi.Dto;
using HamsterWarsApi.Models;

namespace HamsterWarsApi.Repositories.Contracts
{
    public interface IHamsterRepository
    {
        //Endast ha DTOhamstern?
        Task<IEnumerable<Hamster>> GetHamsters();
        Task<Hamster> GetRandomHamster(int id);

        Task<Hamster> GetHamster(int id);

        Task CreateHamster(HamsterDTO hamster);

        Task UpdateHamster(int id, HamsterDTO hamsterToUpdate);

        Task DeleteHamster(int id);



    }
}
