using Microsoft.EntityFrameworkCore.Migrations;

namespace MicroserviceSquare.Migrations
{
    public partial class chageKeySquareNotNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Squares_Delegations_DelegationId",
                table: "Squares");

            migrationBuilder.DropIndex(
                name: "IX_Squares_DelegationId",
                table: "Squares");

            migrationBuilder.AlterColumn<int>(
                name: "DelegationId",
                table: "Squares",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(6)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DelegationId1",
                table: "Squares",
                type: "nvarchar(6)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Squares_DelegationId1",
                table: "Squares",
                column: "DelegationId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Squares_Delegations_DelegationId1",
                table: "Squares",
                column: "DelegationId1",
                principalTable: "Delegations",
                principalColumn: "DelegationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Squares_Delegations_DelegationId1",
                table: "Squares");

            migrationBuilder.DropIndex(
                name: "IX_Squares_DelegationId1",
                table: "Squares");

            migrationBuilder.DropColumn(
                name: "DelegationId1",
                table: "Squares");

            migrationBuilder.AlterColumn<string>(
                name: "DelegationId",
                table: "Squares",
                type: "nvarchar(6)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Squares_DelegationId",
                table: "Squares",
                column: "DelegationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Squares_Delegations_DelegationId",
                table: "Squares",
                column: "DelegationId",
                principalTable: "Delegations",
                principalColumn: "DelegationId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
