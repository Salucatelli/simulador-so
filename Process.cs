using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simulador_so
{
    internal class Process
    {
        private Process? Pai { get; set; } = null;
        private int Id { get; set; }
        private int Prioridade { get; set; }
        private bool Executado { get; set; } = false;
        private int Estado { get; set; } = 0; // 0 - Pronto, 1 - Executando, 2 - Bloqueado
        private int MemoriaAlocada { get; set; } = 0;
        private int TempoExecucao { get; set; } = 0;
        private List<Thread> Threads { get; set; } = new();

        public Process(int id, int prioridade, Process? pai = null)
        {
            Id = id;
            Prioridade = prioridade;
            Pai = pai;
        }


    }
}
