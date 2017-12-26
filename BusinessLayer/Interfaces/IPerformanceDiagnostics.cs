using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IPerformanceDiagostics
    {
        Task<IEnumerable<PerformanceModel>> AsyncGetPerformanceModelInRange(int min, int max);
        Task<TimeSpan> GetCallBackTime(string url);
    }
}
