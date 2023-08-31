using _08_ConexaoBD;
using System.Data;

Tarefa tarefa= new Tarefa(); 

Console.WriteLine("Boas- vindas ao sistema do Conradito Consultinhas!\n"); 

List<Tarefa> tarefas = tarefa.BuscaTodos();
foreach (Tarefa t in tarefas) 
{
    Console.WriteLine($" - Tarefa {t.id}: {t.descricao} | Criado em {t.criado_em}."); 
}

Console.WriteLine("\nDigite 1 para consultar o ID, 2 para consultar a DESCRIÇÃO ou 3 para CADASTRAR uma tarefa:"); 

string opcao = Console.ReadLine(); 

if (opcao == "3")
{
    Console.WriteLine("\nBoas-vindas ao CADASTRO! \nDigite a descrição da nova tarefa:"); 
    string descricao = Console.ReadLine();

    Console.WriteLine("Tarefa concluída? Digite 1 para sim ou 2 para não:"); 
    bool concluido = Console.ReadLine() == "1"; 

    Tarefa t = new Tarefa(); 
    t.descricao = descricao; 
    t.concluido = concluido;

    tarefa.Insere(t); 
}

/*
if (opcao == "1")
{
    Console.WriteLine("Digite o ID que deseja consultar: "); 
    int id = int.Parse(Console.ReadLine());
    tarefa = tarefa.BuscaPorId(id); 
}
else
{
    Console.WriteLine("Digite a DESCRIÇÃO que deseja encontrar: ");
    string descricao = Console.ReadLine(); 
    tarefa = tarefa.BuscaPorDescricao(descricao); 
}

Console.WriteLine($"\nResultados encontrados: "); 
Console.WriteLine($"Tarefa {tarefa.id}: {tarefa.descricao}. \nCriado em {tarefa.criado_em}."); 
*/