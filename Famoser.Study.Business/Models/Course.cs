using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Famoser.SyncApi.Models;
using Famoser.SyncApi.Models.Interfaces;

namespace Famoser.Study.Business.Models
{
    public class Course : AbstractSyncModel
    {
        public string Name { get; set; }
        public string Lecturer { get; set; }
        public string Place { get; set; }
        public string Description { get; set; }
        public Uri InfoUrl { get; set; }
        public Uri WebpageUrl { get; set; }

        public List<Lecture> Lectures { get; set; } = new List<Lecture>();
        public override string GetClassIdentifier()
        {
            return typeof(Course).Name;
        }
    }
}
