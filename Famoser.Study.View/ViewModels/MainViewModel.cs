using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Famoser.FrameworkEssentials.Services.Interfaces;
using Famoser.FrameworkEssentials.View.Commands;
using Famoser.Study.Business.Models;
using Famoser.Study.Business.Repositories.Interfaces;
using Famoser.Study.Business.Services.Interfaces;
using Famoser.Study.View.Enum;
using Famoser.Study.View.Helpers;
using Famoser.Study.View.Models;
using Famoser.Study.View.ViewModels.Base;
using GalaSoft.MvvmLight.Views;

namespace Famoser.Study.View.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IHistoryNavigationService _navigationService;
        private readonly WeekDayHelper _weekDayHelper;

        public MainViewModel(ICourseRepository courseRepository, IHistoryNavigationService navigationService)
        {
            _courseRepository = courseRepository;
            _navigationService = navigationService;
            _weekDayHelper = new WeekDayHelper(courseRepository.GetCoursesLazy());
            _selectedWeekDay = _weekDayHelper.GetToday();
        }

        public ObservableCollection<Course> Courses => _courseRepository.GetCoursesLazy();

        public ObservableCollection<WeekDay> WeekDays => _weekDayHelper.GetWeekDays();

        private WeekDay _selectedWeekDay;
        public WeekDay SelectedWeekDay
        {
            get { return _selectedWeekDay; }
            set { Set(ref _selectedWeekDay, value); }
        }

        public ICommand RefreshCommand => new LoadingRelayCommand(() => _courseRepository.SyncAsnyc());

        public ICommand SelectCourseCommand => new LoadingRelayCommand<Course>((c) =>
        {
            _navigationService.NavigateTo(Pages.Main.ToString());
            MessengerInstance.Send(c, Messages.Select);
        });
    }
}
