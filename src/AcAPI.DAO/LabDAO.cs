using AcAPI.DTL;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace AcAPI.DAO
{
    public class LabDAO : ILabDAO
    {
        
        //private string connString = "Data Source=FERNANDACAMPOS;Initial Catalog=AC_2;Integrated Security=True; TrustServerCertificate=True";
        private string connString = "Server=db4free.net;Database=acapi10;Uid=felipemack;Pwd=Gavioesdafiel04";

        private readonly string _cn;
        public LabDAO(IConfiguration configuration)
        {

            //_cn = ConfigurationExtensions.GetConnectionString(configuration, "AC_2");
        }

        private readonly List<LabDTO> _lab;
        public LabDAO()
        {
            _lab = new List<LabDTO>();
        }

        public List<LabDTO> Listar()
        {
            List<LabDTO> MarcacaoLab = new List<LabDTO>();
            

            using (MySqlConnection connection = new  MySqlConnection(connString))
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * from LAB_API", connection);
                cmd.CommandType = System.Data.CommandType.Text;
                connection.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    LabDTO lab = new LabDTO
                    {
                        Id = Convert.ToInt32(rdr["ID"]),
                        Dt_Cadastro = DateOnly.FromDateTime(Convert.ToDateTime(rdr["DT_CADASTRO"])),
                        Lab = rdr["LAB"].ToString(),
                        Descricao = rdr["DESCRICAO"].ToString(),
                        Andar = Convert.ToInt32(rdr["ANDAR"]),
                        Ativo = Convert.ToBoolean(rdr["ATIVO"]),
                    };

                    MarcacaoLab.Add(lab);
                }
                connection.Close();
            }
            return MarcacaoLab;
        }

        public void Incluir(LabDTO lab)
        {
            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                connection.Open();
                string query = ("INSERT INTO LAB_API ( DT_CADASTRO, ANDAR, LAB, DESCRICAO , ATIVO) VALUES ( @DT_CADASTRO, @ANDAR, @LAB, @DESCRICAO, @ATIVO)");
                using (MySqlCommand command = new MySqlCommand(query, connection))

                {
                    command.Parameters.AddWithValue("@DT_CADASTRO", lab.Dt_Cadastro);
                    command.Parameters.AddWithValue("@ANDAR", lab.Andar);
                    command.Parameters.AddWithValue("@LAB", lab.Lab);
                    command.Parameters.AddWithValue("@DESCRICAO", lab.Descricao);
                    command.Parameters.AddWithValue("@ATIVO", lab.Ativo);
                   
                    command.ExecuteNonQuery();
                    
                }
                connection.Close();
            }
        }
        public void Excluir(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                connection.Open();
                string query = $"DELETE FROM LAB_API where Id = {id}";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                   
                    command.ExecuteNonQuery();
                    
                }
                connection.Close();
            }          
        }
        public void Atualizar(LabDTO lab)
        {
            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                connection.Open();
                string query = "UPDATE LAB_API SET DT_CADASTRO = @DT_CADASTRO, ANDAR = @ANDAR, LAB = @LAB, DESCRICAO = @DESCRICAO, ATIVO = @ATIVO WHERE ID = @ID";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", lab.Id);
                    command.Parameters.AddWithValue("@DT_CADASTRO", lab.Dt_Cadastro);
                    command.Parameters.AddWithValue("@ANDAR", lab.Andar);
                    command.Parameters.AddWithValue("@LAB", lab.Lab);
                    command.Parameters.AddWithValue("@DESCRICAO", lab.Descricao);
                    command.Parameters.AddWithValue("@ATIVO", lab.Ativo);

                    command.ExecuteNonQuery();
                }
                connection.Close();
            }

        }
        public LabDTO ListarPorID(int id)
        {
            LabDTO lab = null;
            using (MySqlConnection con = new MySqlConnection(connString))
            {
                con.Open();

                string query = "SELECT * FROM LAB_API WHERE ID = @ID";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                  

                    cmd.CommandType = System.Data.CommandType.Text;
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        lab = new LabDTO
                        {
                            Id = Convert.ToInt32(rdr["ID"]),
                            Dt_Cadastro = DateOnly.FromDateTime(Convert.ToDateTime(rdr["DT_CADASTRO"])),
                            Lab = rdr["LAB"].ToString(),
                            Descricao = rdr["DESCRICAO"].ToString(),
                            Andar = Convert.ToInt32(rdr["ANDAR"]),
                            Ativo = Convert.ToBoolean(rdr["ATIVO"]),
                        };
                    }
                    con.Close();
                }
            }
            return lab;
        }
        public void Ativar(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                connection.Open();
                string query = "UPDATE LAB_API SET ATIVO = 1 WHERE ID = @ID";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);

                    command.ExecuteNonQuery();
                }
                connection.Close();
            }

        }
        public void Inativar(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                connection.Open();
                string query = "UPDATE LAB_API SET ATIVO = 0 WHERE ID = @ID";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);

                    command.ExecuteNonQuery();
                }
                connection.Close();
            }

        }
    }
}


