using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Timon.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddMoneyRecordType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "MoneyRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "MoneyRecords");
        }
    }
}
