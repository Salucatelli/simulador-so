using simulador_so.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace simulador_so;

public class SO
{
    public List<CPU> CPUs = new();
    public List<Process> allProcesses = new();

    public int Ticks { get; set; } = 0;

    public Scheduler scheduler { get; set; }
    public Process MainProcess { get; set; }

    // States of a process and thread
    public enum ExecutionState { New, Ready, Running, Waiting, Terminated };

    public SO (int numCPUs)
    {
        InitializeCPUs(numCPUs);
        MainProcess = new(1, null);
        scheduler = new Scheduler();
    }

    public void InitializeCPUs(int qnt)
    {
        for (int i = 0; i < qnt; i++)
        {
            CPUs.Add(new CPU());
        }
    }

    /*
    ===============================================================================================
     # TO-DO
      - Melhorar o menu do terminal para aparecer tudo direito                                  ( )
      - Adicionar o alocamento de memória                                                       ( )
      - Editar o escalonador e criar uma interface, para adicionar os 3 algoritmos              ( )

    ===============================================================================================
     */

    public void ExecutarSistema()
    {
        // The main process
        Process P = new(1, null);

        // Creating manualy only for testing
        Process p1 = P.CreateSonProcess(2);
        Process p2 = P.CreateSonProcess(2);

        p1.CreateThread();
        p1.CreateThread();

        p2.CreateThread();
        p2.CreateThread();
        p2.CreateThread();

        allProcesses.Add(p1);
        allProcesses.Add(p2);

        foreach(var p in allProcesses)
        {
            // Adds all the processes to the scheduler queue
            p.State = ExecutionState.Ready;
            scheduler.AddProcessToQueue(p);
        }

        while (true)
        {
            if(allProcesses.All(p => p.State == ExecutionState.Terminated))
            {
                Console.WriteLine("\nExecução finalizada");
                break;
            }

            //Assign threads to all the cpus
            foreach(var cpu in CPUs)
            {
                if (cpu.IsIdle())
                {
                    // Next process to be executed
                    var nextProcess = scheduler.GetNextProcess();

                    // Give the process to the CPU, and it execute the next thread of the process
                    cpu.AddThread(nextProcess);
                    // Execute the current thread
                    Console.WriteLine($"CPU [{cpu.Id}] Executing {cpu.ExecutingThread}");
                }
            }

            // Execute Ticks for all the CPUs
            foreach(var cpu in CPUs)
            {
                var finished = cpu.ExecuteTick();
                if(finished is not null)
                {
                    Console.WriteLine($"CPU [{cpu.Id}] finished Thread [{finished}]");
                }
            }

            // Terminate the processes that has already finished
            foreach(var p in allProcesses)
            {
                if(p.Threads.All(t => t.State == ExecutionState.Terminated))
                {
                    p.State = ExecutionState.Terminated;
                }
            }

            ShowInfo();

            Console.ReadKey();

            Ticks++;
        }
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Tick Atual {Ticks}\n\n");

        Console.WriteLine($"Processos:\n");

        foreach(var p in allProcesses)
        {
            Console.WriteLine($"Id: [{p.Id}] | State: [{p.State}]");
        }
    }
}
