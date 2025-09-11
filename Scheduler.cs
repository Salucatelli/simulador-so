using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using simulador_so;
using static simulador_so.SO;

namespace simulador_so;

public class Scheduler
{
    // Por enquando estou implementando apenas o FCFS, First come first served

    // Fila com os processos
    public Queue<Process> Queue { get; set; } = new();

    // Adds a process to the queue
    public void AddProcessToQueue(Process p)
    {
        Queue.Enqueue(p);
    }

    // If there is only 1 thread left to execute, it removes the process from the queue and return it, if not, it only returns the next process
    public Process GetNextProcess()
    {
        var process = Queue.Peek();

        if(process is not null)
        {
            if (process.Threads.Count(t => t.State == ExecutionState.Terminated) == process.Threads.Count - 1)
            {
                return Queue.Dequeue();
            }
            else
            {
                return process;
            }
        }
        return null!;
    }
}
