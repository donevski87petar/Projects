﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaniaAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Genre = table.Column<int>(nullable: false),
                    Rating = table.Column<double>(nullable: false),
                    LengthMin = table.Column<int>(nullable: false),
                    ReleaseYear = table.Column<int>(nullable: false),
                    Director = table.Column<string>(nullable: true),
                    Actors = table.Column<string>(nullable: true),
                    Cover = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
