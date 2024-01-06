using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FluxoCaixa.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTable_TipoTransacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoTransacaoId",
                table: "Transacoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TipoTransacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTransacao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoTransacao", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transacoes_TipoTransacaoId",
                table: "Transacoes",
                column: "TipoTransacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transacoes_TipoTransacao_TipoTransacaoId",
                table: "Transacoes",
                column: "TipoTransacaoId",
                principalTable: "TipoTransacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transacoes_TipoTransacao_TipoTransacaoId",
                table: "Transacoes");

            migrationBuilder.DropTable(
                name: "TipoTransacao");

            migrationBuilder.DropIndex(
                name: "IX_Transacoes_TipoTransacaoId",
                table: "Transacoes");

            migrationBuilder.DropColumn(
                name: "TipoTransacaoId",
                table: "Transacoes");
        }
    }
}
