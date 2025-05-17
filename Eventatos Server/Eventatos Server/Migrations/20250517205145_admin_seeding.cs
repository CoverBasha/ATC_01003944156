using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eventatos_Server.Migrations
{
    /// <inheritdoc />
    public partial class admin_seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql(@"
        INSERT INTO Users (Name, Phone, Password)
        VALUES ('Admin User', '9999999999', 'admin123')
    ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
