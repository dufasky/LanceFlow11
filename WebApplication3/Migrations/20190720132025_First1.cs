using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication3.Migrations
{
    public partial class First1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProcessOfTechnology",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UdRashKoks = table.Column<int>(nullable: false),
                    RashDut = table.Column<int>(nullable: false),
                    DavlDut = table.Column<int>(nullable: false),
                    TDut = table.Column<int>(nullable: false),
                    VlazDut = table.Column<int>(nullable: false),
                    SodKislorod = table.Column<int>(nullable: false),
                    RashPrirGaz = table.Column<int>(nullable: false),
                    Proizv = table.Column<string>(nullable: true),
                    NrabFurm = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessOfTechnology", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProcessOfTechnology");
        }
    }
}
