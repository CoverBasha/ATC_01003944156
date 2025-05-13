using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eventatos_Server.Migrations
{
    /// <inheritdoc />
    public partial class seeding_roles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Roles (Name) VALUES ('User');");
            migrationBuilder.Sql("INSERT INTO Roles (Name) VALUES ('Admin');");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
