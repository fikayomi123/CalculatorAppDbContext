using CalculatorApp.Service.Implementations;
using CalculatorModel.NewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

namespace CalculatorApp.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculatorServices _calculatorServices;
        public CalculatorController(ICalculatorServices calculatorServices) 
        {
            _calculatorServices = calculatorServices;
        }

        [HttpPost("AdditionModel")]
        public async Task<IActionResult> Addition(AdditionModel model)
        {
            var result = await _calculatorServices.Addition(model);
            return Ok(result);

        }

        [HttpPost("SubtractionModel")]
        public async Task<IActionResult> Subtraction(SubtractionModel model) 
        {
            var result = await _calculatorServices.Subtraction(model);
            return Ok(result);
        }

        [HttpPost("DivisionModel")]
        public async Task<IActionResult> Division(DivisionModel model)
        {
            var result = await _calculatorServices.Division(model);
            return Ok(result);
        }

        [HttpPost("MultiplicationModel")]
        public async Task<IActionResult> Multiplication(MultiplicationModel model)
        {
            var result = await _calculatorServices.Multiplication(model);
            return Ok(result);
        }

        [HttpPost("AreaOfRectangleModel")]
        public async Task<IActionResult> Area(AreaOfRectangleModel model) 
        {
            var result = await _calculatorServices.Area(model);
            return Ok(result);
        }

        [HttpPost("VolumeOfCubeModel")]
        public async Task<IActionResult> Volume(VolumeofCubeModel model)
        {
            var result = await _calculatorServices.Volume(model);
            return Ok(result);
        }

        [HttpPost("AccelerationModel")]
        public async Task<IActionResult> Acceleration(AccelerationModel model)
        {
            var result = await _calculatorServices.Acceleration(model);
            return Ok(result);
        }

        [HttpPost("WeightOfOblectModel")]
        public async Task<IActionResult> Weight(WeightOfObjectModel model)
        {
            var result = await _calculatorServices.Weight(model);
            return Ok(result);
        }

        [HttpPost("SquareRootModel")]
        public async Task<IActionResult> SquareRoot(SquareRootModel model)
        {
            var result = await _calculatorServices.SquareRoot(model);
            return Ok(result);
        }
         [HttpPost("RaiseToPowerModel")]
         public async Task<IActionResult> RaiseToPower(RaiseToPowerModel model)
        {
            var result = await _calculatorServices.Expodential(model);
            return Ok(result);
        }
        [HttpPost ("DensityOfObjectModel")]
        public async Task<IActionResult> Density(DensityOfObjectModel model) 
        {
            var result = await _calculatorServices.Density(model);
            return Ok(result);
        }
        [HttpPost ("PercentageModel")]
        public async Task<IActionResult> Percentage(PercentageModel model)
        {
            var result = await _calculatorServices.Percentage(model);
            return Ok(result);
        }
        [HttpPost ("GetHistory")]
        public async Task<IActionResult> GetHistory()
        {
            var result = await _calculatorServices.GetHistory();
            return Ok(result);
        }
    }   
}
