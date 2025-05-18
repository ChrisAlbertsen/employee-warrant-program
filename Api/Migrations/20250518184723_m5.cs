using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class m5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WarrantAllocations_ApprovalGroups_ApprovalGroupId",
                table: "WarrantAllocations");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "WarrantAllocations");

            migrationBuilder.AddColumn<Guid>(
                name: "ApprovalGroupId1",
                table: "WarrantAllocations",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WarrantAllocations_ApprovalGroupId1",
                table: "WarrantAllocations",
                column: "ApprovalGroupId1");

            migrationBuilder.AddForeignKey(
                name: "FK_WarrantAllocations_ApprovalGroups_ApprovalGroupId",
                table: "WarrantAllocations",
                column: "ApprovalGroupId",
                principalTable: "ApprovalGroups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WarrantAllocations_ApprovalGroups_ApprovalGroupId1",
                table: "WarrantAllocations",
                column: "ApprovalGroupId1",
                principalTable: "ApprovalGroups",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WarrantAllocations_ApprovalGroups_ApprovalGroupId",
                table: "WarrantAllocations");

            migrationBuilder.DropForeignKey(
                name: "FK_WarrantAllocations_ApprovalGroups_ApprovalGroupId1",
                table: "WarrantAllocations");

            migrationBuilder.DropIndex(
                name: "IX_WarrantAllocations_ApprovalGroupId1",
                table: "WarrantAllocations");

            migrationBuilder.DropColumn(
                name: "ApprovalGroupId1",
                table: "WarrantAllocations");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "WarrantAllocations",
                type: "nvarchar(34)",
                maxLength: 34,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_WarrantAllocations_ApprovalGroups_ApprovalGroupId",
                table: "WarrantAllocations",
                column: "ApprovalGroupId",
                principalTable: "ApprovalGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
