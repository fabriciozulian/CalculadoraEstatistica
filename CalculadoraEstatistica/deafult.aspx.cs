using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace CalculadoraEstatistica
{
    public partial class deafult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Verifica se o cookie existe
                HttpCookie ArmazenamentoNumero = Request.Cookies["ListaNumero"];
                if (ArmazenamentoNumero == null)
                {
                    // Se o cookie não existe, cria um novo
                    ArmazenamentoNumero = new HttpCookie("ListaNumero");
                    ArmazenamentoNumero.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(ArmazenamentoNumero);
                }
                else
                {
                    exibir.Text = ArmazenamentoNumero.Value.Replace(",", ", ").TrimEnd(", ".ToCharArray());
                }
            }
        }

        protected void limpar_Click(object sender, EventArgs e)
        {
            // Obtém o cookie da requisição
            HttpCookie ArmazenamentoNumero = Request.Cookies["ListaNumero"];
            if (ArmazenamentoNumero != null)
            {
                // Limpa o valor do cookie
                ArmazenamentoNumero.Value = string.Empty;
                // Atualiza o cookie na resposta
                Response.Cookies.Set(ArmazenamentoNumero);
                exibir.Text = "Nenhum número adicionado";
                LimparResultados();
            }
        }

        protected void enviar_Click(object sender, EventArgs e)
        {
            // Obtém o cookie da requisição
            HttpCookie ArmazenamentoNumero = Request.Cookies["ListaNumero"];
            if (ArmazenamentoNumero == null)
            {
                // Se o cookie não existe, cria um novo
                ArmazenamentoNumero = new HttpCookie("ListaNumero");
                ArmazenamentoNumero.Expires = DateTime.Now.AddDays(1);
            }

            // Adiciona o novo número ao valor do cookie
            ArmazenamentoNumero.Value += numero.Text + ",";
            // Atualiza o cookie na resposta
            Response.Cookies.Set(ArmazenamentoNumero);
            // Limpa a caixa de texto e exibe o valor do cookie
            numero.Text = "";
            exibir.Text = ArmazenamentoNumero.Value.Replace(",", ", ").TrimEnd(", ".ToCharArray());
        }

        protected void calcular_Click(object sender, EventArgs e)
        {
            // Obtém o cookie da requisição
            HttpCookie ArmazenamentoNumero = Request.Cookies["ListaNumero"];
            if (ArmazenamentoNumero != null && !string.IsNullOrEmpty(ArmazenamentoNumero.Value))
            {
                // Converte os valores do cookie para uma lista de números
                List<double> numeros = ArmazenamentoNumero.Value
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(n => double.Parse(n.Trim()))
                    .ToList();

                if (numeros.Count > 0)
                {
                    media.Text = CalcularMedia(numeros).ToString("N2");
                    mediana.Text = CalcularMediana(numeros).ToString("N2");
                    var modas = CalcularModa(numeros);
                    moda.Text = modas.Count > 0 ? string.Join(" | ", modas.Select(x => x.ToString("N2")).ToArray()) : "Nenhuma moda";
                }
            }
        }

        private void LimparResultados()
        {
            media.Text = "-";
            mediana.Text = "-";
            moda.Text = "-";
        }

        private double CalcularMedia(List<double> numeros)
        {
            return numeros.Average();
        }

        private double CalcularMediana(List<double> numeros)
        {
            var sortedNumbers = numeros.OrderBy(n => n).ToList();
            int count = sortedNumbers.Count;
            if (count % 2 == 0)
            {
                return (sortedNumbers[count / 2 - 1] + sortedNumbers[count / 2]) / 2;
            }
            else
            {
                return sortedNumbers[count / 2];
            }
        }

        private List<double> CalcularModa(List<double> numeros)
        {
            var numberGroups = numeros.GroupBy(n => n)
                                      .Select(g => new { Number = g.Key, Count = g.Count() })
                                      .OrderByDescending(g => g.Count)
                                      .ToList();

            int maxCount = numberGroups.First().Count;
            if (maxCount == 1)
            {
                // Se todos os números aparecem apenas uma vez, não há moda.
                return new List<double>();
            }

            return numberGroups.Where(g => g.Count == maxCount).Select(g => g.Number).ToList();
        }
    }
}
