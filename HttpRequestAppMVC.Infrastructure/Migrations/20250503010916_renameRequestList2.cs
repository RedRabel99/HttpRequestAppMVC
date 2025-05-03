using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HttpRequestAppMVC.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class renameRequestList2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HttpRequests_RequestLists_RequestListId",
                table: "HttpRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestLists",
                table: "RequestLists");

            migrationBuilder.RenameTable(
                name: "RequestLists",
                newName: "HttpRequestLists");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HttpRequestLists",
                table: "HttpRequestLists",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HttpRequests_HttpRequestLists_RequestListId",
                table: "HttpRequests",
                column: "RequestListId",
                principalTable: "HttpRequestLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HttpRequests_HttpRequestLists_RequestListId",
                table: "HttpRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HttpRequestLists",
                table: "HttpRequestLists");

            migrationBuilder.RenameTable(
                name: "HttpRequestLists",
                newName: "RequestLists");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestLists",
                table: "RequestLists",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HttpRequests_RequestLists_RequestListId",
                table: "HttpRequests",
                column: "RequestListId",
                principalTable: "RequestLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
