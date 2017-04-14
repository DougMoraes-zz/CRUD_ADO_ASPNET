using BibliotecaASPNET.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BibliotecaASPNET.Repository
{
    public class LivroRepository
    {
        private SqlConnection _con;

        private void Connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["stringConexao"].ToString();

            _con =  new SqlConnection(constr);
        }

        //add livro

        public bool AdicionarLivro(Livro livroObj)
        {
            Connection();

            int i;

            using (SqlCommand conn = new SqlCommand("IncluirLivro", _con))
            {
                conn.CommandType = CommandType.StoredProcedure;
                conn.Parameters.AddWithValue("@LivroTitulo", livroObj.LivroTitulo);
                conn.Parameters.AddWithValue("@LivroAutor", livroObj.LivroAutor);
                conn.Parameters.AddWithValue("@LivroEditora", livroObj.LivroEditora);
                conn.Parameters.AddWithValue("@LivroAno", livroObj.LivroAno);

                _con.Open();

                i = conn.ExecuteNonQuery();
            }

            _con.Close();

            return i >= 1;
        }

        // retorna listra com todos os livros

        public List<Livro> ListarLivros()
        {
            Connection();
            List<Livro> livrosList = new List<Livro>();

            using (SqlCommand conn = new SqlCommand("ListarLivro", _con))
            {
                conn.CommandType = CommandType.StoredProcedure;

                _con.Open();

                SqlDataReader reader = conn.ExecuteReader();

                while (reader.Read())
                {
                    Livro livro = new Livro()
                    {
                        LivroId = Convert.ToInt32(reader["LivroId"]),
                        LivroTitulo = Convert.ToString(reader["LivroTitulo"]),
                        LivroAutor = Convert.ToString(reader["LivroAutor"]),
                        LivroEditora = Convert.ToString(reader["LivroEditora"]),
                        LivroAno = Convert.ToInt32(reader["LivroAno"])
                    };

                    livrosList.Add(livro);

                }

                _con.Close();

                return livrosList;
            }
        }

        //Editar livro

        public bool EditarLivro(Livro livroObj)
        {
            Connection();

            int i;

            using (SqlCommand conn = new SqlCommand("EditarLivro", _con))
            {
                conn.CommandType = CommandType.StoredProcedure;
                conn.Parameters.AddWithValue("@LivroId", livroObj.LivroId);
                conn.Parameters.AddWithValue("@LivroTitulo", livroObj.LivroTitulo);
                conn.Parameters.AddWithValue("@LivroAutor", livroObj.LivroAutor);
                conn.Parameters.AddWithValue("@LivroEditora", livroObj.LivroEditora);
                conn.Parameters.AddWithValue("@LivroAno", livroObj.LivroAno);

                _con.Open();

                i = conn.ExecuteNonQuery();
            }

            _con.Close();

            return i >= 1;
        }

        //Excluir Livro

        public bool ExcluirLivro(int id)
        {
            Connection();

            int i;

            using (SqlCommand conn = new SqlCommand("ExcluirLivroPorId", _con))
            {
                conn.CommandType = CommandType.StoredProcedure;
                conn.Parameters.AddWithValue("@LivroId", id);

                _con.Open();

                i = conn.ExecuteNonQuery();
            }

            _con.Close();

            if (i >= 1)
            {
                return true;
            }

            return false;
        }
    }
}