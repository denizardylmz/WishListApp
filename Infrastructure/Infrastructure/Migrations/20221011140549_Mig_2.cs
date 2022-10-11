using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class Mig_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_WishLists_WishListId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_WishLists_AspNetRoles_AppRoleId",
                table: "WishLists");

            migrationBuilder.DropIndex(
                name: "IX_WishLists_AppRoleId",
                table: "WishLists");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_WishListId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AppRoleId",
                table: "WishLists");

            migrationBuilder.DropColumn(
                name: "WishListId",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "AppUserWishList",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    WishListsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserWishList", x => new { x.UserId, x.WishListsId });
                    table.ForeignKey(
                        name: "FK_AppUserWishList_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserWishList_WishLists_WishListsId",
                        column: x => x.WishListsId,
                        principalTable: "WishLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserWishList_WishListsId",
                table: "AppUserWishList",
                column: "WishListsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserWishList");

            migrationBuilder.AddColumn<int>(
                name: "AppRoleId",
                table: "WishLists",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WishListId",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WishLists_AppRoleId",
                table: "WishLists",
                column: "AppRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_WishListId",
                table: "AspNetUsers",
                column: "WishListId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_WishLists_WishListId",
                table: "AspNetUsers",
                column: "WishListId",
                principalTable: "WishLists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WishLists_AspNetRoles_AppRoleId",
                table: "WishLists",
                column: "AppRoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id");
        }
    }
}
