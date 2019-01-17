using Adv.Dominio.Enums;
using System.Collections.Generic;

namespace Adv.Dominio
{
    public class Cliente : BaseDominio
    {
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public EstadoEnum Estado { get; set; }

        public ICollection<Processo> Processos { get; set; }
    }
}
