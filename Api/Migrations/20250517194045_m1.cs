using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class m1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConfirmationLetters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WarrantGrantCaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsSent = table.Column<bool>(type: "bit", nullable: false),
                    IsSigned = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfirmationLetters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cpr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WarrantAllocations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    StrikePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FullVestingDate = table.Column<DateOnly>(type: "date", nullable: false),
                    GrantDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ExercisePeriodStart = table.Column<DateOnly>(type: "date", nullable: false),
                    ExercisePeriodEnd = table.Column<DateOnly>(type: "date", nullable: false),
                    IsExercised = table.Column<bool>(type: "bit", nullable: false),
                    ExercisedOnDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarrantAllocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WarrantAllocations_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WarrantGrantCases",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConfirmationLetterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WarrantAllocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    IsSignatureRequested = table.Column<bool>(type: "bit", nullable: false),
                    IsApprovedByBoard = table.Column<bool>(type: "bit", nullable: false),
                    IsRegisteredBySkat = table.Column<bool>(type: "bit", nullable: false),
                    IsGranted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarrantGrantCases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WarrantGrantCases_ConfirmationLetters_ConfirmationLetterId",
                        column: x => x.ConfirmationLetterId,
                        principalTable: "ConfirmationLetters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WarrantGrantCases_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "Cpr", "Email", "FullName", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa1"), "1 Main Street", "0101010001", "alice@example.com", "Alice Andersen", "12345678" },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa2"), "2 Main Street", "0202020002", "bob@example.com", "Bob Bentsen", "23456789" },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa3"), "3 Main Street", "0303030003", "clara@example.com", "Clara Christensen", "34567890" },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa4"), "4 Main Street", "0404040004", "david@example.com", "David Dahl", "45678901" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_WarrantAllocations_EmployeeId",
                table: "WarrantAllocations",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_WarrantGrantCases_ConfirmationLetterId",
                table: "WarrantGrantCases",
                column: "ConfirmationLetterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WarrantGrantCases_EmployeeId",
                table: "WarrantGrantCases",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WarrantAllocations");

            migrationBuilder.DropTable(
                name: "WarrantGrantCases");

            migrationBuilder.DropTable(
                name: "ConfirmationLetters");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
