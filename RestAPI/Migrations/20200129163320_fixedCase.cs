using Microsoft.EntityFrameworkCore.Migrations;

namespace RestAPI.Migrations
{
    public partial class fixedCase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseItems_LocalUnions_UnionID",
                table: "CaseItems");

            migrationBuilder.DropIndex(
                name: "IX_CaseItems_UnionID",
                table: "CaseItems");

            migrationBuilder.AlterColumn<int>(
                name: "UnionID",
                table: "CaseItems",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UnionID",
                table: "CaseItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_CaseItems_UnionID",
                table: "CaseItems",
                column: "UnionID");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseItems_LocalUnions_UnionID",
                table: "CaseItems",
                column: "UnionID",
                principalTable: "LocalUnions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
