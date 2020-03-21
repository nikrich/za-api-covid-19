using Covid19.Extenstions;
using Covid19.Interfaces;
using Covid19.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Covid19.Services
{
    public class DeathsService : IDeathsService
    {
        private readonly IHttpClientFactory _clientFactory;

        public DeathsService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<List<DeathsModel>> GetAll()
        {
            var client = _clientFactory.CreateClient("CovidClient");

            var request = new HttpRequestMessage(HttpMethod.Get,
            "dsfsi/covid19za/master/data/covid19za_timeline_deaths.csv");

            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
                throw new Exception("Invalid Response from data endpoint for Cases");

            var result = await response.Content.ReadAsStringAsync();

            return result.MapDeathsList();
        }

        public async Task<DeathsModel> GetById(int caseId)
        {
            var cases = await GetAll();
            return cases.Where(x => x.CaseId == caseId).FirstOrDefault();
        }
    }
}
