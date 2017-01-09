using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Famoser.Study.Business.Models;

namespace Famoser.Study.Presentation.Universal.Converters
{
    class LectureTimesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var lecture = value as Lecture;
            if (lecture != null)
            {
                return TimeSpanToString(lecture.StartTime) + " - " + TimeSpanToString(lecture.EndTime);
            }
            return null;
        }

        private string TimeSpanToString(TimeSpan ts)
        {
            return ts.Hours.ToString("00") + ":" + ts.Minutes.ToString("00");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
