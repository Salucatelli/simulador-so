using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace simulador_so.Hardware;

public class Memory
{
    public int MaxSize { get; private set; } //MB 
    public int UsedMemory { get; private set; } = 0;

    public Memory(int size) { MaxSize = size; }

    // Here it tries to allocate memory
    public bool AllocateMemory(int size)
    {
        if (UsedMemory + size > MaxSize)
            return false;
        else
        {
            UsedMemory += size;
            return true;
        }
    }

    // Here it frees the memory
    public bool FreeMemory(int size)
    {
        UsedMemory -= size;
        return true;
    }
}
