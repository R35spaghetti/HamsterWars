using HamsterWarsApi.Models;

namespace HamsterWarsApi.Repositories.Contracts
{
    public interface IHamsterRepository
    {
        //Endast ha DTOhamstern?
        Task<IEnumerable<Hamster>> GetHamsters();
        Task<Hamster> GetRandomHamster(int id);

        Task<Hamster> GetHamster(int id);

        Task CreateHamster(Hamster hamster);

        Task UpdateHamster(int id, Hamster hamsterToUpdate);

        Task DeleteHamster(int id);



    }
}
