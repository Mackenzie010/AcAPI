using AcAPI.DTL;
using RestSharp;
using System.Text.Json;

namespace AcAPI.DAL
{
    public class RickDAO : IRickDAO
    {

        public async Task<string> post(string boleto, int user_id)
        {
            var servico = new RestClient("https://api-go-wash-efc9c9582687.herokuapp.com");

            var pedido = new RestRequest("/api/pay-boleto", RestSharp.Method.Post)
            {
                RequestFormat = DataFormat.Json,
                Timeout = -1
            };

            pedido.AddHeader("Authorization", "Vf9WSyYqnwxXODjiExToZCT9ByWb3FVsjr");
            pedido.AddHeader("Content-Type", "application/json");
            pedido.AddHeader("Cookie", "gowash_session=m6Y5t4HwextNyZIPR4uCOD97ebOoYusUfmRMwt06");

            pedido.AddJsonBody(new
            {
                boleto = boleto,
                user_id = user_id
            });

            var response = await servico.ExecuteAsync(pedido);
             
            var objeto = JsonSerializer.Deserialize<DataTeste>(response.Content);
            if (objeto.data.status == "approved")
            {
                return "Marcação de Lab feita com sucesso";
            }
            else
            {
                return "Erro";
            }
        }
    }
}
