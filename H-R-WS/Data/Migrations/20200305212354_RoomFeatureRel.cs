using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace H_R_WS.Data.Migrations
{
    public partial class RoomFeatureRel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Features_Rooms_RoomID",
                table: "Features");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_RoomTypes_RoomTypeID",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_RoomTypeID",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Features_RoomID",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "RoomID",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "RoomTypeID",
                table: "Rooms",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "RoomTypeID1",
                table: "Rooms",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RoomFeatureRelationships",
                columns: table => new
                {
                    RoomID = table.Column<string>(nullable: false),
                    FeatureID = table.Column<string>(nullable: false),
                    RoomID1 = table.Column<Guid>(nullable: true),
                    FeatureID1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomFeatureRelationships", x => new { x.RoomID, x.FeatureID });
                    table.ForeignKey(
                        name: "FK_RoomFeatureRelationships_Features_FeatureID1",
                        column: x => x.FeatureID1,
                        principalTable: "Features",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoomFeatureRelationships_Rooms_RoomID1",
                        column: x => x.RoomID1,
                        principalTable: "Rooms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomTypeID1",
                table: "Rooms",
                column: "RoomTypeID1");

            migrationBuilder.CreateIndex(
                name: "IX_RoomFeatureRelationships_FeatureID1",
                table: "RoomFeatureRelationships",
                column: "FeatureID1");

            migrationBuilder.CreateIndex(
                name: "IX_RoomFeatureRelationships_RoomID1",
                table: "RoomFeatureRelationships",
                column: "RoomID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_RoomTypes_RoomTypeID1",
                table: "Rooms",
                column: "RoomTypeID1",
                principalTable: "RoomTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_RoomTypes_RoomTypeID1",
                table: "Rooms");

            migrationBuilder.DropTable(
                name: "RoomFeatureRelationships");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_RoomTypeID1",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "RoomTypeID1",
                table: "Rooms");

            migrationBuilder.AlterColumn<Guid>(
                name: "RoomTypeID",
                table: "Rooms",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RoomID",
                table: "Features",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomTypeID",
                table: "Rooms",
                column: "RoomTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Features_RoomID",
                table: "Features",
                column: "RoomID");

            migrationBuilder.AddForeignKey(
                name: "FK_Features_Rooms_RoomID",
                table: "Features",
                column: "RoomID",
                principalTable: "Rooms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_RoomTypes_RoomTypeID",
                table: "Rooms",
                column: "RoomTypeID",
                principalTable: "RoomTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
