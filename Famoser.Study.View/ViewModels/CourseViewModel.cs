using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Famoser.FrameworkEssentials.View.Commands;
using Famoser.Study.Business.Models;
using Famoser.Study.Business.Repositories.Interfaces;
using Famoser.Study.View.Enum;
using Famoser.Study.View.ViewModels.Base;
using GalaSoft.MvvmLight.Messaging;

namespace Famoser.Study.View.ViewModels
{
    public class CourseViewModel : BaseViewModel
    {
        private readonly ICourseRepository _courseRepository;

        public CourseViewModel(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
            Messenger.Default.Register<Course>(this, Messages.Select, SelectCourse);
        }

        private Course _course;
        public Course Course
        {
            get { return _course; }
            set { Set(ref _course, value); }
        }

        private void SelectCourse(Course obj)
        {
            Course = obj;
        }

        public ICommand SaveCourse => new LoadingRelayCommand(() => _courseRepository.SaveCourseAsync(Course));
        public ICommand DeleteCourse => new LoadingRelayCommand(() => _courseRepository.RemoveCourseAsync(Course));
    }
}
