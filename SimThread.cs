using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static simulador_so.SO;

namespace simulador_so
{
    public class SimThread
    {
        public string Id { get; set; } = Guid.NewGuid().ToString("N");
        public ExecutionState State { get; set; } = ExecutionState.New; // 0 - Criada, 1 - Pronta, 2 - Executando, 3 - Bloqueada, 4 - Finalizada
        public bool Executado { get; set; }
        public Process FatherProcess { get; set; }
        public int TicksNeeded { get; set; }

        public override string ToString() => $"T{Id}(P{FatherProcess.Id})[{State}] Remaining Ticks={TicksNeeded}";

        public SimThread(Process fatherProcess, int ticks)
        {
            FatherProcess = fatherProcess; // The process that created this thread
            TicksNeeded = ticks; // Ticks needed to execute this thread
            State = ExecutionState.Ready;
        }

        //public async Task Execute()
        //{
        //    Estado = 2; // Executing
        //    // Simuilates the execution of the thread
        //    // await Task.Delay(3000);
        //    Estado = 4; // Executed
        //}
    }
}
