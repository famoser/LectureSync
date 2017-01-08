using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Famoser.Study.Business.Models
{
    public class Lecture
    {
        public string Lecturer { get; set; }
        public string Place { get; set; }
        public string Description { get; set; }

        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        [JsonIgnore]
        public Course Course { get; set; }

    }
}
