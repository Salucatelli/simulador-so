using simulador_so.Interfaces;
using simulador_so.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static simulador_so.SO;

namespace simulador_so.Schedulers;

public class SRTScheduler : IScheduler
{
    private Process LastProcess = null!;

    // List with all the processes
    private List<Process> processes { get; set; } = new();

    // Adds a process to the list
    public void AddProcessToList(Process p)
    {
        if(p is not null)
            processes.Add(p);
    }

    // Returns the next process based on a algorithm
    public Process GetNextProcess()
    {
        //This dictionary contains all the process in the line and it's remaining time
        Dictionary<Process, int> ProcessTicks = new Dictionary<Process, int>();

        // Fill the ProcessTicks dictionary 
        foreach (Process p in processes)
        {
            int total = 0;

            var threads = p.Threads;
            foreach(var t in threads)
            {
                total += t.TicksNeeded;
            }

            ProcessTicks.Add(p, total);
        }

        Process next = ProcessTicks.Where(p => p.Value == ProcessTicks.Min(t => t.Value)).FirstOrDefault().Key;

        if (LastProcess != next && LastProcess is not null)
        {
            // Isn't finished yet
            if (LastProcess.GetRemainingTicksNeeded() > 0)
            {
                LastProcess.State = ExecutionState.Waiting;
            }
            LastProcess = next;
        }

        // If the process is about to end, it already removes it from the list
        if (next.Threads.Count(t => t.State == ExecutionState.Terminated) == next.Threads.Count - 1)
        {
            processes.Remove(next);
            return next;
        }
        else
        {
            return next;
        }
    }
}
