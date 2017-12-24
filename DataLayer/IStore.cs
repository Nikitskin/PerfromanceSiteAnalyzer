using System.Collections.Generic;
using DataLayer.Models;

namespace DataLayer
{
    public interface IStore
    {
        IEnumerable<PerformanceResultDataModel> PerformanceResultDataModels { get; }
    }
}
