using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Famoser.Study.Business.Models;
using Famoser.Study.View.Models;

namespace Famoser.Study.View.Services.Interfaces
{
    public interface IWeekDayService
    {
        ObservableCollection<WeekDay> GetWeekDays();
        WeekDay GetToday();
        void RefreshCourse(Course course);
    }
}
