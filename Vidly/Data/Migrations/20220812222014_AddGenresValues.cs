using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vidly.Data.Migrations
{
    public partial class AddGenresValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Genre (Id, Name) VALUES" +
                "(1, 'Comedy'), (2, 'Action'), (3, 'Family'), (4, 'Romance')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
