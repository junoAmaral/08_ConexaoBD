using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_ConexaoBD
{
    internal class Tarefa
    {
        public int id;
        public string descricao;
        public bool concluido;
        public string criado_em;

        public Tarefa()
        {

        }

        public Tarefa(int id, string descricao, bool concluido, string criado_em) 
        {
            this.id = id;
            this.descricao = descricao;
            this.concluido = concluido;
            this.criado_em = criado_em;
        }

        public List <Tarefa> BuscaTodos()
        {
            string query = "SELECT * FROM tarefas;"; 

            DataTable tabela = Conexao.executaQuery(query); 

            List<Tarefa> tarefas = new List<Tarefa>(); 
            foreach (DataRow linha in tabela.Rows)
            {
                Tarefa tarefa = CarregaDados(linha); 
                tarefas.Add(tarefa); 
            }

            return tarefas; 
        }

        public Tarefa BuscaPorId(int id)
        {
            string query = $"SELECT * FROM tarefas WHERE id = {id};";
            DataTable tabela = Conexao.executaQuery(query); 

            Tarefa tarefa = CarregaDados(tabela.Rows[0]); 
            return tarefa; 
        }

        public Tarefa BuscaPorDescricao(string descricao)
        {
            string query = $"SELECT * FROM tarefas WHERE descricao = '{descricao}';";
            DataTable tabela = Conexao.executaQuery(query);

            Tarefa tarefa = CarregaDados(tabela.Rows[0]);
            return tarefa;
        }

        public void Insere(Tarefa tarefa) 
        {
            int concluido = tarefa.concluido == true ? 1 : 0; 
            string query = $"INSERT INTO tarefas (descricao, concluido) VALUES ('{tarefa.descricao}', {concluido});"; 
            Conexao.executaQuery(query); 
        }

        public Tarefa CarregaDados(DataRow linha)
        {
            int id = int.Parse(linha["id"].ToString()); 
            string descricao = linha["descricao"].ToString();
            bool concluido = linha["concluido"].ToString() == "1" ? true : false;
            string criado_em = linha["criado_em"].ToString(); 

            Tarefa tarefa = new Tarefa(id, descricao, concluido, criado_em);
            return tarefa; 
        }
    }
}
