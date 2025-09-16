using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static simulador_so.SO;

namespace simulador_so.Models
{
    public class Process
    {
        public Process? Pai { get; set; } = null;
        public string Id { get; set; } = Guid.NewGuid().ToString("N");
        public int Prioridade { get; set; }
        public bool Executado { get; set; } = false;
        public ExecutionState State { get; set; } // 0 - Criado, 1 - Pronto, 2 - Executando, 3 - Bloqueado, 4 - Encerrado
        public int MemoriaAlocada { get; set; } = 0;
        public int TempoExecucao { get; set; } = 0; // Seconds
        public List<SimThread> Threads { get; set; } = new();

        public Process(int prioridade, Process? pai = null)
        {
            Prioridade = prioridade;
            Pai = pai;
        }

        public Process CreateSonProcess(int priority)
        {
            return new Process(priority, this);
        }

        // Creates a new thread
        public void CreateThread()
        {
            // In the future this will generate a random thread
            var t = new SimThread(this, 4);
            Threads.Add(t);
        }

        public SimThread GetNextThread() {
            var next = Threads.Where(t => t.State == ExecutionState.Ready).FirstOrDefault() ?? null!;
            if (next is not null)
            {
                next.State = ExecutionState.Waiting;
                return next;
            }
            return null!; 
        }

        // Execute all the threads in the process
        //public async Task Execute()
        //{
        //    this.Estado = 3; // Executing

        //    Console.WriteLine($"Executing process {Id}\n");

        //    foreach(Thread t in Threads)
        //    {
        //        Console.WriteLine($"Executing thread {t.Id}");
        //        await t.Execute();
        //    }

        //    this.Estado = 4; // Executed
        //}
    }
}
