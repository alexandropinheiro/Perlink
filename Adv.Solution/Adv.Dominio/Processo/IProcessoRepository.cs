using Adv.Dominio.Enums;
using System;
using System.Collections.Generic;

namespace Adv.Dominio
{
    public interface IProcessoRepository
    {
        IEnumerable<Processo> ObterListaProcessos(
            string numero,
            double? valor,
            DateTime? dataInicial,
            EstadoEnum? estado,
            ProcessoSituacaoEnum? situacao,
            int? idCliente);

        IEnumerable<Processo> ObterProcessosPorIntervaloValor(double? valorInicial, double? valorFinal);

        IEnumerable<Processo> ObterProcessosPorMesAno(int mes, int ano);

        IEnumerable<Processo> ObterProcessosMesmoEstadoCliente(int idCliente);
    }
}
