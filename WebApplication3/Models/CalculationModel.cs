using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class CalculationModel
    {
        public decimal FirstNumber { get; set; }
        public decimal SecondNumber { get; set; }
        public decimal Result { get; set; }
        public CalculationMethod calculationMethod { get; set; }
    }
    public enum CalculationMethod
    {
        Addition = '+',
        Subtraction = '-',
        Multiplication = '*',
        Division = '/'
    }
}
