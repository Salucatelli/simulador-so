using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simulador_so
{
    public class Process
    {
        public Process? Pai { get; set; } = null;
        public string Id { get; set; } = Guid.NewGuid().ToString("N");
        public int Prioridade { get; set; }
        public bool Executado { get; set; } = false;
        public int Estado { get; set; } = 0; // 0 - Criado, 1 - Pronto, 2 - Executando, 3 - Bloqueado, 4 - Encerrado
        public int MemoriaAlocada { get; set; } = 0;
        public int TempoExecucao { get; set; } = 0; // Seconds
        public List<Thread> Threads { get; set; } = new();

        public Process(int prioridade, Process? pai = null)
        {
            Prioridade = prioridade;
            Pai = pai;

            // Here it will create all the threads, and divide the memory for them
            this.CreateThread();
            this.CreateThread();

            this.Estado = 1; // Ready
        }

        public Process CreateSonProcess()
        {
            return new Process(0, this);
        }

        // Creates a new thread
        public void CreateThread()
        {
            Thread t = new(this);
            t.Estado = 1; // Waitig
            Threads.Add(t);
        }

        // Execute all the threads in the process
        public async Task Execute()
        {
            this.Estado = 3; // Executing

            Console.WriteLine($"Executing process {Id}\n");

            foreach(Thread t in Threads)
            {
                Console.WriteLine($"Executing thread {t.Id}");
                await t.Execute();
            }

            this.Estado = 4; // Executed
        }
    }
}
