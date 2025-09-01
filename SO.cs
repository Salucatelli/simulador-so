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

    public void InicializarCPUs(int quantidade)
    {
        for (int i = 0; i < quantidade; i++)
        {
            CPUs.Add(new CPU());
        }
    }

    public void IniciarProcessos()
    {
        // A ser implementado
        Process p1 = new(1, 2, null);
    }
}
