using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendorManagmentApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ZipCode",
                table: "vendors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldMaxLength: 6);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "ZipCode",
                table: "vendors",
                type: "bigint",
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
