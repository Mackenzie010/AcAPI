using Amazon.Runtime;
using Google.Protobuf.WellKnownTypes;
using MongoDB.Bson.IO;
using Org.BouncyCastle.Asn1.Crmf;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AcAPI.DAL
{
    public class RickDAO : IRickDAO
    {

        public async Task<string> get() 
        {
            var servico = new RestClient("https://reqres.in/");

            var pedido = new RestRequest($"/api/users?page=2",RestSharp.Method.Get)
            {
                RequestFormat = DataFormat.Json,
                Timeout = -1
            };


            var oRetornoApi = servico.Execute(pedido).Content;
            return oRetornoApi;
        }

        public async Task<string> put()
        {
            var servico = new RestClient("https://reqres.in/");

            var pedido = new RestRequest($"/api/users/2", RestSharp.Method.Put)
            {
                RequestFormat = DataFormat.Json,
                Timeout = -1
            };

            pedido.AddBody(new
            {
                name = "morpheus",
                job = "leader"
            });


            var oRetornoApi = servico.Execute(pedido).Content;
            return oRetornoApi;
        }
    }
}
