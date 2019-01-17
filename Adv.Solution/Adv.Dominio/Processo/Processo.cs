using Adv.Dominio.Enums;
using System;

namespace Adv.Dominio
{
    public class Processo : BaseDominio
    {
        public string Numero { get; set; }
        public double Valor { get; set; }
        public EstadoEnum Estado { get; set; }
        public DateTime DataInicio { get; set; }
        public ProcessoSituacaoEnum Situacao { get; set; }

        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; }
    }
}
