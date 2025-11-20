using Microsoft.Extensions.Configuration;
using Modelo.Aplication.Interface;
using Modelo.Domain;
using System.Text.Json;

namespace Modelo.Aplication
{
    public class CepService : ICepService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public CepService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }


        public async Task<Endereco?> BuscarfEnderecoPorCep(string cep) 
        {
            try
            {
                cep = cep.Replace("-", "").Replace(".", "").Replace(" ", "");
                string url = _configuration["ApiCep:BaseUrl"].Replace("00000000", cep);

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode == false)
                {
                    throw new ApplicationException("Retorno da Api invalido!");
                }

                var json = await response.Content.ReadAsStringAsync();
                var doc = JsonDocument.Parse(json);
                var ops = new JsonSerializerOptions();
                ops.PropertyNameCaseInsensitive = true;
                var endereco = doc.Deserialize<Endereco>(ops);
                return endereco;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
