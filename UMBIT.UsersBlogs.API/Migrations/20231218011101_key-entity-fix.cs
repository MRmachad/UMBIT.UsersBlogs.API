using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UMBIT.UsersBlogs.API.Migrations
{
    public partial class keyentityfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdKey",
                table: "User");

            migrationBuilder.DropColumn(
                name: "IdKey",
                table: "Blog");

            migrationBuilder.AddColumn<Guid>(
                name: "IdGenerico",
                table: "User",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "IdGenerico",
                table: "Blog",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdGenerico",
                table: "User");

            migrationBuilder.DropColumn(
                name: "IdGenerico",
                table: "Blog");

            migrationBuilder.AddColumn<int>(
                name: "IdKey",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdKey",
                table: "Blog",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
