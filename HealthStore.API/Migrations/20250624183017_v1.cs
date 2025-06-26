using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthStore.API.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PatientName = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    weight = table.Column<float>(type: "REAL", nullable: false),
                    PatientDoc = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vitals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    PatDoc = table.Column<string>(type: "TEXT", nullable: true),
                    SPO2 = table.Column<int>(type: "INTEGER", nullable: false),
                    BloodPressure = table.Column<string>(type: "TEXT", nullable: true),
                    SugarLevel = table.Column<string>(type: "TEXT", nullable: true),
                    BeatsPerMinute = table.Column<int>(type: "INTEGER", nullable: false),
                    Temperature = table.Column<string>(type: "TEXT", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vitals", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Vitals");
        }
    }
}
