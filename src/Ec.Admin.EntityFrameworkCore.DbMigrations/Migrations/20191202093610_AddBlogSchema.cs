using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ec.Admin.EntityFrameworkCore.DbMigrations.Migrations
{
    public partial class AddBlogSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EcBlog",
                columns: table => new
                {
                    BlogId = table.Column<Guid>(nullable: false),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EcBlog", x => x.BlogId);
                });

            migrationBuilder.CreateTable(
                name: "EcPost",
                columns: table => new
                {
                    PostId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    BlogId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EcPost", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_EcPost_EcBlog_BlogId",
                        column: x => x.BlogId,
                        principalTable: "EcBlog",
                        principalColumn: "BlogId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EcPost_BlogId",
                table: "EcPost",
                column: "BlogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EcPost");

            migrationBuilder.DropTable(
                name: "EcBlog");
        }
    }
}
