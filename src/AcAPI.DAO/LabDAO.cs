using AcAPI.DTL;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace AcAPI.DAO
{
    public class LabDAO : ILabDAO
    {
        
        private string connString = "Data Source=FERNANDACAMPOS;Initial Catalog=AC_2;Integrated Security=True; TrustServerCertificate=True";

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
            

            using (SqlConnection connection = new  SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * from LAB_API", connection);
                cmd.CommandType = System.Data.CommandType.Text;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

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
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                string query = ("INSERT INTO LAB_API ( DT_CADASTRO, ANDAR, LAB, DESCRICAO , ATIVO) VALUES ( @DT_CADASTRO, @ANDAR, @LAB, @DESCRICAO, @ATIVO)");
                using (SqlCommand command = new SqlCommand(query, connection))

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
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                string query = $"DELETE FROM LAB_API where Id = {id}";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                   
                    command.ExecuteNonQuery();
                    
                }
                connection.Close();
            }          
        }
        public void Atualizar(LabDTO lab)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                string query = "UPDATE LAB_API SET DT_CADASTRO = @DT_CADASTRO, ANDAR = @ANDAR, LAB = @LAB, DESCRICAO = @DESCRICAO, ATIVO = @ATIVO WHERE ID = @ID";

                using (SqlCommand command = new SqlCommand(query, connection))
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
        public LabDTO SelecionarLab(int id)
        {
            LabDTO lab = null;
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();

                string query = "SELECT * FROM LAB_API WHERE ID = @ID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                  

                    cmd.CommandType = System.Data.CommandType.Text;
                    SqlDataReader rdr = cmd.ExecuteReader();

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
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                string query = "UPDATE LAB_API SET ATIVO = 1 WHERE ID = @ID";

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
                string query = "UPDATE LAB_API SET ATIVO = 0 WHERE ID = @ID";

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


