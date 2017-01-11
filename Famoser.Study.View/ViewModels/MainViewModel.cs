using System.Collections.ObjectModel;
using System.Windows.Input;
using Famoser.FrameworkEssentials.Services.Interfaces;
using Famoser.FrameworkEssentials.View.Commands;
using Famoser.Study.Business.Models;
using Famoser.Study.Business.Repositories.Interfaces;
using Famoser.Study.View.Enum;
using Famoser.Study.View.Models;
using Famoser.Study.View.Services.Interfaces;
using Famoser.Study.View.ViewModels.Base;
using GalaSoft.MvvmLight.Messaging;

namespace Famoser.Study.View.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IHistoryNavigationService _navigationService;
        private readonly IWeekDayService _weekDayService;

        public MainViewModel(ICourseRepository courseRepository, IHistoryNavigationService navigationService, IWeekDayService weekDayService)
        {
            _courseRepository = courseRepository;
            _navigationService = navigationService;
            _weekDayService = weekDayService;
            _selectedWeekDay = _weekDayService.GetToday();
        }

        public ObservableCollection<Course> Courses => _courseRepository.GetCoursesLazy();

        public ObservableCollection<WeekDay> WeekDays => _weekDayService.GetWeekDays();

        private WeekDay _selectedWeekDay;
        public WeekDay SelectedWeekDay
        {
            get { return _selectedWeekDay; }
            set { Set(ref _selectedWeekDay, value); }
        }

        public ICommand RefreshCommand => new LoadingRelayCommand(() => _courseRepository.SyncAsnyc());

        public ICommand SelectCourseCommand => new LoadingRelayCommand<Course>((c) =>
        {
            _navigationService.NavigateTo(Pages.ViewCourse.ToString());
            Messenger.Default.Send(c, Messages.Select);
        });

        public ICommand AddCourseCommand => new LoadingRelayCommand<Course>((c) =>
        {
            _navigationService.NavigateTo(Pages.AddEditCourse.ToString());
            Messenger.Default.Send(new Course(), Messages.Select);
        });
    }
}
