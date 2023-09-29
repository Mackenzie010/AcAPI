using AcAPI.DTL;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace AcAPI.DAO
{
    public class UsuarioDAO : IUsuarioDAO
    {

        private string connString = "Data Source=FERNANDACAMPOS;Initial Catalog=AC_2;Integrated Security=True; TrustServerCertificate=True";

        private readonly string _cn;
        public UsuarioDAO(IConfiguration configuration)
        {

            //_cn = ConfigurationExtensions.GetConnectionString(configuration, "AC_2");
        }

        private readonly List<UsuarioDTO> _usuarios;
        public UsuarioDAO()
        {
            _usuarios = new List<UsuarioDTO>();
        }

        public List<UsuarioDTO> Listar()
        {
            List<UsuarioDTO> MarcacaoLab = new List<UsuarioDTO>();


            using (SqlConnection connection = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * from USUARIO_API", connection);
                cmd.CommandType = System.Data.CommandType.Text;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    UsuarioDTO lab = new UsuarioDTO
                    {
                        Id = Convert.ToInt32(rdr["ID"]),
                        Name = rdr["NOME"].ToString(),
                        Birthday = DateOnly.FromDateTime(Convert.ToDateTime(rdr["DT_NASCIMENTO"])),
                        Email = rdr["EMAIL"].ToString(),
                        Cpf = rdr["CPF"].ToString(),
                        Phone = rdr["TELEFONE"].ToString(),
                        Active = Convert.ToBoolean(rdr["ATIVO"]),
                        Password = rdr["SENHA"].ToString(),
                    };

                    MarcacaoLab.Add(lab);
                }
                connection.Close();
            }
            return MarcacaoLab;
        }

        public void Incluir(UsuarioDTO usuario)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                string query = ("INSERT INTO USUARIO_API ( NOME, DT_NASCIMENTO, EMAIL , CPF, TELEFONE, ATIVO, SENHA) VALUES ( @NOME, @DT_NASCIMENTO, @EMAIL, @CPF, @TELEFONE ,@ATIVO, @SENHA)");
                using (SqlCommand command = new SqlCommand(query, connection))

                {

                    command.Parameters.AddWithValue("@ID", usuario.Id);
                    command.Parameters.AddWithValue("@NOME", usuario.Name);
                    command.Parameters.AddWithValue("@DT_NASCIMENTO", usuario.Birthday);
                    command.Parameters.AddWithValue("@EMAIL", usuario.Email);
                    command.Parameters.AddWithValue("@CPF", usuario.Cpf);
                    command.Parameters.AddWithValue("@TELEFONE", usuario.Phone);
                    command.Parameters.AddWithValue("@ATIVO", usuario.Active);
                    command.Parameters.AddWithValue("@SENHA", usuario.Password);


                    command.ExecuteNonQuery();

                }
                connection.Close();
            }
        }
        public void Excluir(int id)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                string query = $"DELETE FROM USUARIO_API where Id = {id}";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.ExecuteNonQuery();

                }
                connection.Close();
            }
        }
        public void Atualizar(UsuarioDTO usuario)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                string query = "UPDATE USUARIO_API SET NOME = @NOME, DT_NASCIMENTO = @DT_NASCIMENTO, EMAIL = @EMAIL, CPF = @CPF, TELEFONE = @TELEFONE, ATIVO = @ATIVO, SENHA = @SENHA WHERE ID = @ID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", usuario.Id);
                    command.Parameters.AddWithValue("@NOME", usuario.Name);
                    command.Parameters.AddWithValue("@DT_NASCIMENTO", usuario.Birthday);
                    command.Parameters.AddWithValue("@EMAIL", usuario.Email);
                    command.Parameters.AddWithValue("@CPF", usuario.Cpf);
                    command.Parameters.AddWithValue("@TELEFONE", usuario.Phone);
                    command.Parameters.AddWithValue("@ATIVO", usuario.Active);
                    command.Parameters.AddWithValue("@SENHA", usuario.Password);

                    command.ExecuteNonQuery();
                }
                connection.Close();
            }

        }
        public UsuarioDTO Login(string Email, string Password)
        {
            UsuarioDTO usuario = null;
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();

                string query = "SELECT * FROM USUARIO_API WHERE EMAIL = @EMAIL AND SENHA = @SENHA";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@EMAIL", Email);
                    cmd.Parameters.AddWithValue("@SENHA", Password);

                    cmd.CommandType = System.Data.CommandType.Text;
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        usuario = new UsuarioDTO
                        {
                            Id = Convert.ToInt32(rdr["ID"]),
                            Name = rdr["NOME"].ToString(),
                            Birthday = DateOnly.FromDateTime(Convert.ToDateTime(rdr["DT_NASCIMENTO"])),
                            Email = rdr["EMAIL"].ToString(),
                            Cpf = rdr["CPF"].ToString(),
                            Phone = rdr["TELEFONE"].ToString(),
                            Active = Convert.ToBoolean(rdr["ATIVO"]),
                            Password = rdr["SENHA"].ToString(),
                        };
                    }
                    con.Close();
                }
            }
            return usuario;
        }

        public UsuarioDTO SelecionarUsuario(int id)
        {
            UsuarioDTO usuario = null;
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();

                string query = "SELECT * FROM USUARIO_API WHERE ID = @ID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    cmd.CommandType = System.Data.CommandType.Text;
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        usuario = new UsuarioDTO
                        {
                            Id = Convert.ToInt32(rdr["ID"]),
                            Name = rdr["NOME"].ToString(),
                            Birthday = DateOnly.FromDateTime(Convert.ToDateTime(rdr["DT_NASCIMENTO"])),
                            Email = rdr["EMAIL"].ToString(),
                            Cpf = rdr["CPF"].ToString(),
                            Phone = rdr["TELEFONE"].ToString(),
                            Active = Convert.ToBoolean(rdr["ATIVO"]),
                            Password = rdr["SENHA"].ToString(),
                        };
                    }
                    con.Close();
                }
            }
            return usuario;
        }
        public void Ativar(int id)
        { 
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                string query = "UPDATE USUARIO_API SET ATIVO = 1 WHERE ID = @ID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {                 
                    command.Parameters.AddWithValue("@ID", id);
                   
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }

        }
        public void Inativar(int id)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                string query = "UPDATE USUARIO_API SET ATIVO = 0 WHERE ID = @ID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);

                    command.ExecuteNonQuery();
                }
                connection.Close();
            }

        }
    }
}



