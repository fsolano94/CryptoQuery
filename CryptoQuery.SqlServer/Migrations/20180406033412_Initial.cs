using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CryptoQuery.SqlServer.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArticleQueryProfile",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Complexity = table.Column<int>(nullable: false),
                    PushEnabled = table.Column<bool>(nullable: false),
                    Quality = table.Column<int>(nullable: false),
                    Topics = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleQueryProfile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Author = table.Column<string>(nullable: true),
                    Complexity = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    DateOfPublification = table.Column<DateTime>(nullable: false),
                    Quality = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Topic = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ArticleQueryProfileId = table.Column<Guid>(nullable: true),
                    CreatedAt = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    HashedPassword = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true),
                    Salt = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_ArticleQueryProfile_ArticleQueryProfileId",
                        column: x => x.ArticleQueryProfileId,
                        principalTable: "ArticleQueryProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_ArticleQueryProfileId",
                table: "Users",
                column: "ArticleQueryProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ArticleQueryProfile");
        }
    }
}
