using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace GuitarHero
{
    internal class BD
    {
        String conection = @"Data Source=DESKTOP-H00DGNB;Initial Catalog=Guitar_Arena;Integrated Security=True";

        private SqlConnection AbreBanco()
        {
            try
            {
                SqlConnection con = new SqlConnection();// usada para conectar com o bd
                con.ConnectionString = this.conection;//atribui a váriavel com o endereço do bd para a variável q conecta ao banco
                con.Open();//comando para abrir o banco
                return con;
            }
            catch
            {
                Console.WriteLine("Não conectado");
                return null;
            }
        }

        private void FechaBanco(SqlConnection con)
        {
            if (con.State == ConnectionState.Open)//verifica se o bd está aberto
            {
                con.Close();//comando para fechar bd
            }
        }

        public SqlDataReader RetornaDataSet(string strQuery)//função para retornar um obj do bd
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con = AbreBanco();
                SqlCommand cmdComando = new SqlCommand();//declara uma string de comando
                cmdComando.CommandText = strQuery;//variavel strQuery possui um comando sql
                cmdComando.CommandType = CommandType.Text;//define o comando como um texto
                cmdComando.Connection = con;
                return cmdComando.ExecuteReader();//retorna os resultados do bd para strQuery
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void ExecutaComando(string sqlcmd) // função q executa comando no banco sem gerar retorno
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con = AbreBanco();
                SqlCommand cmdComando = new SqlCommand();
                cmdComando.CommandText = sqlcmd;
                cmdComando.CommandType = CommandType.Text;
                cmdComando.Connection = con;
                cmdComando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
