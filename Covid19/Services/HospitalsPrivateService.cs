﻿using Covid19.Extenstions;
using Covid19.Interfaces;
using Covid19.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Covid19.Services
{
    public class HospitalsPrivateService : IHospitalsPrivateService
    {
        private readonly IHttpClientFactory _clientFactory;

        public HospitalsPrivateService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<List<HospitalsPrivateModel>> GetAll()
        {
            var client = _clientFactory.CreateClient("CovidClient");

            var request = new HttpRequestMessage(HttpMethod.Get,
            "nikrich/covid19za/master/data/health_system_za_private_hospitals.csv");

            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
                throw new Exception("Invalid Response from data endpoint for Cases");

            var result = await response.Content.ReadAsStringAsync();

            return result.MapHospitalsPrivateList();
        }
    }
}
