using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHBB.DomainModel
{
    public class VideoModel { }

    public class VideoCategoryViewModel
    {
        public String RequestId { get; set; }
        public VideoCategory Category { get; set; }
        public long SubTotal { get; set; }          // sub category total
        public VideoCategory[] SubCategories { get; set; }
    }

    public class VideoCategory
    {
        public long CateId { get; set; }
        public string CateName { get; set; }
        public long ParentId { get; set; }
        public long Level { get; set; }
    }

    public class Video
    {
        public string VideoId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float Duration { get; set; }
        public string CoverURL { get; set; }
        public string Status { get; set; }
        public string CreationTime { get; set; }
        public long Size { get; set; }
        public string[] Snapshots { get; set; }
        public long CateId { get; set; }
        public string CateName { get; set; }
        public string Tags { get; set; }
    }

}
