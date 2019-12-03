using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ec.Admin.EntityFrameworkCore.DbMigrations.Migrations
{
    public partial class AddUserSchemal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EcPost_EcBlog_BlogId",
                table: "EcPost");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EcPost",
                table: "EcPost");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EcBlog",
                table: "EcBlog");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "EcPost");

            migrationBuilder.DropColumn(
                name: "BlogId",
                table: "EcBlog");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "EcPost",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "EcPost",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtraProperties",
                table: "EcPost",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "EcBlog",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "EcBlog",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtraProperties",
                table: "EcBlog",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EcPost",
                table: "EcPost",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EcBlog",
                table: "EcBlog",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "EcRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EcRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EcUserInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EcUserInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EcUserInfo_EcRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "EcRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EcUserInfo_RoleId",
                table: "EcUserInfo",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_EcPost_EcBlog_BlogId",
                table: "EcPost",
                column: "BlogId",
                principalTable: "EcBlog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EcPost_EcBlog_BlogId",
                table: "EcPost");

            migrationBuilder.DropTable(
                name: "EcUserInfo");

            migrationBuilder.DropTable(
                name: "EcRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EcPost",
                table: "EcPost");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EcBlog",
                table: "EcBlog");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EcPost");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "EcPost");

            migrationBuilder.DropColumn(
                name: "ExtraProperties",
                table: "EcPost");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EcBlog");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "EcBlog");

            migrationBuilder.DropColumn(
                name: "ExtraProperties",
                table: "EcBlog");

            migrationBuilder.AddColumn<Guid>(
                name: "PostId",
                table: "EcPost",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "BlogId",
                table: "EcBlog",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_EcPost",
                table: "EcPost",
                column: "PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EcBlog",
                table: "EcBlog",
                column: "BlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_EcPost_EcBlog_BlogId",
                table: "EcPost",
                column: "BlogId",
                principalTable: "EcBlog",
                principalColumn: "BlogId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
