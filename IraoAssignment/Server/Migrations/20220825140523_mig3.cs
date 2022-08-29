using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IraoAssignment.Server.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CompanyPrice",
                table: "MarketWithCompanyAndPrices",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "CompanyPrice",
                table: "MarketWithCompanyAndPrices",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
