using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication3.Migrations
{
    public partial class First111 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProcessOfTechnology",
                table: "ProcessOfTechnology");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProcessOfTechnology");

            migrationBuilder.AddColumn<int>(
                name: "PechId",
                table: "ProcessOfTechnology",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VariantId",
                table: "ProcessOfTechnology",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProcessOfTechnology",
                table: "ProcessOfTechnology",
                columns: new[] { "PechId", "VariantId" });

            migrationBuilder.CreateTable(
                name: "DanniePoFurmam",
                columns: table => new
                {
                    VariantId = table.Column<int>(nullable: false),
                    NFurm = table.Column<int>(nullable: false),
                    RashGazNaF = table.Column<int>(nullable: false),
                    RashVodiNaF = table.Column<int>(nullable: false),
                    Tperepad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanniePoFurmam", x => new { x.VariantId, x.NFurm });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DanniePoFurmam");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProcessOfTechnology",
                table: "ProcessOfTechnology");

            migrationBuilder.DropColumn(
                name: "PechId",
                table: "ProcessOfTechnology");

            migrationBuilder.DropColumn(
                name: "VariantId",
                table: "ProcessOfTechnology");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ProcessOfTechnology",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProcessOfTechnology",
                table: "ProcessOfTechnology",
                column: "Id");
        }
    }
}
