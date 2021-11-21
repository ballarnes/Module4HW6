using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Module4HW6.DataAccess.Migrations
{
    public partial class AllTablesDataAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Artist",
                columns: new[] { "Id", "DateOfBirth", "Email", "InstagramURL", "IsAlive", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, new DateTime(1985, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "artist1@email.com", "https://www.instagram.com/artist1", true, "Artist1", "+11111111111" },
                    { 2, new DateTime(1942, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "Artist2", null },
                    { 3, new DateTime(1972, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "artist3@email.com", "https://www.instagram.com/artist3", true, "Artist3", "+33333333333" },
                    { 4, new DateTime(1934, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "Artist4", null },
                    { 5, new DateTime(1992, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "artist5@email.com", "https://www.instagram.com/artist5", true, "Artist5", "+55555555555" },
                    { 6, new DateTime(1990, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "artist6@email.com", "https://www.instagram.com/artist6", true, "Artist6", "+66666666666" }
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Rock" },
                    { 2, "Pop" },
                    { 3, "Rap" },
                    { 4, "Blues" },
                    { 5, "Dance" }
                });

            migrationBuilder.InsertData(
                table: "Song",
                columns: new[] { "Id", "Duration", "GenreId", "ReleasedDate", "Title" },
                values: new object[] { 4, 190, null, new DateTime(1969, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Song4" });

            migrationBuilder.InsertData(
                table: "ArtistSong",
                columns: new[] { "Id", "ArtistId", "SongId" },
                values: new object[,]
                {
                    { 5, 4, 4 },
                    { 6, 2, 4 }
                });

            migrationBuilder.InsertData(
                table: "Song",
                columns: new[] { "Id", "Duration", "GenreId", "ReleasedDate", "Title" },
                values: new object[,]
                {
                    { 6, 180, 1, new DateTime(2012, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Song6" },
                    { 2, 161, 2, new DateTime(2016, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Song2" },
                    { 5, 177, 3, new DateTime(2017, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Song5" },
                    { 3, 177, 4, new DateTime(1950, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Song3" },
                    { 1, 231, 5, new DateTime(2007, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Song1" }
                });

            migrationBuilder.InsertData(
                table: "ArtistSong",
                columns: new[] { "Id", "ArtistId", "SongId" },
                values: new object[,]
                {
                    { 8, 5, 6 },
                    { 3, 3, 2 },
                    { 7, 6, 5 },
                    { 4, 4, 3 },
                    { 1, 1, 1 },
                    { 2, 6, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ArtistSong",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ArtistSong",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ArtistSong",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ArtistSong",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ArtistSong",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ArtistSong",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ArtistSong",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ArtistSong",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Artist",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Artist",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Artist",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Artist",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Artist",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Artist",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
