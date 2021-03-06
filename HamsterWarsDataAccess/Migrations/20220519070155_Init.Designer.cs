// <auto-generated />
using HamsterWarsApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HamsterWarsDataAccess.Migrations
{
    [DbContext(typeof(HamsterWarsDbContext))]
    [Migration("20220519070155_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HamsterWarsApi.Models.Hamster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("FavFood")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Games")
                        .HasColumnType("int");

                    b.Property<string>("ImgName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Losses")
                        .HasColumnType("int");

                    b.Property<string>("Loves")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Wins")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Hamsters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 1,
                            FavFood = "Lime",
                            Games = 9,
                            ImgName = "hamster-1.jpg",
                            Losses = 4,
                            Loves = "Ice skating",
                            Name = "Testhamster",
                            Wins = 5
                        },
                        new
                        {
                            Id = 2,
                            Age = 1,
                            FavFood = "raspberries",
                            Games = 10,
                            ImgName = "hamster-2.jpg",
                            Losses = 3,
                            Loves = "scaring cats",
                            Name = "Tam",
                            Wins = 7
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
