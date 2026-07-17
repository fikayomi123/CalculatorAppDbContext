using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorModel.Enitiy
{
    public class CalculatorHistory
    {
        public int Id { get; set; }
        public DateTime DataPerformed { get; set; }
        public string Action { get; set; }
        public string Answer { get; set; }
    }
}
