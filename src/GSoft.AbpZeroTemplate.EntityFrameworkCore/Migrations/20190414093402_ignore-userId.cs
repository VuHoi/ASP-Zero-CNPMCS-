using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class ignoreuserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_AbpUsers_UserId1",
                table: "Purchases");

            migrationBuilder.DropIndex(
                name: "IX_Purchases_UserId1",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Purchases");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "Purchases",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_UserId",
                table: "Purchases",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_AbpUsers_UserId",
                table: "Purchases",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_AbpUsers_UserId",
                table: "Purchases");

            migrationBuilder.DropIndex(
                name: "IX_Purchases_UserId",
                table: "Purchases");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Purchases",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserId1",
                table: "Purchases",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_UserId1",
                table: "Purchases",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_AbpUsers_UserId1",
                table: "Purchases",
                column: "UserId1",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
