using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthStore.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataforPatient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "PatientDoc", "PatientName", "PhoneNumber", "weight" },
                values: new object[] { new Guid("8f5d33a7-9ac7-4fc1-84a3-21e1c1829f7e"), "Mr. String", "GHJ", 1234567890, 66.6f });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("8f5d33a7-9ac7-4fc1-84a3-21e1c1829f7e"));
        }
    }
}
