using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eventatos_Server.Migrations
{
    /// <inheritdoc />
    public partial class seeding_database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
        INSERT INTO Events (Name, Description, Date, Venue, Price, Tickets, ImageURL)
        VALUES 
        ('Tech Expo 2025', 'A major technology exhibition with industry leaders.', '2025-06-10', 'Expo Center', 50, 100, 'https://via.placeholder.com/200'),
        ('AI Bootcamp', 'A hands-on workshop on AI tools and frameworks.', '2025-07-01', 'Innovation Hub', 30, 60, 'https://via.placeholder.com/200'),
        ('Web Dev Summit', 'A gathering of web developers sharing knowledge and tools.', '2025-08-15', 'Online', 20, 80, 'https://via.placeholder.com/200')
    ");


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
