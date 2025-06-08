using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mission.Entities.Migrations
{
    /// <inheritdoc />
    public partial class addskills : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MissionSkills",
                table: "MissionSkills");

            migrationBuilder.RenameTable(
                name: "MissionSkills",
                newName: "MissionSkill");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MissionSkill",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MissionSkill",
                table: "MissionSkill",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MissionSkill",
                table: "MissionSkill");

            migrationBuilder.RenameTable(
                name: "MissionSkill",
                newName: "MissionSkills");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MissionSkill");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MissionSkills",
                table: "MissionSkills",
                column: "Id");
        }
    }
}
