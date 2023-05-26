using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClubView.API.Migrations
{
    /// <inheritdoc />
    public partial class NamingUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MemberClubs_ClubMembers_MemberId",
                table: "MemberClubs");

            migrationBuilder.DropForeignKey(
                name: "FK_MemberClubs_Clubs_ClubId",
                table: "MemberClubs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Whiskeys",
                table: "Whiskeys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MemberClubs",
                table: "MemberClubs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clubs",
                table: "Clubs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClubMembers",
                table: "ClubMembers");

            migrationBuilder.RenameTable(
                name: "Whiskeys",
                newName: "Whiskey");

            migrationBuilder.RenameTable(
                name: "MemberClubs",
                newName: "MemberClub");

            migrationBuilder.RenameTable(
                name: "Clubs",
                newName: "Club");

            migrationBuilder.RenameTable(
                name: "ClubMembers",
                newName: "ClubMember");

            migrationBuilder.RenameIndex(
                name: "IX_MemberClubs_ClubId",
                table: "MemberClub",
                newName: "IX_MemberClub_ClubId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Whiskey",
                table: "Whiskey",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MemberClub",
                table: "MemberClub",
                columns: new[] { "MemberId", "ClubId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Club",
                table: "Club",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClubMember",
                table: "ClubMember",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MemberClub_ClubMember_MemberId",
                table: "MemberClub",
                column: "MemberId",
                principalTable: "ClubMember",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MemberClub_Club_ClubId",
                table: "MemberClub",
                column: "ClubId",
                principalTable: "Club",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MemberClub_ClubMember_MemberId",
                table: "MemberClub");

            migrationBuilder.DropForeignKey(
                name: "FK_MemberClub_Club_ClubId",
                table: "MemberClub");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Whiskey",
                table: "Whiskey");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MemberClub",
                table: "MemberClub");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClubMember",
                table: "ClubMember");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Club",
                table: "Club");

            migrationBuilder.RenameTable(
                name: "Whiskey",
                newName: "Whiskeys");

            migrationBuilder.RenameTable(
                name: "MemberClub",
                newName: "MemberClubs");

            migrationBuilder.RenameTable(
                name: "ClubMember",
                newName: "ClubMembers");

            migrationBuilder.RenameTable(
                name: "Club",
                newName: "Clubs");

            migrationBuilder.RenameIndex(
                name: "IX_MemberClub_ClubId",
                table: "MemberClubs",
                newName: "IX_MemberClubs_ClubId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Whiskeys",
                table: "Whiskeys",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MemberClubs",
                table: "MemberClubs",
                columns: new[] { "MemberId", "ClubId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClubMembers",
                table: "ClubMembers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clubs",
                table: "Clubs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MemberClubs_ClubMembers_MemberId",
                table: "MemberClubs",
                column: "MemberId",
                principalTable: "ClubMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MemberClubs_Clubs_ClubId",
                table: "MemberClubs",
                column: "ClubId",
                principalTable: "Clubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
