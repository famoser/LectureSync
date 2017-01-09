using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Famoser.FrameworkEssentials.View.Commands;
using Famoser.Study.Business.Models;
using Famoser.Study.Business.Repositories.Interfaces;
using Famoser.Study.View.Enum;
using Famoser.Study.View.ViewModels.Base;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;

namespace Famoser.Study.View.ViewModels
{
    public class LectureViewModel : BaseViewModel
    {
        private ICourseRepository _courseRepository;

        public LectureViewModel(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
            Messenger.Default.Register<Lecture>(this, Messages.Select, SelectLecture);
            if (IsInDesignModeStatic)
            {
                Lecture = courseRepository.GetCoursesLazy().FirstOrDefault().Lectures.FirstOrDefault();
            }
        }

        private Lecture _lecture;
        public Lecture Lecture
        {
            get { return _lecture; }
            set { Set(ref _lecture, value); }
        }

        public ObservableCollection<DayOfWeek> DayOfWeeks { get; } = new ObservableCollection<DayOfWeek>()
        {
            DayOfWeek.Monday,
            DayOfWeek.Tuesday,
            DayOfWeek.Wednesday,
            DayOfWeek.Thursday,
            DayOfWeek.Friday,
            DayOfWeek.Saturday,
            DayOfWeek.Sunday
        };

        private void SelectLecture(Lecture obj)
        {
            Lecture = obj;
        }
        public ICommand SaveCourseCommand => new LoadingRelayCommand(() =>
        {
            var vm = SimpleIoc.Default.GetInstance<CourseViewModel>();
            if (!vm.Course.Lectures.Contains(Lecture))
                vm.Course.Lectures.Add(Lecture);
            _courseRepository.SaveCourseAsync(vm.Course);
        });
    }
}
