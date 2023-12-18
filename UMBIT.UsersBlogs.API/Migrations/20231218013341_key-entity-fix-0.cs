using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UMBIT.UsersBlogs.API.Migrations
{
    public partial class keyentityfix0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdGenerico",
                table: "User",
                newName: "IdKey");

            migrationBuilder.RenameColumn(
                name: "IdGenerico",
                table: "Blog",
                newName: "IdKey");

            migrationBuilder.AddColumn<int>(
                name: "Index",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Index",
                table: "Blog",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Index",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Index",
                table: "Blog");

            migrationBuilder.RenameColumn(
                name: "IdKey",
                table: "User",
                newName: "IdGenerico");

            migrationBuilder.RenameColumn(
                name: "IdKey",
                table: "Blog",
                newName: "IdGenerico");
        }
    }
}
