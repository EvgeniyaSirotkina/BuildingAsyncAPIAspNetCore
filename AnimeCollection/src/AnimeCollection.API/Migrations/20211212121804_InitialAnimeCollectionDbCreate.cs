using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimeCollection.API.Migrations
{
    public partial class InitialAnimeCollectionDbCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    OriginalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalAlias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Studios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    OriginalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearOfFoundation = table.Column<int>(type: "int", nullable: false),
                    PresidentName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    OriginalPresidentName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnimeCollection",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    OriginalTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DirectorName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    OriginalDirectorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfPremiere = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfSeries = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeCollection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnimeCollection_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimeCollection_Studios_StudioId",
                        column: x => x.StudioId,
                        principalTable: "Studios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Alias", "DateOfBirth", "Name", "OriginalAlias", "OriginalName" },
                values: new object[,]
                {
                    { new Guid("00c84da1-a331-48a2-aa1d-f96e937abda3"), "Tite Kubo", new DateTime(1977, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Noriyaki Kubo", null, "久保 宣章" },
                    { new Guid("eac6b73d-4fdc-4130-85ff-7ae7c10f1e61"), null, new DateTime(1975, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oda Eiichiro", null, "尾田 栄一郎" },
                    { new Guid("92437869-7e2a-4523-a991-69870ceff328"), null, new DateTime(1941, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hayao Miyazaki", null, "宮崎 駿" },
                    { new Guid("7aba6f15-1c72-4895-a790-378910dd9f6b"), null, new DateTime(1962, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hiiragi Aoi", null, "柊 あおい" }
                });

            migrationBuilder.InsertData(
                table: "Studios",
                columns: new[] { "Id", "Name", "OriginalName", "OriginalPresidentName", "PresidentName", "YearOfFoundation" },
                values: new object[,]
                {
                    { new Guid("a7cdeec1-e15b-4d33-a83c-c05c79bfad76"), "Studio Pierrot", "株式会社ぴえろ", null, "Yuji Nunokawa", 1979 },
                    { new Guid("aa134a5c-a0c4-4d7f-bfb0-c4994c2d578a"), "Toei Animation", "東映アニメーション株式会社", null, null, 1956 },
                    { new Guid("32ddd588-272f-4e61-ad82-a6799063e44e"), "Studio Ghibli", "スタジオジブリ", null, "Hayao Miyazaki", 1985 }
                });

            migrationBuilder.InsertData(
                table: "AnimeCollection",
                columns: new[] { "Id", "AuthorId", "DateOfPremiere", "DirectorName", "NumberOfSeries", "OriginalDirectorName", "OriginalTitle", "StudioId", "Title" },
                values: new object[] { new Guid("53d382c0-8522-4bee-96ab-6b4e1cadb1e1"), new Guid("00c84da1-a331-48a2-aa1d-f96e937abda3"), new DateTime(2004, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Abe Noriyuki", 366, null, "ブリーチ", new Guid("a7cdeec1-e15b-4d33-a83c-c05c79bfad76"), "Bleach" });

            migrationBuilder.InsertData(
                table: "AnimeCollection",
                columns: new[] { "Id", "AuthorId", "DateOfPremiere", "DirectorName", "NumberOfSeries", "OriginalDirectorName", "OriginalTitle", "StudioId", "Title" },
                values: new object[] { new Guid("00c535c2-6abc-4480-a64b-00f6cc49cc5d"), new Guid("eac6b73d-4fdc-4130-85ff-7ae7c10f1e61"), new DateTime(1999, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Konosuke Uda", 990, null, "ワンピース", new Guid("aa134a5c-a0c4-4d7f-bfb0-c4994c2d578a"), "One Piece" });

            migrationBuilder.InsertData(
                table: "AnimeCollection",
                columns: new[] { "Id", "AuthorId", "DateOfPremiere", "DirectorName", "NumberOfSeries", "OriginalDirectorName", "OriginalTitle", "StudioId", "Title" },
                values: new object[] { new Guid("6a53a23a-f4fc-4674-b43c-1e91d97b763e"), new Guid("7aba6f15-1c72-4895-a790-378910dd9f6b"), new DateTime(1995, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yoshifumi Kondo", 0, null, "耳をすませば", new Guid("32ddd588-272f-4e61-ad82-a6799063e44e"), "Whisper of the Heart" });

            migrationBuilder.CreateIndex(
                name: "IX_AnimeCollection_AuthorId",
                table: "AnimeCollection",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimeCollection_StudioId",
                table: "AnimeCollection",
                column: "StudioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimeCollection");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Studios");
        }
    }
}
