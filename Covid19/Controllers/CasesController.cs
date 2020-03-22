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
        public async Task<ActionResult<List<CaseModel>>> GetAll([FromQuery]string province)
        {
            List<CaseModel> result = new List<CaseModel>();

            if(string.IsNullOrWhiteSpace(province)) 
                result = await _casesService.GetAll();
            else
                result = await _casesService.GetAllForProvince(province);

            return Ok(result);
        }

        [HttpGet]
        [Route("getallperday")]
        public async Task<ActionResult<List<CaseCountModel>>> GetAllPerDay([FromQuery]string province)
        {
            List<CaseModel> result = new List<CaseModel>();

            if (string.IsNullOrWhiteSpace(province))
                result = await _casesService.GetAll();
            else
                result = await _casesService.GetAllForProvince(province);

            var groupedResult = result.GroupBy(x => x.Date)
                .Select(x => new CaseCountModel
                {
                    CasesTotal = x.Count(),
                    Date = x.Key
                });

            return Ok(groupedResult);
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<ActionResult<CaseModel>> Get(int id)
        {
            var result = await _casesService.GetById(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("getcount")]
        public async Task<ActionResult<CaseCountModel>> GetTotal([FromQuery]string province)
        {
            List<CaseModel> result = new List<CaseModel>();

            if (string.IsNullOrWhiteSpace(province))
                result = await _casesService.GetAll();
            else
                result = await _casesService.GetAllForProvince(province);
           

            if (result == null)
                return Ok(new CaseCountModel { CasesTotal = Int32.MinValue, Date = DateTime.Now });

            return Ok(new CaseCountModel { CasesTotal = result.Count, Date = DateTime.Now });
        }
    }
}
