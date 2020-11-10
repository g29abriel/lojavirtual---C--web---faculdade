using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace lojavirtual
{
    public class conexao
    {
        private static string StringConexao = "SERVER=localhost;DATABASE=lojavirtual;UID=root;PASSWORD=''";
        private static MySqlConnection MinhaConexao = new MySqlConnection(StringConexao);

        private static string AbrirConexao()
        {
            string retorno = "Sucesso";
            try
            {
                MinhaConexao.Open();
            }
            catch (MySqlException e)
            {
                retorno = "Falha na abertura da conexão - " + e.Message;
            }
            return retorno;

        }

        private static string FecharConexao()
        {
            string retorno = "Sucesso";
            try
            {
                MinhaConexao.Close();
            }
            catch (MySqlException e)
            {
                retorno = "Falha no fechamento da conexão - " + e.Message;
            }
            return retorno;
        }

        /// <summary>
        /// Método que realiza operações de modificação em uma tabela (INSERT, UPDATE, DELETE)
        /// </summary>
        /// <param name="query">Consulta SQL a ser enviada ao banco de dados</param>
        public static void ModificarTabela(string query)
        {
            AbrirConexao();
            MySqlCommand comando = new MySqlCommand(query, MinhaConexao);
            comando.ExecuteNonQuery();
            FecharConexao();
        }

        /// <summary>
        /// Método para recuperar dados do banco (SELECT)
        /// </summary>
        /// <param name="query">consulta sql</param>
        /// <returns></returns>
        public static DataTable RecuperarDados(string query)
        {
            DataTable dt = new DataTable();
            AbrirConexao();
            MySqlCommand comando = new MySqlCommand(query, MinhaConexao);
            MySqlDataReader dataReader = comando.ExecuteReader();
            dt.Load(dataReader);
            FecharConexao();

            return dt;
        }
    }
}