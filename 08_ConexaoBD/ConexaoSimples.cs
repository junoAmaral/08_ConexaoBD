using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_ConexaoBD
{
    internal class ConexaoSimples
    {
        string host = "localhost";
        string banco = "08_lista_tarefas";
        string usuario = "root";
        string senha = "senac";

        public ConexaoSimples() 
        {  
            string dadosConexao = $"Server={host};Database={banco};Uid={usuario};Pwd={senha}"; 
            MySqlConnection conexao = new MySqlConnection(dadosConexao); 

            conexao.Open();

            string query = "SELECT * FROM tarefas;";
            MySqlCommand comando = new MySqlCommand(query, conexao); 
            
            MySqlDataReader dados = comando.ExecuteReader();

            while (dados.Read() == true)
            {
                Console.WriteLine("Descrição da tarefa: " + dados["descricao"]);
            }

            conexao.Close();
        }

    }
}
