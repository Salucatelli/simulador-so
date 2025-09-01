using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace simulador_so.Hardware;

public class Memory
{
    public int MaxSize { get; private set; } = 1024; //MB 
    public int UsedMemory { get; private set; } = 0;

    public Memory()
    {
    }
}
