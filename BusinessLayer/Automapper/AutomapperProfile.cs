using AutoMapper;
using BusinessLayer.Models;
using DataLayer.Models;

namespace BusinessLayer.Automapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<PerformanceModel, PerformanceResultDataModel>();
            CreateMap<PerformanceResultDataModel, PerformanceModel>();
        }
    }
}
