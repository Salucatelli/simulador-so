using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simulador_so;

internal class Scheduler
{

    public static async Task<Process> GetNextProcess(List<Process> processes)
    {
        // Por enquanto ele apenas retorna o processo com a maior prioridade. Futuramente serão adicionados os outros algoritmos de escalonamento.
        Process toBeExecuted = processes.OrderByDescending(p => p.Prioridade).FirstOrDefault()!;

        await Task.Delay(1000); // simula o tempo do escalonador de decidir o proximo processo

        return processes.OrderByDescending(p => p.Prioridade).FirstOrDefault()!;
    }
}
