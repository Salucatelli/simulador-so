using simulador_so;
using System.Windows.Forms;

public class Program
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        SO system = new(1);
        system.BootSystem();

        Application.Run(new MainForm(system)); // abre a janela
    }
}


