using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parcels.Migrations
{
    public partial class AddSenderAssociationWithPackage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SenderId",
                table: "Packages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Packages_SenderId",
                table: "Packages",
                column: "SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Senders_SenderId",
                table: "Packages",
                column: "SenderId",
                principalTable: "Senders",
                principalColumn: "SenderId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Senders_SenderId",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_SenderId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "SenderId",
                table: "Packages");
        }
    }
}
