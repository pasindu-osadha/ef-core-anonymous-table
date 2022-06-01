using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ef_core_anonymous_table.Migrations
{
    public partial class PriceUpdateView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@" create view PriceUpdateView as 
            select p.Id,p.Price
            from Products p");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"drop PriceUpdateView");
        }
    }
}
