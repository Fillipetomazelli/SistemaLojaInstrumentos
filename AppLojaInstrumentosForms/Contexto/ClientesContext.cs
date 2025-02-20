using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppLojaInstrumentosForms.Models;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;

namespace AppLojaInstrumentosForms.Contexto
{
    public class ClientesContext
    {
        private string dados_conexao;
        private MySqlConnection conexao = null;

        //método construtor para carregar as informações dentro do objeto "conexao" para  conectar com o banco Mysql
        public ClientesContext()
        {
            dados_conexao = "server=localhost;port=3306;database=bd_instrumentos;user=root;password=2312;Persist Security Info=False;Connect Timeout=300;";
            conexao = new MySqlConnection(dados_conexao);//conexão preparada => objeto criado e pronto para conectar ao banco
        }//fim do método construtor

        public List<Clientes> ListarClientes()
        {
            List<Clientes> listaClientesParaExportar = new List<Clientes>();// para retornar (return) o resutaldo e ser utilizado na aplicação 
            string sql = "SELECT * FROM CLIENTES"; //consulta SQL para trazer todas as pessoas
            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexao);//objeto "comando" responsável por ir até o banco e realizar ações

                conexao.Open();//abrir a porta do banco para realizar a consulta

                MySqlDataReader dados = comando.ExecuteReader(); //"comando" vai realizar a consulta e enviar tudo para dentro do objeto "dados"

                //laço responsável por percorrer todos os registros que estão dentro do objeto "dados". 
                while (dados.Read())
                {
                    Clientes cliente = new Clientes();
                    cliente.Id = Convert.ToInt32(dados["Id"]);
                    cliente.Nome = dados["Nome"].ToString();
                    cliente.Cpf = dados["Cpf"].ToString();
                    cliente.Sexo = dados["Sexo"].ToString();
                    cliente.Idade = dados["Idade"].ToString();
                    cliente.Loja_Id = Convert.ToInt32(dados["Loja_Id"]);
                    listaClientesParaExportar.Add(cliente);
                }
                conexao.Close(); // Fechar a porta do banco após  resultado da consulta
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);

            }
            return listaClientesParaExportar; //retornar o resultado (exportar para aplicação) 

        }
        public void InserirPessoa(Clientes cliente)
        {
            string sql = "INSERT INTO CLIENTES (Nome, Cpf, Sexo, Idade, Loja_Id) VALUES (@Nome, @Cpf,@Sexo, @Idade, @Loja_Id)"; //para inserir uma pessoa no banco
            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexao);

                // Adicionando parâmetros para evitar SQL Injection
                comando.Parameters.AddWithValue("@Nome", cliente.Nome);
                comando.Parameters.AddWithValue("@Cpf", cliente.Cpf);
                comando.Parameters.AddWithValue("@Sexo", cliente.Sexo);
                comando.Parameters.AddWithValue("@Idade", cliente.Idade);
                comando.Parameters.AddWithValue("@Loja_Id", cliente.Loja_Id);
                comando.Parameters.AddWithValue("@Id", cliente.Id); // Identifica qual registro será atualizado

                conexao.Open(); // Abrir as portas do banco
                int linhasAfestadas = comando.ExecuteNonQuery(); //executa o comando e mostrar quantas linhas foram afetadas
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inserir veículo: " + ex.Message);

            }
            finally
            {
                conexao.Close(); // Fecha as portas do banco, mesmo que ocorra erro
            }
        }// fim do método para Inserir pessoas
        public void AtualizarCliente(Clientes cliente)
        {
            // Comando SQL para atualizar os dados da pessoa
            string sql = "UPDATE CLIENTES SET Nome = @Nome, Cpf = @Cpf, Sexo = @Sexo, Idade = @Idade, Loja_Id = @Loja_Id WHERE Id = @Id";

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexao);

                // Adicionando parâmetros para evitar SQL Injection
                comando.Parameters.AddWithValue("@Nome", cliente.Nome);
                comando.Parameters.AddWithValue("@Cpf", cliente.Cpf);
                comando.Parameters.AddWithValue("@Sexo", cliente.Sexo);
                comando.Parameters.AddWithValue("@Idade", cliente.Idade);
                comando.Parameters.AddWithValue("@Loja_Id", cliente.Loja_Id);
                comando.Parameters.AddWithValue("@Id", cliente.Id); // Identifica qual registro será atualizado

                conexao.Open(); // Abrir conexão com o banco
                int linhasAfetadas = comando.ExecuteNonQuery(); // Executa o comando e retorna quantas linhas foram alteradas

                if (linhasAfetadas > 0)
                {
                    MessageBox.Show("Cliente atualizada com sucesso!");
                }
                else
                {
                    MessageBox.Show("Nenhum registro foi atualizado. Verifique o ID informado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar Cliente: " + ex.Message);
            }
            finally
            {
                conexao.Close(); // Fecha a conexão com o banco
            }
        } //fim do Atualizar Pessoa

        public void DeleteCliente(Clientes cliente)
        {
            // Comando SQL para atualizar os dados da pessoa
            string sql = "DELETE FROM Clientes WHERE Id = @Id";

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexao);

                // Adicionando parâmetros para evitar SQL Injection
                comando.Parameters.AddWithValue("@Nome", cliente.Nome);
                comando.Parameters.AddWithValue("@Cpf", cliente.Cpf);
                comando.Parameters.AddWithValue("@Sexo", cliente.Sexo);
                comando.Parameters.AddWithValue("@Idade", cliente.Idade);
                comando.Parameters.AddWithValue("@Loja_Id", cliente.Loja_Id);
                comando.Parameters.AddWithValue("@Id", cliente.Id); // Identifica qual registro será atualizado


                conexao.Open(); // Abrir conexão com o banco
                int linhasAfetadas = comando.ExecuteNonQuery(); // Executa o comando e retorna quantas linhas foram alteradas

                if (linhasAfetadas > 0)
                {
                    MessageBox.Show("Cliente deletada com sucesso!");
                }
                else
                {
                    MessageBox.Show("Nenhum registro foi deletado. Verifique o ID informado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao deletar cliente: " + ex.Message);
            }
            finally
            {
                conexao.Close(); // Fecha a conexão com o banco
            }
        } //fim do Deletar Pessoa

    }
}

