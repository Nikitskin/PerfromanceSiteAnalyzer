using System;
using System.Collections.Generic;
using DataLayer.Models;

namespace DataLayer
{
    //todo please move this to some DB 
    public class Store : IStore
    {
        private IEnumerable<PerformanceResultDataModel> _performanceResultDataModels;

        public IEnumerable<PerformanceResultDataModel> PerformanceResultDataModels => _performanceResultDataModels ?? new List<PerformanceResultDataModel>();
    }
}
