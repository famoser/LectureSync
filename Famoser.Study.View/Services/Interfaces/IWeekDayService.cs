using System.Collections.ObjectModel;
using Famoser.Study.View.Models;

namespace Famoser.Study.View.Services.Interfaces
{
    public interface IWeekDayService
    {
        ObservableCollection<WeekDay> GetWeekDays();
        WeekDay GetToday();
    }
}
