using EvoPdf;
using FluxoCaixa.Application.Interfaces;
using FluxoCaixa.Data.Interfaces;
using FluxoCaixa.Domain.Entities;
using FluxoCaixa.Domain.Input;
using FluxoCaixa.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System.IO;
using System.Text;

namespace FluxoCaixa.Application.Applications
{
    public class TransacaoApplication : ITransacaoApplication
    {
        private readonly ITransacaoRepository _transacaoRepository;
        private readonly IContaApplication _contaApplication;
        private readonly IRabbitMQService _rabbitMQService;

        public TransacaoApplication(ITransacaoRepository transacaoRepository, IContaApplication contaApplication, IRabbitMQService rabbitMQService)
        {
            _transacaoRepository = transacaoRepository;
            _contaApplication = contaApplication;
            _rabbitMQService = rabbitMQService;
        }

        public async Task<ActionResult<Transacao>> Add(Transacao entity)
        {
            //Regras:
            //Criar uma Transação
            entity.SetCreateAtDate();
            var retornoTransacao = await _transacaoRepository.Add(entity);

            //Atualizar o saldo da conta.
            await _contaApplication.AtualizaSaldo(entity.ContaId, entity.Valor);

            //Ao finalizar enviar mensagem RabbitMQ com retornoTransacao
            _rabbitMQService.PublicarMensagem(JsonConvert.SerializeObject(retornoTransacao));

            return retornoTransacao;
        }

        public async Task<ActionResult<IEnumerable<Transacao>>> GetAll()
        {
            var transacoes = await _transacaoRepository.GetAll();

            return transacoes.ToList();
        }

        public async Task<ActionResult<Transacao>> GetById(Guid id)
        {
            return await _transacaoRepository.GetById(id);
        }

        public async Task<ActionResult<IEnumerable<Transacao>>> GetFilter(Guid? contaId, Guid? tipoTransacaoId, DateTime? createAt)
        {
            var filter = new TransacaoFilter()
            {
                ContaId = contaId,
                TipoTransacaoId = tipoTransacaoId,
                CreateAt = createAt
            };

            var transacoes = await _transacaoRepository.GetFilter(filter);

            return transacoes.ToList();

        }

        public async Task Remove(Guid id)
        {
            var transacao = await _transacaoRepository.GetById(id);

            transacao.SetRemoveAtDate();

            await _transacaoRepository.Update(transacao);
        }

        public async Task<ActionResult<Transacao>> Update(Transacao entity)
        {
            Transacao transacaoUpdated = new();

            var transacao = await _transacaoRepository.GetById(entity.Id);

            if (transacao != null)
            {
                transacao.Valor = entity.Valor;
                transacao.SetRemoveAtDate();

                transacaoUpdated = await _transacaoRepository.Update(transacao);
            }

            return transacaoUpdated;


        }

        public async Task<byte[]> GetStatement(Guid? contaId, Guid? tipoTransacaoId, DateTime? createAt)
        {
            var filter = new TransacaoFilter()
            {
                ContaId = contaId,
                TipoTransacaoId = tipoTransacaoId,
                CreateAt = createAt
            };

            var transacoes = await _transacaoRepository.GetFilter(filter);

            HtmlToPdfConverter converter = new();

            byte[] htmlToPdfBuffer = converter.ConvertHtml(await BuildHtmlTable(transacoes), null);

            return htmlToPdfBuffer;
        }

        public async Task<string> BuildHtmlTable(IEnumerable<Transacao> transacoes)
        {
            StringBuilder sb = new();
            sb.AppendLine("<!DOCTYPE html>");

            sb.AppendLine("<html>");
            sb.AppendLine("<head>");


            //Css
            sb.AppendLine(
                "<style>" +
                    "table {" +
                        "font-family: arial, sans-serif;" +
                        "border-collapse: collapse;" +
                        "width: 100%;" +
                        "}" +
                    "td, th {" +
                        "border: 1px solid #dddddd;" +
                        "text-align: left;" +
                        "padding: 8px;" +
                        "}" +
                    "tr:nth-child(even) {" +
                        "background-color: #dddddd;" +
                        "}" +
                "</style>");

            sb.AppendLine("</head>");

            sb.AppendLine("<body>");

            sb.AppendLine("<h4>");
            sb.AppendLine("Extrato Consolidado " + transacoes.Min(x=> x.CreateAt!.Value.Date.ToString("d")) + " Até " + transacoes.Max(x => x.CreateAt!.Value.Date.ToString("d")));
            sb.AppendLine("<h4>");

            //Table Begin
            sb.AppendLine("<table>");
            sb.AppendLine("<tr>");

            //Columns
            sb.AppendLine("<th>Cliente</th>");
            sb.AppendLine("<th>Tipo de Transação</th>");
            sb.AppendLine("<th>Descrição</th>");
            sb.AppendLine("<th>Valor</th>");
            sb.AppendLine("<th>Data Transação</th>");

            sb.AppendLine("</tr>");


            //Rows
            foreach (var transacao in transacoes)
            {
                sb.Append("<tr>");
                sb.Append("<td>");
                sb.Append(transacao.Conta.Nome);

                sb.Append("<td>");
                sb.Append(transacao.TipoTransacao.Descricao);
                sb.Append("</td>");

                sb.Append("<td>");
                sb.Append(transacao.Descricao);
                sb.Append("</td>");

                sb.Append("<td>");
                sb.Append(transacao.Valor.ToString());
                sb.Append("</td>");

                sb.Append("<td>");
                sb.Append(transacao.CreateAt.ToString());
                sb.Append("</td>");

                sb.Append("</tr>");
            }


            sb.AppendLine("</table>");
            sb.AppendLine("</body>");
            sb.AppendLine("</html>");

            return sb.ToString();
        }
    }
}
