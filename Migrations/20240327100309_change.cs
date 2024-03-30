using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloggingSite.Migrations
{
    /// <inheritdoc />
    public partial class change : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserSignupId",
                table: "comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_comments_UserSignupId",
                table: "comments",
                column: "UserSignupId");

            migrationBuilder.AddForeignKey(
                name: "FK_comments_userSignup_UserSignupId",
                table: "comments",
                column: "UserSignupId",
                principalTable: "userSignup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_userSignup_UserSignupId",
                table: "comments");

            migrationBuilder.DropIndex(
                name: "IX_comments_UserSignupId",
                table: "comments");

            migrationBuilder.DropColumn(
                name: "UserSignupId",
                table: "comments");
        }
    }
}
