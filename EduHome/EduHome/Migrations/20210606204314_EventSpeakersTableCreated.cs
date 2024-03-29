﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHome.Migrations
{
    public partial class EventSpeakersTableCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Speakers_SpeakerId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_SpeakerId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "SpeakerId",
                table: "Events");

            migrationBuilder.CreateTable(
                name: "EventSpeaker",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(nullable: false),
                    SpeakerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventSpeaker", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventSpeaker_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventSpeaker_Speakers_SpeakerId",
                        column: x => x.SpeakerId,
                        principalTable: "Speakers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventSpeaker_EventId",
                table: "EventSpeaker",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventSpeaker_SpeakerId",
                table: "EventSpeaker",
                column: "SpeakerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventSpeaker");

            migrationBuilder.AddColumn<int>(
                name: "SpeakerId",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Events_SpeakerId",
                table: "Events",
                column: "SpeakerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Speakers_SpeakerId",
                table: "Events",
                column: "SpeakerId",
                principalTable: "Speakers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
