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
    public List<Process> allProcesses = new();
    public List<Process> waitingProcesses = new();
    public List<Process> executingProcesses = new();
    public List<Process> endProcesses = new();

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

        waitingProcesses.Add(p1);
    }

    // Eu posso ao invez de simplesmente mandar tudo executar dentro do SO, declarar meus núcleos, e esses núcleos farão o trabalho de chamar o escalonador para decidir o próximo processo, e executa-lo.

    // This class is going to call all the methods to run the system, starting with the creation of the processes, calling the scheduler to decide the priority and execute the processes
    public async Task ExecutarSistema()
    {
        // The main process
        Process P = new(1, null);

        // A ideia inicial é simplesmente criar todos os processos no início do programa, e colocar todos eles em uma lista. Toda vez que um processo for finalizado, eu passo essa lista de processos que estão aguardando para o escalonador, ele decide qual o próximo processo a ser executado, executa ele, e assim por diante.

        // Perguntar depois pro professor se eu preciso ter um sistema para interromper processos no meio da execução para colocar outros pocessos no lugar (Preempção).

        // Creates a new porocess and adds it to the list
        allProcesses.Add(P.CreateSonProcess(2));
        allProcesses.Add(P.CreateSonProcess(1));

        waitingProcesses = allProcesses.ToList();

        // Depois de adicionar os processos na lista, eu começo um loop para executa-los


        // Esse for basicamente passa pela lista com todos os processos. A cada execução ele chama o escalonador para decidir qual será o proximo, atualiza as listas de processos em espera e os em execução, e executa o processo selecionado. Repete isso até acabar os processos da lista.
        for(int i = 0; i < allProcesses.Count; i++)
        {
            // Posso depois fazer uma "tela" para vizualizar o estado atual de cada uma das listas, e talvez dos processos que estão sendo executados naquele momento.

            // chama o escalonador para decidir qual processo será executado
            Process pToBeExecuted = await Scheduler.GetNextProcess(waitingProcesses);

            waitingProcesses.Remove(pToBeExecuted);
            executingProcesses.Add(pToBeExecuted);

            Console.WriteLine($"Processo de Id {pToBeExecuted.Id} com prioridade {pToBeExecuted.Prioridade} selecionado para ser executado.\n");

            await Task.Delay(200); // 0.2s

            await pToBeExecuted.Execute();
        }

        Console.WriteLine("Execução finalizada. Pressione qualquer tecla para sair...");
        Console.ReadKey();
    }
}
