namespace HamsterWarsApi.Dto
{
    public record HamsterDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Age { get; set; }

        public string FavFood { get; set; } = string.Empty;

        public string Loves { get; set; } = string.Empty;

        public string ImgName { get; set; } = string.Empty;

        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Games { get; set; }
    }
}
