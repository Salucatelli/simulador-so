using simulador_so.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simulador_so;

internal class SO
{
    public List<CPU> CPUs = new();
    public List<Process> Processes = new();

    public void InicializarCPUs(int quantidade)
    {
        for (int i = 0; i < quantidade; i++)
        {
            CPUs.Add(new CPU());
        }
    }

    public void IniciarProcessos()
    {
        // Main Process
        Process p1 = new(1, null);

        Processes.Add(p1);
    }

    // This class is going to call all the methods to run the system, starting with the creation of the processes, calling the scheduler to decide the priority and execute the processes
    public async Task ExecutarSistema()
    {
        // The main process
        Process P = new(1, null);

        // Creates a new porocess and adds it to the list
        Processes.Add(P.CreateSonProcess());
        Processes.Add(P.CreateSonProcess());

        foreach(var p in Processes.OrderBy(a => a.Prioridade))
        {
            await p.Execute();
        }

        Console.WriteLine("Execução finalizada. Pressione qualquer tecla para sair...");
        Console.ReadKey();
    }
}
