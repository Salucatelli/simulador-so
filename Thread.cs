using simulador_so.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simulador_so
{
    internal class Thread
    {
        private int Id { get; set; }
        private int Estado { get; set; } = 0; // 0 - Pronto, 1 - Executando, 2 - Bloqueado
        private bool Executado { get; set; }
        private Process ProcessoDerivado { get; set; }
    }
}
