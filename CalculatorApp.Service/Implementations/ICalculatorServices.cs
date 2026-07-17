using CalculatorModel.NewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorApp.Service.Implementations
{
    public interface ICalculatorServices
    {
        Task<double> Addition(AdditionModel model);
        Task<double> Subtraction(SubtractionModel model);
        Task<double> Acceleration(AccelerationModel model);
        Task<double> Division(DivisionModel model);
        Task<double> Multiplication(MultiplicationModel model);
        Task<double> Area(AreaOfRectangleModel model);
        Task<double> Volume(VolumeofCubeModel model);
        Task<double> Weight(WeightOfObjectModel model);
        Task<double> SquareRoot(SquareRootModel model);
        Task<double> Expodential(RaiseToPowerModel model);
        Task<double> Density(DensityOfObjectModel model);
        Task<double> Percentage(PercentageModel model);
        Task<List<CalculationHistoryModel>> GetHistory();


    }
}
