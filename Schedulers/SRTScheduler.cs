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

internal class SRTScheduler : IScheduler
{
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
        // to be implemented yet
        foreach (Process p in processes)
        {
            int total = 0;
            var threads = p.Threads;
            foreach(var t in threads)
            {

            }
        }
        return null!;
    }
}
