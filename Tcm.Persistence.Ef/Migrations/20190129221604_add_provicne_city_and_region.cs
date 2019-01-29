using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System.IO;

namespace Tcm.Persistence.Ef.Migrations
{
    public partial class add_provicne_city_and_region : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            var functionPath = Path.Combine(@"../Tcm.Persistence.Ef/Scripts/971109-00-Create Function dbo.StringFarsi.sql");
            var provincePath = Path.Combine(@"../Tcm.Persistence.Ef/Scripts/971109-01-Add Provinces And cities.sql");
            var function = File.ReadAllText(functionPath);
            var province = File.ReadAllText(provincePath);
            migrationBuilder.Sql(function + " " + province);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION dbo.StringFarsi " +
                                 "GO " +
                                 "DELETE dbo.Regions " +
                                 "GO " +
                                 "DELETE dbo.Cities " +
                                 "GO " +
                                 "DELETE dbo.Provinces");
        }
    }
}
