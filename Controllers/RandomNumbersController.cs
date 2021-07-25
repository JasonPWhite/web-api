using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using web_api.Data;
using web_api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;


namespace web_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RandomNumbersController : ControllerBase
    {
        private readonly IStatCalculations _calc;
        private double _mean = 0.0;
        private double _stdDev = 0.0;

        private string _freq = "";


        public RandomNumbersController(IStatCalculations calc)
        {
            _calc = calc;
            _mean = _calc.CalculateMean();
            _stdDev =  _calc.CalculateStdDev();
            _freq =  _calc.CalculateFrequencies();
        }


        [HttpGet]
        public IActionResult GetStats()
        {
            
            return Ok("{\"results\" : {\"mean\":" + _mean.ToString() + 
                ", \"standardDeviation\":"  + _stdDev.ToString()  +
                 ", \"frequencies\":"  + _freq.ToString()  +"}}");

        }

    }
}