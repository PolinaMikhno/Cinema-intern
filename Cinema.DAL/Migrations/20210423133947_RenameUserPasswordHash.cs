using Microsoft.EntityFrameworkCore.Migrations;

namespace Cinema.DAL.Migrations
{
    public partial class RenameUserPasswordHash : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalServices_Sessions_SessionId",
                table: "AdditionalServices");

            migrationBuilder.DropForeignKey(
                name: "FK_Halls_Theaters_TheaterId",
                table: "Halls");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Films_FilmId",
                table: "Sessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Halls_HallId",
                table: "Sessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Theaters_TheaterId",
                table: "Sessions");

            migrationBuilder.DropForeignKey(
                name: "FK_SittingPlaces_Halls_HallId",
                table: "SittingPlaces");

            migrationBuilder.DropForeignKey(
                name: "FK_SittingPlaces_Tickets_TicketId",
                table: "SittingPlaces");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Sessions_SessionId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "PasswordHash");

            migrationBuilder.RenameColumn(
                name: "SessionId",
                table: "Tickets",
                newName: "SessionEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_SessionId",
                table: "Tickets",
                newName: "IX_Tickets_SessionEntityId");

            migrationBuilder.RenameColumn(
                name: "TicketId",
                table: "SittingPlaces",
                newName: "TicketEntityId");

            migrationBuilder.RenameColumn(
                name: "HallId",
                table: "SittingPlaces",
                newName: "HallEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_SittingPlaces_TicketId",
                table: "SittingPlaces",
                newName: "IX_SittingPlaces_TicketEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_SittingPlaces_HallId",
                table: "SittingPlaces",
                newName: "IX_SittingPlaces_HallEntityId");

            migrationBuilder.RenameColumn(
                name: "TheaterId",
                table: "Sessions",
                newName: "TheaterEntityId");

            migrationBuilder.RenameColumn(
                name: "HallId",
                table: "Sessions",
                newName: "HallEntityId");

            migrationBuilder.RenameColumn(
                name: "FilmId",
                table: "Sessions",
                newName: "FilmEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Sessions_TheaterId",
                table: "Sessions",
                newName: "IX_Sessions_TheaterEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Sessions_HallId",
                table: "Sessions",
                newName: "IX_Sessions_HallEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Sessions_FilmId",
                table: "Sessions",
                newName: "IX_Sessions_FilmEntityId");

            migrationBuilder.RenameColumn(
                name: "TheaterId",
                table: "Halls",
                newName: "TheaterEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Halls_TheaterId",
                table: "Halls",
                newName: "IX_Halls_TheaterEntityId");

            migrationBuilder.RenameColumn(
                name: "SessionId",
                table: "AdditionalServices",
                newName: "SessionEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_AdditionalServices_SessionId",
                table: "AdditionalServices",
                newName: "IX_AdditionalServices_SessionEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalServices_Sessions_SessionEntityId",
                table: "AdditionalServices",
                column: "SessionEntityId",
                principalTable: "Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Halls_Theaters_TheaterEntityId",
                table: "Halls",
                column: "TheaterEntityId",
                principalTable: "Theaters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Films_FilmEntityId",
                table: "Sessions",
                column: "FilmEntityId",
                principalTable: "Films",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Halls_HallEntityId",
                table: "Sessions",
                column: "HallEntityId",
                principalTable: "Halls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Theaters_TheaterEntityId",
                table: "Sessions",
                column: "TheaterEntityId",
                principalTable: "Theaters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SittingPlaces_Halls_HallEntityId",
                table: "SittingPlaces",
                column: "HallEntityId",
                principalTable: "Halls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SittingPlaces_Tickets_TicketEntityId",
                table: "SittingPlaces",
                column: "TicketEntityId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Sessions_SessionEntityId",
                table: "Tickets",
                column: "SessionEntityId",
                principalTable: "Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalServices_Sessions_SessionEntityId",
                table: "AdditionalServices");

            migrationBuilder.DropForeignKey(
                name: "FK_Halls_Theaters_TheaterEntityId",
                table: "Halls");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Films_FilmEntityId",
                table: "Sessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Halls_HallEntityId",
                table: "Sessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Theaters_TheaterEntityId",
                table: "Sessions");

            migrationBuilder.DropForeignKey(
                name: "FK_SittingPlaces_Halls_HallEntityId",
                table: "SittingPlaces");

            migrationBuilder.DropForeignKey(
                name: "FK_SittingPlaces_Tickets_TicketEntityId",
                table: "SittingPlaces");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Sessions_SessionEntityId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "SessionEntityId",
                table: "Tickets",
                newName: "SessionId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_SessionEntityId",
                table: "Tickets",
                newName: "IX_Tickets_SessionId");

            migrationBuilder.RenameColumn(
                name: "TicketEntityId",
                table: "SittingPlaces",
                newName: "TicketId");

            migrationBuilder.RenameColumn(
                name: "HallEntityId",
                table: "SittingPlaces",
                newName: "HallId");

            migrationBuilder.RenameIndex(
                name: "IX_SittingPlaces_TicketEntityId",
                table: "SittingPlaces",
                newName: "IX_SittingPlaces_TicketId");

            migrationBuilder.RenameIndex(
                name: "IX_SittingPlaces_HallEntityId",
                table: "SittingPlaces",
                newName: "IX_SittingPlaces_HallId");

            migrationBuilder.RenameColumn(
                name: "TheaterEntityId",
                table: "Sessions",
                newName: "TheaterId");

            migrationBuilder.RenameColumn(
                name: "HallEntityId",
                table: "Sessions",
                newName: "HallId");

            migrationBuilder.RenameColumn(
                name: "FilmEntityId",
                table: "Sessions",
                newName: "FilmId");

            migrationBuilder.RenameIndex(
                name: "IX_Sessions_TheaterEntityId",
                table: "Sessions",
                newName: "IX_Sessions_TheaterId");

            migrationBuilder.RenameIndex(
                name: "IX_Sessions_HallEntityId",
                table: "Sessions",
                newName: "IX_Sessions_HallId");

            migrationBuilder.RenameIndex(
                name: "IX_Sessions_FilmEntityId",
                table: "Sessions",
                newName: "IX_Sessions_FilmId");

            migrationBuilder.RenameColumn(
                name: "TheaterEntityId",
                table: "Halls",
                newName: "TheaterId");

            migrationBuilder.RenameIndex(
                name: "IX_Halls_TheaterEntityId",
                table: "Halls",
                newName: "IX_Halls_TheaterId");

            migrationBuilder.RenameColumn(
                name: "SessionEntityId",
                table: "AdditionalServices",
                newName: "SessionId");

            migrationBuilder.RenameIndex(
                name: "IX_AdditionalServices_SessionEntityId",
                table: "AdditionalServices",
                newName: "IX_AdditionalServices_SessionId");

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
                name: "FK_Sessions_Films_FilmId",
                table: "Sessions",
                column: "FilmId",
                principalTable: "Films",
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
                name: "FK_Sessions_Theaters_TheaterId",
                table: "Sessions",
                column: "TheaterId",
                principalTable: "Theaters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SittingPlaces_Halls_HallId",
                table: "SittingPlaces",
                column: "HallId",
                principalTable: "Halls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SittingPlaces_Tickets_TicketId",
                table: "SittingPlaces",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Sessions_SessionId",
                table: "Tickets",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
