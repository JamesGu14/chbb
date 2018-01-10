using CHBB.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace chbb.Controllers
{
    public class VideoController : ApiController
    {
        public readonly VideoService videoService;
        
        public VideoController()
        {
            videoService = new VideoService();
        }

        public string Get()
        {
            return videoService.GetVideoCategoriesByCateId(null, null, null);
        }
    }
}
