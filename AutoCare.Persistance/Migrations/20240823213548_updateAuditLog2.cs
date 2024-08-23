using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoCare.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class updateAuditLog2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "SocialMedias",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "SocialMedias",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "SocialMedias");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "SocialMedias");
        }
    }
}
