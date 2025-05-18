using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class m4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ApprovalGroupId",
                table: "WarrantAllocations",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "WarrantAllocations",
                type: "nvarchar(34)",
                maxLength: 34,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ApprovalGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalGroups", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WarrantAllocations_ApprovalGroupId",
                table: "WarrantAllocations",
                column: "ApprovalGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_WarrantAllocations_ApprovalGroups_ApprovalGroupId",
                table: "WarrantAllocations",
                column: "ApprovalGroupId",
                principalTable: "ApprovalGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WarrantAllocations_ApprovalGroups_ApprovalGroupId",
                table: "WarrantAllocations");

            migrationBuilder.DropTable(
                name: "ApprovalGroups");

            migrationBuilder.DropIndex(
                name: "IX_WarrantAllocations_ApprovalGroupId",
                table: "WarrantAllocations");

            migrationBuilder.DropColumn(
                name: "ApprovalGroupId",
                table: "WarrantAllocations");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "WarrantAllocations");
        }
    }
}
