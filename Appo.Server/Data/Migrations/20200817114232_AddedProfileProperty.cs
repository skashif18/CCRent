using Microsoft.EntityFrameworkCore.Migrations;

namespace Appo.Server.Data.Migrations
{
    public partial class AddedProfileProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Profile_Biography",
                table: "AspNetUsers",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Profile_Gender",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Profile_Name",
                table: "AspNetUsers",
                type: "nvarchar(72)",
                maxLength: 72,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Profile_PrivateProfile",
                table: "AspNetUsers",
                type: "bit",
                nullable: true,
                defaultValue:false);

            migrationBuilder.AddColumn<string>(
                name: "Profile_ProfilePhotoUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Profile_Website",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Profile_Biography",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Profile_Gender",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Profile_Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Profile_PrivateProfile",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Profile_ProfilePhotoUrl",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Profile_Website",
                table: "AspNetUsers");
        }
    }
}
