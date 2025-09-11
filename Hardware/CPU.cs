using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static simulador_so.SO;

namespace simulador_so.Hardware;

public class CPU
{
    public string Id = Guid.NewGuid().ToString("N");
    public SimThread? ExecutingThread { get; set; } = null;
    public int CurrentTick { get; set; } = 0;

    // If there is no thread executing, the cpu is idle
    public bool IsIdle() => ExecutingThread is null;

    // Here it tries to execute a thread from the process that the scheduler send
    public void AddThread(Process p)
    {
        if(ExecutingThread != null)
        {
            return;
        }
        else
        {
            SimThread t = p.GetNextThread();
            if(t is not null)
            {
                t.State = ExecutionState.Running;
                ExecutingThread = t;
                return;
            }
        }
    }

    public SimThread ExecuteTick()
    {
        if(ExecutingThread is not null)
        {
            ExecutingThread.TicksNeeded--;
            if(ExecutingThread.TicksNeeded <= 0)
            {
                ExecutingThread.State = ExecutionState.Terminated;
                var finished = ExecutingThread;
                ExecutingThread = null;
                return finished;
            }
        }
        return null!;
    }
}
