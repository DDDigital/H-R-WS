using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace H_R_WS.Data.Migrations
{
    public partial class RoomFeatureRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Features_Rooms_RoomID",
                table: "Features");

            migrationBuilder.DropIndex(
                name: "IX_Features_RoomID",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "RoomID",
                table: "Features");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

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
                name: "IX_RoomFeatureRelationships_FeatureID1",
                table: "RoomFeatureRelationships",
                column: "FeatureID1");

            migrationBuilder.CreateIndex(
                name: "IX_RoomFeatureRelationships_RoomID1",
                table: "RoomFeatureRelationships",
                column: "RoomID1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomFeatureRelationships");

            migrationBuilder.AddColumn<Guid>(
                name: "RoomID",
                table: "Features",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

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
        }
    }
}
