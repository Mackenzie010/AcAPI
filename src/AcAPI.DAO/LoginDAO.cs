using AcAPI.DTL;
using Microsoft.Data.SqlClient;

namespace AcAPI.DAO
{
    public class LoginDAO : ILoginDAO
    {
        private string connString = "Data Source=FERNANDACAMPOS;Initial Catalog=AC_2;Integrated Security=True; TrustServerCertificate=True";

        private readonly List<LoginDTO> _login;
        public LoginDAO()
        {
            _login = new List<LoginDTO>();
        }



        public bool Login(string Email, string Password)
        {
            bool flUsuarioEncontrado = false;
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();

                string query = $"SELECT CASE WHEN EMAIL = @EMAIL and SENHA = @SENHA THEN 1 ELSE 0 END AS FlUsuarioEncontrado FROM USUARIO_API";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@EMAIL", Email);
                    cmd.Parameters.AddWithValue("@SENHA", Password);


                    cmd.CommandType = System.Data.CommandType.Text;
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        flUsuarioEncontrado = Convert.ToBoolean(rdr["FlUsuarioEncontrado"]);
                    }

                    con.Close();
                }
            }

            return flUsuarioEncontrado;
        }
    }
}
