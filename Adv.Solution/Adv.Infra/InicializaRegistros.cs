﻿using Adv.Dominio;
using Adv.Dominio.Enums;
using System;
using System.Collections.Generic;

namespace Adv.Infra
{
    public static class InicializaRegistros
    {
        static readonly Cliente empresaA = new Cliente
        {
            Id = 1,
            Nome = "Empresa A",
            Cnpj = "000000000001",
            Estado = EstadoEnum.RJ
        };

        static readonly Cliente empresaB = new Cliente
        {
            Id = 2,
            Nome = "Empresa B",
            Cnpj = "000000000002",
            Estado = EstadoEnum.SP
        };

        public static IEnumerable<Cliente> ObterClientes()
        {
            return new List<Cliente>
            {
                empresaA,
                empresaB
            };
        }

        public static IEnumerable<Processo> ObterProcessos()
        {
            return new List<Processo>
            {
                new Processo { Numero = "00001CIVELRJ", Estado = EstadoEnum.RJ, Valor = 200000, DataInicio = Convert.ToDateTime("10/10/2007"), Situacao = ProcessoSituacaoEnum.Ativo, IdCliente = 1, Cliente = empresaA },
                new Processo { Numero = "00002CIVELSP", Estado = EstadoEnum.SP, Valor = 100000, DataInicio = Convert.ToDateTime("20/10/2007"), Situacao = ProcessoSituacaoEnum.Ativo, IdCliente = 1, Cliente = empresaA },
                new Processo { Numero = "00003TRABMG", Estado = EstadoEnum.MG, Valor = 10000, DataInicio = Convert.ToDateTime("30/10/2007"), Situacao = ProcessoSituacaoEnum.Inativo, IdCliente = 1, Cliente = empresaA },
                new Processo { Numero = "00004CIVELRJ", Estado = EstadoEnum.RJ, Valor = 20000, DataInicio = Convert.ToDateTime("10/11/2007"), Situacao = ProcessoSituacaoEnum.Inativo, IdCliente = 1, Cliente = empresaA },
                new Processo { Numero = "00005CIVELSP", Estado = EstadoEnum.SP, Valor = 35000, DataInicio = Convert.ToDateTime("15/11/2007"), Situacao = ProcessoSituacaoEnum.Ativo, IdCliente = 1, Cliente = empresaA },
                new Processo { Numero = "00006CIVELRJ", Estado = EstadoEnum.RJ, Valor = 20000, DataInicio = Convert.ToDateTime("01/05/2007"), Situacao = ProcessoSituacaoEnum.Ativo, IdCliente = 2, Cliente = empresaB },
                new Processo { Numero = "00007CIVELRJ", Estado = EstadoEnum.RJ, Valor = 700000, DataInicio = Convert.ToDateTime("02/06/2007"), Situacao = ProcessoSituacaoEnum.Ativo, IdCliente = 2, Cliente = empresaB },
                new Processo { Numero = "00008CIVELSP", Estado = EstadoEnum.SP, Valor = 500, DataInicio = Convert.ToDateTime("03/07/2007"), Situacao = ProcessoSituacaoEnum.Inativo, IdCliente = 2, Cliente = empresaB },
                new Processo { Numero = "00009CIVELSP", Estado = EstadoEnum.SP, Valor = 32000, DataInicio = Convert.ToDateTime("04/08/2007"), Situacao = ProcessoSituacaoEnum.Ativo, IdCliente = 2, Cliente = empresaB },
                new Processo { Numero = "00010TRABAM", Estado = EstadoEnum.AM, Valor = 1000, DataInicio = Convert.ToDateTime("05/09/2007"), Situacao = ProcessoSituacaoEnum.Inativo, IdCliente = 2, Cliente = empresaB },
            };
        }
    }
}
