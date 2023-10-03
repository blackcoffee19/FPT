using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ex2.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbPeople",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Role = table.Column<bool>(type: "bit", nullable: true),
                    Balence = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbPeople", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbPeople");
        }
    }
}
