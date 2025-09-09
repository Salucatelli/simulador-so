using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simulador_so.Hardware;

internal class CPU
{
    // Talvez de para criar uma classe de núcleo, e cada nucleo executa separadamente, ou seja, ele chama o escalonador para decidir qual processo deve executar, executa esse processo, e repete até que não tenha mais nenhum processo na fila.

    public List<Core> Cores = new();


}
