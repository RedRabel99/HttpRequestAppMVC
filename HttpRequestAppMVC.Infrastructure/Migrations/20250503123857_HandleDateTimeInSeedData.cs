using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HttpRequestAppMVC.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class HandleDateTimeInSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "HttpHeaders",
                keyColumn: "Id",
                keyValue: new Guid("45a2d89c-185b-ff39-98ef-70c05b9b5983"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "HttpHeaders",
                keyColumn: "Id",
                keyValue: new Guid("c55a10dc-232c-9f7f-09c7-4b0767f64f74"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "HttpHeaders",
                keyColumn: "Id",
                keyValue: new Guid("45a2d89c-185b-ff39-98ef-70c05b9b5983"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 3, 12, 33, 29, 872, DateTimeKind.Utc).AddTicks(1073), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HttpHeaders",
                keyColumn: "Id",
                keyValue: new Guid("c55a10dc-232c-9f7f-09c7-4b0767f64f74"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 3, 12, 33, 29, 867, DateTimeKind.Utc).AddTicks(5738), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
