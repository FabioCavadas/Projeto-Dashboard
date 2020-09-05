using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using Projeto.Infra.Data.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Presentation.MVC.Reports.Pdf
{
    public class ContaReportPdf
    {
        public static byte[] GenerateReport(List<Conta> contas)
        {
            MemoryStream ms = new MemoryStream();
            var pdf = new PdfDocument(new PdfWriter(ms));

            using (var doc = new Document(pdf))
            {
                var titulo = "Relatório de Contas - C# WebDeveloper";
                var subtitulo = "Data de geração: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm");

                doc.Add(new Paragraph(titulo));
                doc.Add(new Paragraph(subtitulo));

                var table = new Table(6); //6 colunas

                table.AddHeaderCell("Nome da Conta");
                table.AddHeaderCell("Data");
                table.AddHeaderCell("Valor");
                table.AddHeaderCell("Tipo");
                table.AddHeaderCell("Categoria");
                table.AddHeaderCell("Forma de Pagamento");

                foreach (var item in contas)
                {
                    table.AddCell(item.NomeConta);
                    table.AddCell(item.DataConta.ToString("dd/MM/yyyy"));
                    table.AddCell(item.ValorConta.ToString("c"));
                    table.AddCell(item.Tipo.ToString());
                    table.AddCell(item.Categoria.ToString());
                    table.AddCell(item.FormaDePagamento.ToString());
                }

                doc.Add(table);
            }

            return ms.ToArray();
        }
    }
}
