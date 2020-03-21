﻿using System;
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
    public class TestsController : ControllerBase
    {
        private readonly ITestsService _testsService;
        private readonly ILogger<CasesController> _logger;

        public TestsController(ITestsService testsService, ILogger<CasesController> logger)
        {
            _testsService = testsService;
            _logger = logger;
        }

        [HttpGet]
        [Route("getall")]
        public async Task<ActionResult<List<CaseModel>>> GetAll()
        {
            var result = await _testsService.GetAll();
            return Ok(result);
        }
    }
}