using Microsoft.EntityFrameworkCore.Migrations;

namespace H_R_WS.Migrations
{
    public partial class RoomFeatureRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemImageRelationships");
        }
    }
}
