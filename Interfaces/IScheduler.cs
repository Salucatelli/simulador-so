using simulador_so.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simulador_so.Interfaces;

public interface IScheduler
{
    // Method for adding a process to the list
    public void AddProcessToList(Process p);

    // Method that return the nexto process to be executed
    public Process GetNextProcess();
}
