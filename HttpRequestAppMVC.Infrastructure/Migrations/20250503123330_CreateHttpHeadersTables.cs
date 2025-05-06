using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HttpRequestAppMVC.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateHttpHeadersTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestHeaderValues");

            migrationBuilder.CreateTable(
                name: "HttpHeaders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCommon = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HttpHeaders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HttpHeaderValues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCommon = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HttpHeaderValues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HttpRequestHeaders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HttpHeaderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HttpHeaderValueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HttpRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HttpRequestHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HttpRequestHeaders_HttpHeaderValues_HttpHeaderValueId",
                        column: x => x.HttpHeaderValueId,
                        principalTable: "HttpHeaderValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HttpRequestHeaders_HttpHeaders_HttpHeaderId",
                        column: x => x.HttpHeaderId,
                        principalTable: "HttpHeaders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HttpRequestHeaders_HttpRequests_HttpRequestId",
                        column: x => x.HttpRequestId,
                        principalTable: "HttpRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "HttpHeaders",
                columns: new[] { "Id", "CreatedAt", "IsCommon", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("45a2d89c-185b-ff39-98ef-70c05b9b5983"), new DateTime(2025, 5, 3, 12, 33, 29, 872, DateTimeKind.Utc).AddTicks(1073), true, "Authorization", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c55a10dc-232c-9f7f-09c7-4b0767f64f74"), new DateTime(2025, 5, 3, 12, 33, 29, 867, DateTimeKind.Utc).AddTicks(5738), true, "Content-Type", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HttpRequestHeaders_HttpHeaderId",
                table: "HttpRequestHeaders",
                column: "HttpHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_HttpRequestHeaders_HttpHeaderValueId",
                table: "HttpRequestHeaders",
                column: "HttpHeaderValueId");

            migrationBuilder.CreateIndex(
                name: "IX_HttpRequestHeaders_HttpRequestId",
                table: "HttpRequestHeaders",
                column: "HttpRequestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HttpRequestHeaders");

            migrationBuilder.DropTable(
                name: "HttpHeaderValues");

            migrationBuilder.DropTable(
                name: "HttpHeaders");

            migrationBuilder.CreateTable(
                name: "RequestHeaderValues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HttpRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Header = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestHeaderValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestHeaderValues_HttpRequests_HttpRequestId",
                        column: x => x.HttpRequestId,
                        principalTable: "HttpRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestHeaderValues_HttpRequestId",
                table: "RequestHeaderValues",
                column: "HttpRequestId");
        }
    }
}
