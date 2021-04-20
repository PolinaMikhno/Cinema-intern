using Microsoft.EntityFrameworkCore.Migrations;

namespace Cinema.DAL.Migrations
{
    public partial class RenameTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalService_Sessions_SessionId",
                table: "AdditionalService");

            migrationBuilder.DropForeignKey(
                name: "FK_Hall_Theaters_TheaterId",
                table: "Hall");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Hall_HallId",
                table: "Sessions");

            migrationBuilder.DropForeignKey(
                name: "FK_SittingPlace_Hall_HallId",
                table: "SittingPlace");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SittingPlace",
                table: "SittingPlace");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hall",
                table: "Hall");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdditionalService",
                table: "AdditionalService");

            migrationBuilder.RenameTable(
                name: "SittingPlace",
                newName: "SittingPlaces");

            migrationBuilder.RenameTable(
                name: "Hall",
                newName: "Halls");

            migrationBuilder.RenameTable(
                name: "AdditionalService",
                newName: "AdditionalServices");

            migrationBuilder.RenameIndex(
                name: "IX_SittingPlace_HallId",
                table: "SittingPlaces",
                newName: "IX_SittingPlaces_HallId");

            migrationBuilder.RenameIndex(
                name: "IX_Hall_TheaterId",
                table: "Halls",
                newName: "IX_Halls_TheaterId");

            migrationBuilder.RenameIndex(
                name: "IX_AdditionalService_SessionId",
                table: "AdditionalServices",
                newName: "IX_AdditionalServices_SessionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SittingPlaces",
                table: "SittingPlaces",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Halls",
                table: "Halls",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdditionalServices",
                table: "AdditionalServices",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalServices_Sessions_SessionId",
                table: "AdditionalServices",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Halls_Theaters_TheaterId",
                table: "Halls",
                column: "TheaterId",
                principalTable: "Theaters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Halls_HallId",
                table: "Sessions",
                column: "HallId",
                principalTable: "Halls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SittingPlaces_Halls_HallId",
                table: "SittingPlaces",
                column: "HallId",
                principalTable: "Halls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalServices_Sessions_SessionId",
                table: "AdditionalServices");

            migrationBuilder.DropForeignKey(
                name: "FK_Halls_Theaters_TheaterId",
                table: "Halls");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Halls_HallId",
                table: "Sessions");

            migrationBuilder.DropForeignKey(
                name: "FK_SittingPlaces_Halls_HallId",
                table: "SittingPlaces");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SittingPlaces",
                table: "SittingPlaces");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Halls",
                table: "Halls");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdditionalServices",
                table: "AdditionalServices");

            migrationBuilder.RenameTable(
                name: "SittingPlaces",
                newName: "SittingPlace");

            migrationBuilder.RenameTable(
                name: "Halls",
                newName: "Hall");

            migrationBuilder.RenameTable(
                name: "AdditionalServices",
                newName: "AdditionalService");

            migrationBuilder.RenameIndex(
                name: "IX_SittingPlaces_HallId",
                table: "SittingPlace",
                newName: "IX_SittingPlace_HallId");

            migrationBuilder.RenameIndex(
                name: "IX_Halls_TheaterId",
                table: "Hall",
                newName: "IX_Hall_TheaterId");

            migrationBuilder.RenameIndex(
                name: "IX_AdditionalServices_SessionId",
                table: "AdditionalService",
                newName: "IX_AdditionalService_SessionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SittingPlace",
                table: "SittingPlace",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hall",
                table: "Hall",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdditionalService",
                table: "AdditionalService",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalService_Sessions_SessionId",
                table: "AdditionalService",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Hall_Theaters_TheaterId",
                table: "Hall",
                column: "TheaterId",
                principalTable: "Theaters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Hall_HallId",
                table: "Sessions",
                column: "HallId",
                principalTable: "Hall",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SittingPlace_Hall_HallId",
                table: "SittingPlace",
                column: "HallId",
                principalTable: "Hall",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
