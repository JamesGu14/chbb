using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Http;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.vod.Model.V20170321;
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
            var client = Utilities.ConstructClient();
            try
            {
                var request = new GetCategoriesRequest();
                GetCategoriesResponse response = client.GetAcsResponse(request);
                return response.SubTotal.ToString();
            }
            catch (ServerException e)
            {
                Console.WriteLine(e.ErrorCode);
                Console.WriteLine(e.ErrorMessage);
            }
            catch (ClientException e)
            {
                Console.WriteLine(e.ErrorCode);
                Console.WriteLine(e.ErrorMessage);
            }
            return "Failed";
        }
        
    }
}
