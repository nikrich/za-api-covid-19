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
    [Route("[controller]")]
    public class CasesController : ControllerBase
    {
        private readonly ICasesService _casesService;
        private readonly ILogger<CasesController> _logger;

        public CasesController(ICasesService casesService, ILogger<CasesController> logger)
        {
            _casesService = casesService;
            _logger = logger;
        }

        [HttpGet]
        [Route("getall")]
        public async Task<ActionResult<List<CaseModel>>> GetAll()
        {
            var result = await _casesService.GetAll();
            return Ok(result);
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<ActionResult<List<CaseModel>>> Get(int id)
        {
            var result = await _casesService.GetById(id);
            return Ok(result);
        }
    }
}
