using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FluxoCaixa.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transacoes_TipoTransacao_TipoTransacaoId",
                table: "Transacoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoTransacao",
                table: "TipoTransacao");

            migrationBuilder.RenameTable(
                name: "TipoTransacao",
                newName: "TipoTransacoes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoTransacoes",
                table: "TipoTransacoes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transacoes_TipoTransacoes_TipoTransacaoId",
                table: "Transacoes",
                column: "TipoTransacaoId",
                principalTable: "TipoTransacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transacoes_TipoTransacoes_TipoTransacaoId",
                table: "Transacoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoTransacoes",
                table: "TipoTransacoes");

            migrationBuilder.RenameTable(
                name: "TipoTransacoes",
                newName: "TipoTransacao");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoTransacao",
                table: "TipoTransacao",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transacoes_TipoTransacao_TipoTransacaoId",
                table: "Transacoes",
                column: "TipoTransacaoId",
                principalTable: "TipoTransacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
