using Adv.Dominio;
using Adv.Dominio.Enums;
using Adv.Infra;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Unity;

namespace Adv.Teste
{
    [TestClass]
    public class CasosTeste
    {
        private readonly UnityContainer _container = new UnityContainer();
        private readonly IProcessoRepository _processoRepository;

        public CasosTeste()
        {
            _container.RegisterType<IProcessoRepository, ProcessoRepository>();
            _processoRepository = _container.Resolve<IProcessoRepository>();
        }

        [TestMethod]
        public void ObterSomaValorProcessosAtivos()
        {        
            var processosAtivos = _processoRepository.ObterListaProcessos(string.Empty, null, null, null, ProcessoSituacaoEnum.Ativo, null);

            var somaValores = processosAtivos.Sum(p => p.Valor);

            Assert.AreEqual(1087000, somaValores);
        }

        [TestMethod]
        public void ObterMediaValorProcessosRJEmpresaA()
        {
            var processos = _processoRepository.ObterListaProcessos(string.Empty, null, null, EstadoEnum.RJ, null, 1);

            var mediaValores = processos.Average(p => p.Valor);

            Assert.AreEqual(110000, mediaValores);
        }

        [TestMethod]
        public void ObterProcessosComValorAcimaDe100Mil()
        {            
            var processos = _processoRepository.ObterProcessosPorIntervaloValor(100000, null);

            Assert.AreEqual(2, processos.Where(p => p.Valor > 100000).Count());
        }

        [TestMethod]
        public void ObterProcessosNoMesSetembro2007()
        {            
            var processos = _processoRepository.ObterProcessosPorMesAno(9, 2007);

            Assert.AreEqual(1, processos.Count());
            Assert.AreEqual("00010TRABAM", processos.FirstOrDefault().Numero);
        }

        [TestMethod]
        public void ObterProcessosMesmoEstadoClienteA()
        {
            var processos = _processoRepository.ObterProcessosMesmoEstadoCliente(1);

            Assert.AreEqual(2, processos.Count());

            var i = 1;
            foreach (var p in processos.OrderBy(pr => pr.Numero))
            {
                switch (i)
                {
                    case 1:
                        Assert.AreEqual("00001CIVELRJ", p.Numero);
                        break;

                    case 2:
                        Assert.AreEqual("00004CIVELRJ", p.Numero);
                        break;
                }
                i++;
            }
        }

        [TestMethod]
        public void ObterProcessosMesmoEstadoClienteB()
        {
            var processos = _processoRepository.ObterProcessosMesmoEstadoCliente(2);

            Assert.AreEqual(2, processos.Count());

            var i = 1;
            foreach (var p in processos.OrderBy(pr => pr.Numero))
            {
                switch (i)
                {
                    case 1:
                        Assert.AreEqual("00008CIVELSP", p.Numero);
                        break;

                    case 2:
                        Assert.AreEqual("00009CIVELSP", p.Numero);
                        break;
                }
                i++;
            }
        }

        [TestMethod]
        public void ObterProcessosComSiglaTRAB()
        {
            var processos = _processoRepository.ObterListaProcessos("TRAB", null, null, null, null, null);

            Assert.AreEqual(2, processos.Count());

            var i = 1;
            foreach (var p in processos.OrderBy(pr => pr.Numero))
            {
                switch (i)
                {
                    case 1:
                        Assert.AreEqual("00003TRABMG", p.Numero);
                        break;

                    case 2:
                        Assert.AreEqual("00010TRABAM", p.Numero);
                        break;
                }
                i++;
            }
        }
    }
}
