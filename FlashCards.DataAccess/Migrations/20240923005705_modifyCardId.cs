using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlashCards.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class modifyCardId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cards",
                newName: "IadWeiShenMea");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IadWeiShenMea",
                table: "Cards",
                newName: "Id");
        }
    }
}
