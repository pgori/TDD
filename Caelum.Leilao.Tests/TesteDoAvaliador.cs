using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao
{
    [TestFixture]
    public class TesteDoAvaliador
    {

        [Test]
        public void DeveEntenderLancesEmOrdemCrescente()
        {
            // cenario: 3 lances em ordem crescente
            Usuario morgan = new Usuario("Arthur Morgan");
            Usuario dutch = new Usuario("Dutch Van Der Linde");
            Usuario maria = new Usuario("maria");

            Leilao leilao = new Leilao("Red Dead Redemption II");

            leilao.Propoe(new Lance(maria, 250.0));
            leilao.Propoe(new Lance(morgan, 300.0));
            leilao.Propoe(new Lance(dutch, 400.0));

            //executando a acao
            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            // comparando a saida com o esperado
            double maiorEsperado = 400;
            double menorEsperado = 250;

            Assert.AreEqual(maiorEsperado, leiloeiro.MaiorLance, 0.00001);
            Assert.AreEqual(menorEsperado, leiloeiro.MenorLance, 0.00001);
        }

        [Test]
        public void MediaDosLancesTest()
        {
            //cenario: média de 3 lances
            Usuario john = new Usuario("John Marston");
            Usuario hosea = new Usuario("Hosea");
            Usuario abigail = new Usuario("Abigail");

            Leilao leilao = new Leilao("RDRII");

            leilao.Propoe(new Lance(john, 200.0));
            leilao.Propoe(new Lance(hosea, 200.0));
            leilao.Propoe(new Lance(abigail, 200.0));

            Avaliador leiloeiro = new Avaliador();

            double mediaEsperada = 200;

            Assert.AreEqual(mediaEsperada, leiloeiro.MediaDosLances(leilao), 0.00001);
        }
    }
}
