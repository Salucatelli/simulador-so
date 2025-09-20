using simulador_so.Interfaces;
using simulador_so.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static simulador_so.SO;

namespace simulador_so.Schedulers;

public class RRScheduler : IScheduler
{
    private Process LastProcess = null!;

    private int _quantum = 6; // Just an exemple
    private int _currentQuantumTick = 0;

    // List with all the processes
    private Queue<Process> processes { get; set; } = new();

    // Adds a process to the list
    public void AddProcessToList(Process p)
    {
        if (p is not null)
            processes.Enqueue(p);
    }

    // Returns the next process based on a algorithm
    public Process GetNextProcess()
    {
        var next = processes.Peek();

        if (LastProcess != next && LastProcess is not null)
        {
            // Isn't finished yet
            if (LastProcess.GetRemainingTicksNeeded() > 0)
            {
                LastProcess.State = ExecutionState.Waiting;
            }
            LastProcess = next;
        }

        _currentQuantumTick++;

        // If the process is about to end, it already removes it from the queue
        if (next.Threads.Count(t => t.State == ExecutionState.Terminated) == next.Threads.Count - 1)
        {
            processes.Dequeue();
            _currentQuantumTick = 0;
        }
        // If the processes reach the max quantum, it returns to the end of the queue
        else if (_currentQuantumTick == _quantum)
        {
            _currentQuantumTick = 0;
            processes.Dequeue();
            processes.Enqueue(next);
        }

        return next;
    }
}
