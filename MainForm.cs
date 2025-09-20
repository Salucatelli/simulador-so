using simulador_so;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

public class ProcessView
{
    public string Nome { get; set; }
    public string Estado { get; set; }
    public int TicksRestantes { get; set; }
}

public class MainForm : Form
{
    private DataGridView grid;
    private BindingList<ProcessView> processList;


    public MainForm(SO so)
    {
        Text = "Simulador de SO";
        Width = 800;
        Height = 600;

        // Button Setting
        Button botao = new Button
        {
            Text = "Clique Aqui",
            Width = 100,
            Height = 30,
        };

        // Posiciona no canto inferior direito
        botao.Left = this.ClientSize.Width - botao.Width - 10; // 10 px de margem
        botao.Top = this.ClientSize.Height - botao.Height - 10;

        // Faz com que ele se mova junto se a janela for redimensionada
        botao.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

        botao.Click += (s, e) =>
        {
            // Executa um tick do simulador
            so.LoopFunction();

            // Atualiza a tabela imediatamente
            processList.Clear();
            foreach (var p in so.allProcesses)
            {
                processList.Add(new ProcessView
                {
                    Nome = p.Id,
                    Estado = p.State.ToString(),
                    TicksRestantes = p.GetRemainingTicksNeeded()
                });
            }
        };



        Controls.Add(botao);

        grid = new DataGridView
        {
            Dock = DockStyle.Fill,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            ReadOnly = true
        };

        Controls.Add(grid);

        // cria a lista vinculada
        processList = new BindingList<ProcessView>();
        grid.DataSource = processList;

        // exemplo: adicionando processos
        foreach(var p in so.allProcesses)
        {
            processList.Add(new ProcessView { Nome = p.Id, Estado = p.State.ToString(), TicksRestantes = p.GetRemainingTicksNeeded() });
        }
    }
}
