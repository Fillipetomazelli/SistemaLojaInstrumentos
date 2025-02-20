using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppLojaInstrumentosForms.Models;
using MySql.Data.MySqlClient;

namespace AppLojaInstrumentosForms.Contexto
{
    public class LojaContext
    {
        private string dados_conexao;
        private MySqlConnection conexao = null;

        //método construtor para carregar as informações dentro do objeto "conexao" para  conectar com o banco Mysql
        public LojaContext()
        {
            dados_conexao = "server=localhost;port=3306;database=bd_instrumentos;user=root;password=2312;Persist Security Info=False;Connect Timeout=300;";
            conexao = new MySqlConnection(dados_conexao);//conexão preparada => objeto criado e pronto para conectar ao banco
        }//fim do método construtor

        public List<Loja> ListarLojas()
        {
            List<Loja> listaLojasParaExportar = new List<Loja>();// para retornar (return) o resutaldo e ser utilizado na aplicação 
            string sql = "SELECT * FROM LOJA"; //consulta SQL para trazer todas as pessoas
            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexao);//objeto "comando" responsável por ir até o banco e realizar ações

                conexao.Open();//abrir a porta do banco para realizar a consulta

                MySqlDataReader dados = comando.ExecuteReader(); //"comando" vai realizar a consulta e enviar tudo para dentro do objeto "dados"

                //laço responsável por percorrer todos os registros que estão dentro do objeto "dados". 
                while (dados.Read())
                {
                    Loja loja = new Loja();
                    loja.Id = Convert.ToInt32(dados["Id"]);
                    loja.Nome = dados["Nome"].ToString();
                    loja.DonoDaLoja = dados["DonoDaLoja"].ToString();
                    loja.Cnpj = dados["Cnpj"].ToString();
                    listaLojasParaExportar.Add(loja);
                }
                conexao.Close(); // Fechar a porta do banco após  resultado da consulta
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);

            }
            return listaLojasParaExportar; //retornar o resultado (exportar para aplicação) 

        }
        public void InserirLoja(Loja loja)
        {
            string sql = "INSERT INTO LOJA ( Nome, DonoDaLoja, Cnpj) VALUES (@Nome, @DonoDaLoja, @Cnpj)"; //para inserir uma pessoa no banco
            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexao);

                // Adicionando parâmetros para evitar SQL Injection
                comando.Parameters.AddWithValue("@Nome", loja.Nome);
                comando.Parameters.AddWithValue("@DonoDaLoja", loja.DonoDaLoja);
                comando.Parameters.AddWithValue("@Cnpj", loja.Cnpj);


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
       
    }
}
