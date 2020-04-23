using Microsoft.EntityFrameworkCore.Migrations;

namespace MatrimonialProject.Migrations
{
    public partial class migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Description_AspNetUsers_UserIdId",
                table: "Description");

            migrationBuilder.DropIndex(
                name: "IX_Description_UserIdId",
                table: "Description");

            migrationBuilder.RenameColumn(
                name: "UserIdId",
                table: "Description",
                newName: "UserId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Description",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Description",
                newName: "UserIdId");

            migrationBuilder.AlterColumn<string>(
                name: "UserIdId",
                table: "Description",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Description_UserIdId",
                table: "Description",
                column: "UserIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Description_AspNetUsers_UserIdId",
                table: "Description",
                column: "UserIdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
