using CalculatorMigrations;
using CalculatorModel.Enitiy;
using CalculatorModel.NewModel;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorApp.Service.Implementations
{ 
    public class CalculatorServices : ICalculatorServices
    {
        private readonly CalculatorAppDbContex _dbContext;
        public CalculatorServices(CalculatorAppDbContex dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<double> Addition(AdditionModel model)
        {
            var formula = model.NumberA + model.NumberB;
            var history = new CalculatorHistory
            {
                DataPerformed = DateTime.UtcNow,
                Action = "Addition",
                Answer = formula.ToString()
            };
            _dbContext.Calculator.Add(history);
            await _dbContext.SaveChangesAsync();
            return formula;

        }
        public async Task<double> Subtraction(SubtractionModel model)
        {
            var formula = model.NumberA - model.NumberB;
            var history = new CalculatorHistory
            {
                DataPerformed = DateTime.UtcNow,
                Action = "Subtraction",
                Answer = formula.ToString()
            };
            _dbContext.Calculator.Add(history);
            await _dbContext.SaveChangesAsync();
            return formula;
        }
        public async Task<double> Acceleration(AccelerationModel model)
        {
            var formula = model.Velocity / model.Time;
            var history = new CalculatorHistory
            {
                DataPerformed = DateTime.UtcNow,
                Action = "Acceleration",
                Answer = formula.ToString()
            };
            _dbContext.Calculator.Add(history);
            await _dbContext.SaveChangesAsync();
            return formula;
        }
        public async Task<double> Division(DivisionModel model)
        {
            var formula = model.NumberA / model.NumberB;
            var history = new CalculatorHistory
            {
                DataPerformed = DateTime.UtcNow,
                Action = "Division",
                Answer = formula.ToString()
            };
            _dbContext.Calculator.Add(history);
            await _dbContext.SaveChangesAsync();
            return formula;
        }
        public async Task<double> Multiplication(MultiplicationModel model)
        {
            var formula = model.NumberA * model.NumberB;
            var history = new CalculatorHistory

            {
                DataPerformed = DateTime.UtcNow,
                Action = "Multiplication",
                Answer = formula.ToString()
            };



            _dbContext.Calculator.Add(history);
            await _dbContext.SaveChangesAsync();
            return formula;

        }
        public async Task<double> Area(AreaOfRectangleModel model)
        {
            var formula = model.NumberA * model.NumberB;
            var history = new CalculatorHistory
            {
                DataPerformed = DateTime.UtcNow,
                Action = "Area",
                Answer = formula.ToString()
            };
            _dbContext.Calculator.Add(history);
            await _dbContext.SaveChangesAsync();
            return formula;

        }
        public async Task<double> Volume(VolumeofCubeModel model)
        {
            var formula = model.NumberA * model.NumberB;
            var history = new CalculatorHistory
            {
                DataPerformed = DateTime.UtcNow,
                Action = "Volume",
                Answer = formula.ToString(),
            };
            _dbContext.Calculator.Add(history);
            await _dbContext.SaveChangesAsync();
            return formula;
        }
        public async Task<double> Weight(WeightOfObjectModel model)
        {
            var formula = model.Mass * model.AccelerationDG ;
            var history = new CalculatorHistory
            {
                DataPerformed = DateTime.UtcNow,
                Action = "Weight",
                Answer = formula.ToString(),
            };
            _dbContext.Calculator.Add(history);
            await _dbContext.SaveChangesAsync();
            return formula;
        }
       public async Task<double> SquareRoot(SquareRootModel model)
        {
            var formula = Math.Sqrt(model.NumberA);
            var history = new CalculatorHistory
            {
                DataPerformed = DateTime.UtcNow,
                Action = "SquareRoot",
                Answer = formula.ToString(),

            };
            _dbContext.Calculator.Add(history);
            await _dbContext.SaveChangesAsync();
            return formula;
        }
        public async Task<double> Expodential(RaiseToPowerModel model)
        {
            var formula = Math.Pow(model.NumberA, model.NumberB);
            var history = new CalculatorHistory
            {
                DataPerformed = DateTime.UtcNow,
                Action = "Expodential",
                Answer = formula.ToString(),
            };
            _dbContext.Calculator.Add(history);
            await _dbContext.SaveChangesAsync();
            return formula;
        }
        public async Task<double> Density(DensityOfObjectModel model)
        {

            var formula = model.Mass / model.Volume;
            var history = new CalculatorHistory
            {
                DataPerformed = DateTime.UtcNow,
                Action = "Density",
                Answer = formula.ToString()
            };
            _dbContext.Calculator.Add(history);
            await _dbContext.SaveChangesAsync();
            return formula;
        }
        public async Task<double> Percentage(PercentageModel model)
        {
            var formula = (model.NumberA / 100);
            var history = new CalculatorHistory
            {
                DataPerformed = DateTime.UtcNow,
                Action = "Percentage",
                Answer = formula.ToString()
            };
            _dbContext.Calculator.Add(history);
            await _dbContext.SaveChangesAsync();
            return formula;
        }
        public async Task<List<CalculationHistoryModel>> GetHistory()
        {
            try
            {
                var user = _dbContext.Calculator.ToList();
                var CalculationList = new List<CalculationHistoryModel>();

                foreach (var item in user)
                {
                    CalculationHistoryModel history = new CalculationHistoryModel()
                    {
                        Action = item.Action,
                        DataPerformed = item.DataPerformed,
                        Answer = item.Answer,
                    };
                    CalculationList.Add(history);
                }
                ;
                return CalculationList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }    
}
