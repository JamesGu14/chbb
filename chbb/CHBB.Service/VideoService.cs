using CHBB.DomainModel;
using CHBB.Utility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Text;

namespace CHBB.Service
{
    public class VideoService
    {
        public string API_URL;
        public VideoService()
        {
            API_URL = ConfigurationManager.AppSettings["AliyunVideoAPIHost"];
        }

        // VideoCategoryViewModel
        public string GetVideoCategoriesByCateId(long? cateId, long? pageNo, long? pageSize)
        {
            string resultString = string.Empty;
            Dictionary<string, string> privateParams = new Dictionary<string, string>();
            privateParams.Add("Action", "GetCategories");
            if (cateId.HasValue) privateParams.Add("CateId", cateId.Value.ToString());
            if (pageNo.HasValue) privateParams.Add("PageNo", pageNo.Value.ToString());
            if (pageSize.HasValue) privateParams.Add("PageSize", pageSize.Value.ToString());

            using(WebClient client = new WebClient())
            {
                client.Headers["Type"] = "GET";
                client.Headers["Accept"] = "application/json";
                client.Encoding = Encoding.UTF8;
                client.DownloadStringCompleted += (senderobj, es) =>
                {
                    resultString = es.Result;
                };

                string url = Utilities.GenerateOpenAPIURL(API_URL, "GET", privateParams);

                client.DownloadStringAsync(new Uri(url));
            }

            return resultString;
        }
    }
}
