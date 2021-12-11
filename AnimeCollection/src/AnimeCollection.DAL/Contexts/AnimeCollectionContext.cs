using AnimeCollection.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace AnimeCollection.DAL.Contexts
{
    public class AnimeCollectionContext : DbContext
    {
        public DbSet<Anime> AnimeCollection { get; set; }

        public AnimeCollectionContext(DbContextOptions<AnimeCollectionContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Studio>().HasData(
                new Studio
                {
                    Id = Guid.Parse("a7cdeec1-e15b-4d33-a83c-c05c79bfad76"),
                    Name = "Studio Pierrot",
                    OriginalName = "株式会社ぴえろ",
                    YearOfFoundation = 1979,
                    PresidentName = "Yuji Nunokawa",
                },
                new Studio
                {
                    Id = Guid.Parse("aa134a5c-a0c4-4d7f-bfb0-c4994c2d578a"),
                    Name = "Toei Animation",
                    OriginalName = "東映アニメーション株式会社",
                    YearOfFoundation = 1956,
                },
                new Studio
                {
                    Id = Guid.Parse("32ddd588-272f-4e61-ad82-a6799063e44e"),
                    Name = "Studio Ghibli",
                    OriginalName = "スタジオジブリ",
                    YearOfFoundation = 1985,
                    PresidentName = "Hayao Miyazaki",
                });

            modelBuilder.Entity<Author>().HasData(
                new Author
                {
                    Id = Guid.Parse("00c84da1-a331-48a2-aa1d-f96e937abda3"),
                    Name = "Noriyaki Kubo",
                    OriginalName = "久保 宣章",
                    Alias = "Tite Kubo",
                    DateOfBirth = new DateTime(1977, 6, 26),
                },
                new Author
                {
                    Id = Guid.Parse("eac6b73d-4fdc-4130-85ff-7ae7c10f1e61"),
                    Name = "Oda Eiichiro",
                    OriginalName = "尾田 栄一郎",
                    DateOfBirth = new DateTime(1975, 1, 1),
                },
                new Author
                {
                    Id = Guid.Parse("92437869-7e2a-4523-a991-69870ceff328"),
                    Name = "Hayao Miyazaki",
                    OriginalName = "宮崎 駿",
                    DateOfBirth = new DateTime(1941, 1, 5),
                },
                new Author
                {
                    Id = Guid.Parse("7aba6f15-1c72-4895-a790-378910dd9f6b"),
                    Name = "Hiiragi Aoi",
                    OriginalName = "柊 あおい",
                    DateOfBirth = new DateTime(1962, 11, 22),
                });

            modelBuilder.Entity<Anime>().HasData(
                new Anime
                {
                    Id = Guid.Parse("6a53a23a-f4fc-4674-b43c-1e91d97b763e"),
                    Title = "Whisper of the Heart",
                    OriginalTitle = "耳をすませば",
                    DirectorName = "Yoshifumi Kondo",
                    DateOfPremiere = new DateTime(1995, 7, 15),
                    StudioId = Guid.Parse("32ddd588-272f-4e61-ad82-a6799063e44e"),
                    AuthorId = Guid.Parse("7aba6f15-1c72-4895-a790-378910dd9f6b"),
                },
                new Anime
                {
                    Id = Guid.Parse("00c535c2-6abc-4480-a64b-00f6cc49cc5d"),
                    Title = "One Piece",
                    OriginalTitle = "ワンピース",
                    DirectorName = "Konosuke Uda",
                    DateOfPremiere = new DateTime(1999, 10, 20),
                    NumberOfSeries = 990,
                    StudioId = Guid.Parse("aa134a5c-a0c4-4d7f-bfb0-c4994c2d578a"),
                    AuthorId = Guid.Parse("eac6b73d-4fdc-4130-85ff-7ae7c10f1e61"),
                },
                new Anime
                {
                    Id = Guid.Parse("53d382c0-8522-4bee-96ab-6b4e1cadb1e1"),
                    Title = "Bleach",
                    OriginalTitle = "ブリーチ",
                    DirectorName = "Abe Noriyuki",
                    DateOfPremiere = new DateTime(2004, 10, 5),
                    NumberOfSeries = 366,
                    StudioId = Guid.Parse("a7cdeec1-e15b-4d33-a83c-c05c79bfad76"),
                    AuthorId = Guid.Parse("00c84da1-a331-48a2-aa1d-f96e937abda3"),
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
