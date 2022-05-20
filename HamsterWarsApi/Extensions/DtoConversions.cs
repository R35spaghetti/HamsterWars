using HamsterWarsApi.Dto;
using HamsterWarsApi.Models;

namespace HamsterWarsApi.Extensions
{
    public static class DtoConversions
    {
        public static IEnumerable<HamsterDTO> ConvertToHamstersDTO(this IEnumerable<Hamster> hamsters)
        {
            return (from hamster in hamsters select new HamsterDTO
            {
                Id = hamster.Id,
                Name = hamster.Name,
                Age = hamster.Age,
                FavFood = hamster.FavFood,
                Loves = hamster.Loves,
                ImgName = hamster.ImgName,
                Wins = hamster.Wins,
                Losses = hamster.Losses,
                Games = hamster.Games,

            }).ToArray();
        }

        public static HamsterDTO ConvertToHamsterDTO(this Hamster hamster)
        {
            return new HamsterDTO
            {
                Id = hamster.Id,
                Name = hamster.Name,
                Age = hamster.Age,
                FavFood = hamster.FavFood,
                Loves = hamster.Loves,
                ImgName = hamster.ImgName,
                Wins = hamster.Wins,
                Losses = hamster.Losses,
                Games = hamster.Games,

            };
        }
    }
}
