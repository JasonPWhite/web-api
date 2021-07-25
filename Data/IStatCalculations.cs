using System.Collections.Generic;
using System.Threading.Tasks;
using web_api.Models;

namespace web_api.Data
{
    public interface IStatCalculations
    {
        double CalculateMean();
        double CalculateStdDev();
        string CalculateFrequencies();
    }

}