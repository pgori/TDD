using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao
{
    public class Avaliador
    {
        private double maiorDeTodos = Double.MinValue;
        private double menorDeTodos = Double.MaxValue;

        public void Avalia(Leilao leilao)
        {
            foreach (var lance in leilao.Lances)
            {
                if (lance.Valor > maiorDeTodos)
                {
                    maiorDeTodos = lance.Valor;
                }
                if (lance.Valor < menorDeTodos)
                {
                    menorDeTodos = lance.Valor;
                }
            }
        }

        public double MediaDosLances(Leilao leilao)
        {
            int qnt = leilao.Lances.Count;
            double soma = 0;

            foreach (var lance in leilao.Lances)
                soma += lance.Valor;

            if (qnt < 1)
                throw new Exception("Não pode dividir por zero");

            return soma / qnt;
        }

        public double MaiorLance { get { return maiorDeTodos; }}
        public double MenorLance { get { return menorDeTodos; }}
    }
}
