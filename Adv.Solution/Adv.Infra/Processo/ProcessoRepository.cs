using Adv.Dominio;
using Adv.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Adv.Infra
{
    public class ProcessoRepository : IProcessoRepository
    {
        public IEnumerable<Processo> ObterListaProcessos(string numero,
                                                         double? valor,
                                                         DateTime? dataInicio,
                                                         EstadoEnum? estado,
                                                         ProcessoSituacaoEnum? situacao,
                                                         int? idCliente)
        {
            var predicate = PredicateBuilder.True<Processo>();

            if (!string.IsNullOrEmpty(numero))
                predicate = predicate.And(x => x.Numero.Contains(numero));

            if (valor.HasValue)
                predicate = predicate.And(x => x.Valor == valor);

            if (dataInicio.HasValue)
                predicate = predicate.And(x => x.DataInicio == dataInicio);

            if (estado.HasValue)
                predicate = predicate.And(x => x.Estado == estado);

            if (situacao.HasValue)
                predicate = predicate.And(x => x.Situacao == situacao);

            if (idCliente.HasValue)
                predicate = predicate.And(x => x.IdCliente == idCliente);

            return InicializaRegistros.ObterProcessos().AsQueryable().Where(predicate);
        }

        public IEnumerable<Processo> ObterProcessosPorIntervaloValor(double? valorInicial, double? valorFinal)
        {
            var predicate = PredicateBuilder.True<Processo>();

            if (valorInicial.HasValue)
                predicate = predicate.And(x => x.Valor > valorInicial);

            if (valorFinal.HasValue)
                predicate = predicate.And(x => x.Valor < valorFinal);

            return InicializaRegistros.ObterProcessos().AsQueryable().Where(predicate).ToList();
        }

        public IEnumerable<Processo> ObterProcessosPorMesAno(int mes, int ano)
        {
            return InicializaRegistros.ObterProcessos().Where(p => p.DataInicio.Month == mes && p.DataInicio.Year == ano);
        }

        public IEnumerable<Processo> ObterProcessosMesmoEstadoCliente(int idCliente)
        {
            var processos = InicializaRegistros.ObterProcessos().Join(
                    InicializaRegistros.ObterClientes(),
                    p => p.IdCliente,
                    c => c.Id,
                    (p, c) => new { p, c })
                    .Where(x => x.p.IdCliente == x.c.Id && x.p.Estado == x.c.Estado && x.c.Id == idCliente)
                    .Select(y => y.p);

            return processos;
        }
    }
}
