﻿using System.Collections.Generic;
using System.Xml;
using System.Xml.XPath;
using BusinessLayer.Interfaces;
using DataLayer;
using DataLayer.Models;
using System;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLayer.Analyzer
{
    public class UrlSiteMapParser : IAnalyzer
    {
        private const string DEFAULT = "DEFAULT";
        private const string RegExp = @"^(https?:\/\/)?([\w\.]+)\.([a-z]{2,6}\.?)(\/[\w\.]*)*\/?$";

        public List<string> GetSitemap(string url)
        {
            var client = new HttpClient();
            var resultTask = Task.Run(async () =>
            {
                var getResponseMessage = await client.GetAsync($"{url}/sitemap.xml");
                var content = await getResponseMessage.Content.ReadAsStringAsync();
                return Regex.Matches(content, RegExp).Select(value => value.Value).ToList();
            });

            resultTask.Wait();
            
            //todo make something different
            foreach (var value in resultTask.Result)
            {
                Store.PerformanceResultDataModels.Add(new PerformanceResultDataModel
                {
                    Url = value
                });
            }
            return resultTask.Result;
        }

        public List<string> ReturnSiteMap(string url)
        {
            
            var urls = new List<string>();
            //todo KISS not implemented
            Store.PerformanceResultDataModels.Clear();
            var result = Store.PerformanceResultDataModels;
            var siteUrl = Regex.Match(url, RegExp);
            if (string.IsNullOrEmpty(url) || !siteUrl.Success) return urls;
            
            var xmlReader = new XmlTextReader(string.Format("{0}/sitemap.xml", siteUrl.Value));
            var document = new XPathDocument(xmlReader);
            var xNav = document.CreateNavigator();
            var xmlNamespaceManager = getNamespaces(xmlReader, xNav);

            foreach (var namespc in xmlNamespaceManager)
            {
                if(string.IsNullOrEmpty(namespc.ToString())) continue;
                var iterator = xNav.Select(string.Format("//{0}:loc",
                    namespc), xmlNamespaceManager);

                foreach (XPathNavigator node in iterator)
                {
                    urls.Add(node.Value);
                    //todo add DI
                    result.Add(new PerformanceResultDataModel
                    {
                        Url = node.Value,
                        ResponseTime = TimeSpan.Zero
                    });
                }
            }
            return urls;
        }

        private XmlNamespaceManager getNamespaces(XmlReader xmlReader, XPathNavigator xNav)
        {
            var resolver = new XmlNamespaceManager(xmlReader.NameTable);

            IDictionary<string, string> localNamespaces = null;
            while (xNav.MoveToFollowing(XPathNodeType.Element))
            {
                localNamespaces = xNav.GetNamespacesInScope(XmlNamespaceScope.Local);
                foreach (var localNamespace in localNamespaces)
                {
                    resolver.RemoveNamespace(localNamespace.Key, localNamespace.Value);
                    var prefix = string.IsNullOrEmpty(localNamespace.Key) ? DEFAULT : localNamespace.Key;
                    resolver.AddNamespace(prefix, localNamespace.Value);
                }
            }
            return resolver;
        }
    }
}