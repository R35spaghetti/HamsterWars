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

        private async Task<bool> CheckIfHamsterExist(int Id)
        {
            return await this.hamsterDbContext.Hamsters.AnyAsync(x => x.Id == Id);
        }
        //Null här
        //TODO: Skapa en hamster
        public async Task<Hamster> CreateHamster(Hamster hamsterToAdd)
        {

            //Är denna ens korrekt?
            if (await CheckIfHamsterExist(hamsterToAdd.Id) == false)
              {
                var hamster = await (from Hamster in this.hamsterDbContext.Hamsters
                                     where Hamster.Id == hamsterToAdd.Id
                                     select new Hamster
                                     {
                                         Name = hamsterToAdd.Name,
                                         Age = hamsterToAdd.Age,
                                         FavFood = hamsterToAdd.FavFood,
                                         Loves = hamsterToAdd.Loves,
                                         ImgName = hamsterToAdd.ImgName,
                                         Wins = hamsterToAdd.Wins,
                                         Losses = hamsterToAdd.Losses,
                                         Games = hamsterToAdd.Games


                                     }).SingleOrDefaultAsync();


                if (hamsterToAdd != null)
                {
                    var result = await this.hamsterDbContext.Hamsters.AddAsync(hamsterToAdd);
                    await this.hamsterDbContext.SaveChangesAsync();
                    return result.Entity;
                }



                    
            }

            return null;
        }


        public async Task <Hamster> DeleteHamster(int id)
        {
            var hamster = await this.hamsterDbContext.Hamsters.FindAsync(id);
            if(hamster != null)
            {
                this.hamsterDbContext.Hamsters.Remove(hamster);
                await this.hamsterDbContext.SaveChangesAsync();
            }

            return hamster;
        }
   

        public async Task<Hamster> GetHamster(int id)
        {
            var hamster = await  this.hamsterDbContext.Hamsters.SingleOrDefaultAsync(x=>x.Id == id);
            return hamster;
        }

        public async Task<IEnumerable<Hamster>> GetHamsters()
        {

            return await this.hamsterDbContext.Hamsters.ToArrayAsync();
          
        }
        //TODO: Får fram en slumpad hamster
        public  Task<Hamster> GetRandomHamster()
        {
            throw new NotImplementedException();
        }

        //TODO: fixa att en sak blir uppdaterad och resten får gamla värden, eller om det sker i frontend?
        public async Task<Hamster> UpdateHamster(int id, Hamster hamsterToUpdate)
        {
            var hamster = await this.hamsterDbContext.Hamsters.FindAsync(id);

            if (hamster != null)
            {
                hamster.Name = hamsterToUpdate.Name;
                hamster.Age = hamsterToUpdate.Age;
                hamster.FavFood = hamsterToUpdate.FavFood;
                hamster.Loves = hamsterToUpdate.Loves;
                hamster.ImgName = hamsterToUpdate.ImgName;
                hamster.Wins = hamsterToUpdate.Wins;
                hamster.Losses = hamsterToUpdate.Losses;
                hamster.Games = hamsterToUpdate.Games;

               return hamster;
            }
            return null;
        }
    }
}
