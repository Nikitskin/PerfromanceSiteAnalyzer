using System.Collections.Generic;
using DataLayer.Models;

namespace DataLayer
{
    //todo please move this to some DB 
    public static class Store
    {
        //todo remove static when it will be DI
        private static List<PerformanceResultDataModel> _performanceResultDataModels;

        public static List<PerformanceResultDataModel> PerformanceResultDataModels
        {
            get
            {
                if (_performanceResultDataModels == null)
                {
                    _performanceResultDataModels = new List<PerformanceResultDataModel>();
                }
                return _performanceResultDataModels;
            }
        }
    
    }
}
