using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymFeesManagement.Migrations
{
    /// <inheritdoc />
    public partial class Enrollment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entrollments_Programs_ProgramId",
                table: "Entrollments");

            migrationBuilder.DropIndex(
                name: "IX_Entrollments_ProgramId",
                table: "Entrollments");

            migrationBuilder.AddColumn<int>(
                name: "GymProgramId",
                table: "Entrollments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Entrollments_GymProgramId",
                table: "Entrollments",
                column: "GymProgramId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entrollments_Programs_GymProgramId",
                table: "Entrollments",
                column: "GymProgramId",
                principalTable: "Programs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entrollments_Programs_GymProgramId",
                table: "Entrollments");

            migrationBuilder.DropIndex(
                name: "IX_Entrollments_GymProgramId",
                table: "Entrollments");

            migrationBuilder.DropColumn(
                name: "GymProgramId",
                table: "Entrollments");

            migrationBuilder.CreateIndex(
                name: "IX_Entrollments_ProgramId",
                table: "Entrollments",
                column: "ProgramId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entrollments_Programs_ProgramId",
                table: "Entrollments",
                column: "ProgramId",
                principalTable: "Programs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
