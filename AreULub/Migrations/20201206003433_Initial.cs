using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AreULub.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentsUser = table.Column<string>(maxLength: 20, nullable: false),
                    CommentTitle = table.Column<string>(maxLength: 25, nullable: false),
                    CommentText = table.Column<string>(maxLength: 250, nullable: false),
                    CommentDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentsID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    UserLast = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ServiceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceName = table.Column<string>(maxLength: 50, nullable: false),
                    ServiceDescription = table.Column<string>(maxLength: 50, nullable: false),
                    ServiceEstimated = table.Column<string>(maxLength: 25, nullable: false),
                    ServicePrice = table.Column<decimal>(nullable: false),
                    UserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ServiceID);
                    table.ForeignKey(
                        name: "FK_Services_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "UserLast", "UserName" },
                values: new object[,]
                {
                    { "1", "FakeLast1", "Johnny" },
                    { "2", "FakeLast2", "Tommy" },
                    { "3", "FakeLast3", "Danny" },
                    { "4", "FakeLast4", "Mannly" },
                    { "5", "FakeLast5", "Conny" },
                    { "6", "FakeLast6", "Sunny" },
                    { "7", "FakeLast7", "Diandra" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceID", "ServiceDescription", "ServiceEstimated", "ServiceName", "ServicePrice", "UserID" },
                values: new object[] { 1, "Fast and using the best oil", "Around 30 minutes", "Oil Change", 80m, "1" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceID", "ServiceDescription", "ServiceEstimated", "ServiceName", "ServicePrice", "UserID" },
                values: new object[] { 2, "Reliable to get your car ready", "Around 1 hour", "General checkout", 140m, "5" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceID", "ServiceDescription", "ServiceEstimated", "ServiceName", "ServicePrice", "UserID" },
                values: new object[] { 3, "Quick and using Duracell", "Around 15 minutes", "Battery change", 120m, "7" });

            migrationBuilder.CreateIndex(
                name: "IX_Services_UserID",
                table: "Services",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
