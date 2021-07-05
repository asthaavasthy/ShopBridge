using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopBridge.Migrations
{
    public partial class ShopBridgeHelperUserContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.CreateTable(
                name: "UserContext",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    RoleName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserContext", x => x.UserId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Item_UserId",
                schema: "dbo",
                table: "User",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_User_UserId",
                schema: "dbo",
                table: "Item",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_User_UserId",
                schema: "dbo",
                table: "Item");

            migrationBuilder.DropTable(
                name: "UserContext");

            migrationBuilder.DropIndex(
                name: "IX_Item_UserId",
                schema: "dbo",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "dbo",
                table: "Item");
        }
    }
}
