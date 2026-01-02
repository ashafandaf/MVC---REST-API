using PerpustakaanAppMVC.Model.Entity;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerpustakaanAppMVC.Model.Repository
{
    public class MahasiswaRestApiRepository
    {

        private readonly string _baseUrl = "http://latihan.coding4ever.net:5555/";

        /* =======================
           READ ALL (Latihan 3)
           ======================= */
        public List<Mahasiswa> ReadAll()
        {
            var client = new RestClient(_baseUrl);
            var request = new RestRequest("api/mahasiswa", Method.GET);

            var response = client.Execute<List<Mahasiswa>>(request);
            return response.Data;
        }

        /* =======================
           READ BY NAMA (Latihan 4)
           ======================= */
        public List<Mahasiswa> ReadByNama(string nama)
        {
            var client = new RestClient(_baseUrl);
            var request = new RestRequest("api/mahasiswa", Method.GET);
            request.AddParameter("nama", nama);

            var response = client.Execute<List<Mahasiswa>>(request);
            return response.Data;
        }

        /* =======================
           CREATE (Latihan 5)
           ======================= */
        public bool Create(Mahasiswa mhs)
        {
            var client = new RestClient(_baseUrl);
            var request = new RestRequest("api/mahasiswa", Method.POST);
            request.AddJsonBody(mhs);

            var response = client.Execute(request);
            return response.IsSuccessful;
        }

        /* =======================
           UPDATE
           ======================= */
        public bool Update(Mahasiswa mhs)
        {
            var client = new RestClient(_baseUrl);
            var request = new RestRequest($"api/mahasiswa/{mhs.Npm}", Method.PUT);
            request.AddJsonBody(mhs);

            var response = client.Execute(request);
            return response.IsSuccessful;
        }

        /* =======================
           DELETE
           ======================= */
        public bool Delete(string nim)
        {
            var client = new RestClient(_baseUrl);
            var request = new RestRequest($"api/mahasiswa/{nim}", Method.DELETE);

            var response = client.Execute(request);
            return response.IsSuccessful;
        }


    }
}
    
