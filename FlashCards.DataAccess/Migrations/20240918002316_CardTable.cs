using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlashCards.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CardTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "Answer", "Question" },
                values: new object[] { 1, "2", "What is 1+1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
