using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Covid19.Interfaces;
using Covid19.Models;
using Covid19.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Covid19.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ResponseCache(Duration = 300, Location = ResponseCacheLocation.Any)]
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

            if (string.IsNullOrWhiteSpace(province))
                result = await _casesService.GetAll();
            else
                result = await _casesService.GetAllForProvince(province);

            return Ok(result);
        }

        [HttpGet]
        [Route("getallperday")]
        public async Task<ActionResult<List<CountModel>>> GetAllPerDay([FromQuery]string province)
        {
            List<CaseModel> result = new List<CaseModel>();

            if (string.IsNullOrWhiteSpace(province))
                result = await _casesService.GetAll();
            else
                result = await _casesService.GetAllForProvince(province);

            var groupedResult = result.GroupBy(x => x.Date)
                .Select(x => new CountModel
                {
                    CasesTotal = x.Count(),
                    Date = x.Key
                });

            return Ok(groupedResult);
        }

        [HttpGet]
        [Route("getdayaggregate")]
        public async Task<ActionResult<List<CountModel>>> GetAllPerDayAggregate([FromQuery]string province)
        {
            var result = await _casesService.GetCumulative();

            if (string.IsNullOrWhiteSpace(province))
                return Ok(CumulativeUtility.GetCumulative(result));
            else
                return Ok(CumulativeUtility.GetCumulativeForProvince(result, province));
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
        public async Task<ActionResult<CountModel>> GetTotal([FromQuery]string province)
        {
            var result = await _casesService.GetCumulative();

            if (result == null)
                return Ok(new CountModel { CasesTotal = Int32.MinValue, Date = DateTime.Now });

            if (!string.IsNullOrWhiteSpace(province))
                return Ok(new CountModel
                {
                    CasesTotal = CumulativeUtility.GetTotalForProvince(result, province),
                    Date = DateTime.Now
                });
            else
                return Ok(new CountModel
                {
                    CasesTotal = CumulativeUtility.GetTotal(result),
                    Date = result.Last().Date
                });



        }

        [HttpGet]
        [Route("getavgage")]
        public async Task<ActionResult<AvgAgeModel>> GetAvgAge([FromQuery]string province)
        {
            List<CaseModel> result = new List<CaseModel>();

            if (string.IsNullOrWhiteSpace(province))
                result = await _casesService.GetAll();
            else
                result = await _casesService.GetAllForProvince(province);

            if (result == null)
                return Ok(new AvgAgeModel { Age = Int32.MinValue, Date = DateTime.Now });

            return Ok(new AvgAgeModel { Age = Math.Round(result.Where(x => x.Age != 0).Average(x => x.Age)), Date = DateTime.Now });
        }

        [HttpGet]
        [Route("getlatestupdate")]
        public async Task<ActionResult<CountModel>> GetLatestUpdate()
        {
            var result = await _casesService.GetCumulative();

            if (result == null)
                return Ok(new CountModel());

            return CumulativeUtility.GetLatest(result);           
        }
    }
}
