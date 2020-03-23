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
    [ResponseCache(Duration = 1800, Location = ResponseCacheLocation.Any)]
    public class HospitalsController : ControllerBase
    {
        private readonly IHospitalsPublicService _publicService;
        private readonly IHospitalsPrivateService _privateService;
        private readonly ILogger<CasesController> _logger;

        public HospitalsController(IHospitalsPublicService publicService, IHospitalsPrivateService privateService, ILogger<CasesController> logger)
        {
            _publicService = publicService;
            _privateService = privateService;
            _logger = logger;
        }

        [HttpGet]
        [Route("public/getall")]
        public async Task<ActionResult<List<HospitalsPublicModel>>> GetAllPublic()
        {
            var result = await _publicService.GetAll();
            return Ok(result);
        }

        [HttpGet]
        [Route("private/getall")]
        public async Task<ActionResult<List<HospitalsPrivateModel>>> GetAllPrivate()
        {
            var result = await _privateService.GetAll();
            return Ok(result);
        }
    }
}
