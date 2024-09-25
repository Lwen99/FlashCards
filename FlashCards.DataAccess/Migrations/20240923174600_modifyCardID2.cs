using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlashCards.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class modifyCardID2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IadWeiShenMea",
                table: "Cards",
                newName: "CardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CardId",
                table: "Cards",
                newName: "IadWeiShenMea");
        }
    }
}
