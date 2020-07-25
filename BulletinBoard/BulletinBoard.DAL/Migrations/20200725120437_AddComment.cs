using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BulletinBoard.DAL.Migrations
{
    public partial class AddComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Notices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Notices",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "Notices",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Notices",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "RecordImageType",
                table: "Notices",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Content = table.Column<string>(maxLength: 1000, nullable: false),
                    AuthorId = table.Column<int>(nullable: false),
                    NoticeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Notices_NoticeId",
                        column: x => x.NoticeId,
                        principalTable: "Notices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AuthorId",
                table: "Comments",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_NoticeId",
                table: "Comments",
                column: "NoticeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Notices");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Notices");

            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Notices");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Notices");

            migrationBuilder.DropColumn(
                name: "RecordImageType",
                table: "Notices");
        }
    }
}
