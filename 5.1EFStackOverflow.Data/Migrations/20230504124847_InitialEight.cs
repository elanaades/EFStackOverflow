using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _5._1EFStackOverflow.Data.Migrations
{
    public partial class InitialEight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionsTags_Users_UserId",
                table: "QuestionsTags");

            migrationBuilder.DropIndex(
                name: "IX_QuestionsTags_UserId",
                table: "QuestionsTags");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "QuestionsTags");

            migrationBuilder.RenameColumn(
                name: "DatePosted",
                table: "Questions",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "DatePosted",
                table: "Answers",
                newName: "Date");

            migrationBuilder.CreateTable(
                name: "QuestionLikes",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionLikes", x => new { x.QuestionId, x.UserId });
                    table.ForeignKey(
                        name: "FK_QuestionLikes_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuestionLikes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Questions_UserId",
                table: "Questions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionLikes_UserId",
                table: "QuestionLikes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Users_UserId",
                table: "Questions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Users_UserId",
                table: "Questions");

            migrationBuilder.DropTable(
                name: "QuestionLikes");

            migrationBuilder.DropIndex(
                name: "IX_Questions_UserId",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Questions",
                newName: "DatePosted");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Answers",
                newName: "DatePosted");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "QuestionsTags",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuestionsTags_UserId",
                table: "QuestionsTags",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionsTags_Users_UserId",
                table: "QuestionsTags",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
