using HamsterWarsApi.Models;

namespace HamsterWarsApi.Repositories.Contracts
{
    public interface IHamsterRepository
    {
        //Endast ha DTOhamstern?
        Task<IEnumerable<Hamster>> GetHamsters();
        Task<Hamster> GetRandomHamster();

        Task<Hamster> GetHamster(int id);

        Task<Hamster> CreateHamster(Hamster hamster);

        Task<Hamster> UpdateHamster(int id, Hamster hamsterToUpdate);

        Task<Hamster> DeleteHamster(int id);



    }
}
