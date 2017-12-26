﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using DataLayer;
using AutoMapper;
using DataLayer.Models;

namespace BusinessLayer.Analyzer
{
    public class PerformanceDiagnostics : IPerformanceDiagostics
    {
        private readonly double _timeoutValue;

        public PerformanceDiagnostics(double timeoutValue = 20.0d)
        {
            _timeoutValue = timeoutValue;
        }

        public int GetTotalAmountOfSitemaps()
        {
            return Store.PerformanceResultDataModels.Count; 
        }

        public async Task<IEnumerable<PerformanceModel>> AsyncGetPerformanceModelInRange(int from, int howMany)
        {
            var list = new List<PerformanceModel>();
            for (int i = from; i < from + howMany; i++)
            {
                //todo DI
                var url = Store.PerformanceResultDataModels.ToArray()[i];
                var resultTime = await GetCallBackTime(url.Url);
                url.ResponseTime = resultTime;
                list.Add(Mapper.Map<PerformanceResultDataModel, PerformanceModel>(url));
            }
            return list;
        }

        //todo can be refactored with the model using
        /// <summary>
        /// Returns time needed to get response from url
        /// if timeout reached, then TimeSpan.MaxValue returned
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<TimeSpan> GetCallBackTime(string url)
        {
            var httpClient = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(_timeoutValue)
            };
            try
            {
                var timer = Stopwatch.StartNew();
                var result = await httpClient.GetAsync(url);
                timer.Stop();
                return result.IsSuccessStatusCode ? timer.Elapsed : TimeSpan.Zero;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}