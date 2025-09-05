using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simulador_so
{
    public class Thread
    {
        public string Id { get; set; } = Guid.NewGuid().ToString("N");
        public int Estado { get; set; } = 0; // 0 - Criada, 1 - Pronta, 2 - Executando, 3 - Bloqueada, 4 - Finalizada
        public bool Executado { get; set; }
        public Process FatherProcess { get; set; }

        public Thread(Process fatherProcess)
        {
            FatherProcess = fatherProcess; // The process that created this thread
        }

        public async Task Execute()
        {
            Estado = 2; // Executing
            // Simuilates the execution of the thread
            await Task.Delay(3000);
            Estado = 4; // Executed
        }
    }
}
