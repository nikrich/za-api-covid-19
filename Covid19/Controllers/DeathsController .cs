using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Covid19.Interfaces;
using Covid19.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Covid19.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any)]
    public class DeathsController : ControllerBase
    {
        private readonly IDeathsService _deathsService;
        private readonly ILogger<CasesController> _logger;

        public DeathsController(IDeathsService deathsService, ILogger<CasesController> logger)
        {
            _deathsService = deathsService;
            _logger = logger;
        }

        [HttpGet]
        [Route("getall")]
        public async Task<ActionResult<List<DeathsModel>>> GetAll()
        {
            var result = await _deathsService.GetAll();
            return Ok(result);
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<ActionResult<DeathsModel>> Get(int id)
        {
            var result = await _deathsService.GetById(id);
            return Ok(result);
        }
    }
}
