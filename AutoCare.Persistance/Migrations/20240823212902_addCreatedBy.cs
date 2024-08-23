using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoCare.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class addCreatedBy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "SocialMedias",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "SocialMedias");
        }
    }
}
