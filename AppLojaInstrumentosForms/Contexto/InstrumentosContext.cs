using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppLojaInstrumentosForms.Models;
using MySql.Data.MySqlClient;

namespace AppLojaInstrumentosForms.Contexto
{
    public class InstrumentosContext
    {
        private string dados_conexao;
        private MySqlConnection conexao = null;

        //método construtor para carregar as informações dentro do objeto "conexao" para  conectar com o banco Mysql
        public InstrumentosContext()
        {
            dados_conexao = "server=localhost;port=3306;database=bd_instrumentos;user=root;password=2312;Persist Security Info=False;Connect Timeout=300;";
            conexao = new MySqlConnection(dados_conexao);//conexão preparada => objeto criado e pronto para conectar ao banco
        }//fim do método construtor

        public List<Instrumentos> ListarInstrumentos()
        {
            List<Instrumentos> listaInstrumentosParaExportar = new List<Instrumentos>();// para retornar (return) o resutaldo e ser utilizado na aplicação 
            string sql = "SELECT * FROM INSTRUMENTOS"; //consulta SQL para trazer todas as pessoas
            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexao);//objeto "comando" responsável por ir até o banco e realizar ações

                conexao.Open();//abrir a porta do banco para realizar a consulta

                MySqlDataReader dados = comando.ExecuteReader(); //"comando" vai realizar a consulta e enviar tudo para dentro do objeto "dados"

                //laço responsável por percorrer todos os registros que estão dentro do objeto "dados". 
                while (dados.Read())
                {
                    Instrumentos instrumento = new Instrumentos();
                    instrumento.Id = Convert.ToInt32(dados["Id"]);
                    instrumento.Nome = dados["Nome"].ToString();
                    instrumento.Descricao = dados["Descricao"].ToString();
                    instrumento.Valor = Convert.ToDouble(dados["Valor"]);
                    instrumento.Modelo = dados["Modelo"].ToString();
                    instrumento.Genero = dados["Genero"].ToString();
                    instrumento.Loja_Id = Convert.ToInt32(dados["Loja_Id"]);
                    listaInstrumentosParaExportar.Add(instrumento);
                }
                conexao.Close(); // Fechar a porta do banco após  resultado da consulta
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);

            }
            return listaInstrumentosParaExportar; //retornar o resultado (exportar para aplicação) 

        }
        public void InserirInstrumentos(Instrumentos instrumento)
        {
            string sql = "INSERT INTO INSTRUMENTOS (Nome, Descricao, Valor, Modelo, Genero, Loja_Id) VALUES (@Nome, @Descricao, @Valor, @Modelo, @Genero, @Loja_Id)"; //para inserir uma pessoa no banco
            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexao);

                // Adicionando parâmetros para evitar SQL Injection
                comando.Parameters.AddWithValue("@Nome", instrumento.Nome);
                comando.Parameters.AddWithValue("@Descricao", instrumento.Descricao);
                comando.Parameters.AddWithValue("@Valor", instrumento.Valor);
                comando.Parameters.AddWithValue("@Modelo", instrumento.Modelo);
                comando.Parameters.AddWithValue("@Genero", instrumento.Genero);
                comando.Parameters.AddWithValue("@Loja_Id", instrumento.Loja_Id);
  

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
        public void AtualizarInstrumento(Instrumentos instrumento)
        {
            // Comando SQL para atualizar os dados da pessoa
            string sql = "UPDATE INSTRUMENTOS SET Nome = @Nome, Descricao = @Descricao, Valor = @Valor, Loja_Id = @Loja_Id, Modelo = @Modelo, Genero = @Genero WHERE Id = @Id";

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexao);

                // Adicionando parâmetros para evitar SQL Injection
                comando.Parameters.AddWithValue("@Nome", instrumento.Nome);
                comando.Parameters.AddWithValue("@Descricao", instrumento.Descricao);
                comando.Parameters.AddWithValue("@Valor", instrumento.Valor);
                comando.Parameters.AddWithValue("@Modelo", instrumento.Modelo);
                comando.Parameters.AddWithValue("@Genero", instrumento.Genero);
                comando.Parameters.AddWithValue("@Loja_Id", instrumento.Loja_Id);
                comando.Parameters.AddWithValue("Id", instrumento.Id);

                conexao.Open(); // Abrir conexão com o banco
                int linhasAfetadas = comando.ExecuteNonQuery(); // Executa o comando e retorna quantas linhas foram alteradas

                if (linhasAfetadas > 0)
                {
                    MessageBox.Show("instrumento atualizada com sucesso!");
                }
                else
                {
                    MessageBox.Show("Nenhum registro foi atualizado. Verifique o ID informado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar instrumento: " + ex.Message);
            }
            finally
            {
                conexao.Close(); // Fecha a conexão com o banco
            }
        } //fim do Atualizar Pessoa

        public void DeleteInstrumento(Instrumentos instrumento)
        {
            // Comando SQL para atualizar os dados da pessoa
            string sql = "DELETE FROM INSTRUMENTOS WHERE Id = @Id";

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexao);

                // Adicionando parâmetros para evitar SQL Injection
                comando.Parameters.AddWithValue("@Nome", instrumento.Nome);
                comando.Parameters.AddWithValue("@Descricao", instrumento.Descricao);
                comando.Parameters.AddWithValue("@Valor", instrumento.Valor);
                comando.Parameters.AddWithValue("@Modelo", instrumento.Modelo);
                comando.Parameters.AddWithValue("@Genero", instrumento.Genero);
                comando.Parameters.AddWithValue("@Loja_Id", instrumento.Loja_Id);
                comando.Parameters.AddWithValue("Id", instrumento.Id);



                conexao.Open(); // Abrir conexão com o banco
                int linhasAfetadas = comando.ExecuteNonQuery(); // Executa o comando e retorna quantas linhas foram alteradas

                if (linhasAfetadas > 0)
                {
                    MessageBox.Show("Instrumento deletada com sucesso!");
                }
                else
                {
                    MessageBox.Show("Nenhum registro foi deletado. Verifique o ID informado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao deletar instrumento: " + ex.Message);
            }
            finally
            {
                conexao.Close(); // Fecha a conexão com o banco
            }
        } //fim do Deletar Pessoa
    }
}
