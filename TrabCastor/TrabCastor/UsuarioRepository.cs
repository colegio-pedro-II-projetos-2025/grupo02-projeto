using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace TrabCastor
{
    internal class UsuarioRepository
    {
        private readonly string _connectionString;

        public UsuarioRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public Usuario ObterPorEmailESenha(string email, string senha)
        {
            try
            {
                Usuario usuario = null;
                using (var connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    string hashSenha = HashUtil.GerarHashSha256(senha);
                    string query = "SELECT email_responsavel, nome, senha FROM usuario WHERE email_responsavel = @Email AND senha = @Senha";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Senha", hashSenha);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Usuario
                                {
                                    Email_Responsavel = reader.GetString("email_responsavel"),
                                    Nome = reader.GetString("nome"),
                                    Senha = reader.GetString("senha")
                                };
                            }
                        }
                    }
                }
                return usuario;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public int InserirUsuario(Usuario usuario)
        {
            int linhasAfetadas = -1;
            using (var connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO usuario (email_responsavel, nome, senha) VALUES (@Email, @Username, @Senha)";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        string hashSenha = HashUtil.GerarHashSha256(usuario.Senha);
                        command.Parameters.AddWithValue("@Email", usuario.Email_Responsavel);
                        command.Parameters.AddWithValue("@Username", usuario.Nome);
                        command.Parameters.AddWithValue("@Senha", hashSenha);
                        linhasAfetadas = command.ExecuteNonQuery();
                    }

                    return linhasAfetadas;
                }
                catch (Exception ex) 
                {
                    return 0;
                }
                }
        }
    }
}
