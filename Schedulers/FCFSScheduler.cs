using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using simulador_so.Interfaces;
using simulador_so.Models;
using static simulador_so.SO;

namespace simulador_so.Schedulers;

public class FCFSScheduler : IScheduler
{
    // Por enquando estou implementando apenas o FCFS, First come first served

    // Fila com os processos
    private Queue<Process> Queue { get; set; } = new();

    private Process LastProcess = null!;

    // Adds a process to the queue
    public void AddProcessToList(Process p)
    {
        Queue.Enqueue(p);
    }

    // If there is only 1 thread left to execute, it removes the process from the queue and return it, if not, it only returns the next process
    public Process GetNextProcess()
    {
        var process = Queue.Peek();

        if(process is not null)
        {
            if(LastProcess != process && LastProcess is not null)
            {
                // Isn't finished yet
                if(LastProcess.GetRemainingTicksNeeded() > 0)
                {
                    LastProcess.State = ExecutionState.Waiting;
                }
                LastProcess = process;
            }

            process.State = ExecutionState.Running;

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
