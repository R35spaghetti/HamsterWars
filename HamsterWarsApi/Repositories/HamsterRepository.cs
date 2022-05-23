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
        //Får fram en slumpad hamster
        public  async Task<Hamster> GetRandomHamster()
        {

            List<Hamster> allHamsterIDs = new List<Hamster>();
            Hamster getRandomHamster = new Hamster();
            int highestNumber = 0;


            var getLastID = await this.hamsterDbContext.Hamsters.OrderByDescending(x => x.Id).FirstOrDefaultAsync(); //LastOrDefaultAsync funkade inte
            highestNumber = getLastID.Id;


           await AddIDsToHamsterList(allHamsterIDs, highestNumber);


     
           getRandomHamster = GetOneRandomHamster(getRandomHamster, allHamsterIDs);



            return getRandomHamster;
        }

        private async Task AddIDsToHamsterList(List<Hamster> allHamsterIDs, int highestNumber)
        {
            for (int i = 1; i <= highestNumber; i++)
            {

                var hamster = await this.hamsterDbContext.Hamsters.SingleOrDefaultAsync(x => x.Id == i);

                if (hamster is null)
                { }

                else
                {
                    allHamsterIDs.Add(hamster);
                }
            }

        }

        //TODO: Funkar som sync?
        private Hamster GetOneRandomHamster(Hamster getRandomHamster, List<Hamster> allIDs)
        {
            int randomHamster = 0;
            var random = new Random();

            randomHamster = random.Next(allIDs.Count);


            randomHamster = random.Next(allIDs.Count);
            getRandomHamster = (allIDs[randomHamster]);
            
            return getRandomHamster;
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

        public Hamster AddValuesToHamster(Hamster hamster, string Name, int Age, string FavFood, string Loves, string ImgName, int Wins, int losses, int games)
        {
            hamster.Name = Name;
            hamster.Age = Age;
            hamster.FavFood = FavFood;
            hamster.Loves = Loves;
            hamster.ImgName = ImgName;
            hamster.Wins = Wins;
            hamster.Losses = losses;
            hamster.Games = games;

            return hamster;
        }
    }
}
