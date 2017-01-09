using Famoser.FrameworkEssentials.Services.Interfaces;
using Famoser.Study.Business.Repositories;
using Famoser.Study.Business.Repositories.Interfaces;
using Famoser.Study.Business.Services;
using Famoser.Study.Business.Services.Interfaces;
using Famoser.Study.View.Mocks;
using Famoser.Study.View.Services;
using Famoser.Study.View.Services.Interfaces;
using GalaSoft.MvvmLight.Ioc;

namespace Famoser.Study.View.ViewModels.Base
{
    public class BaseViewModelLocator : BaseViewModel
    {
        static BaseViewModelLocator()
        {
            SimpleIoc.Default.Register<IApiService, ApiService>();
            SimpleIoc.Default.Register<ISimpleProgressService, ProgressViewModel>();
            SimpleIoc.Default.Register<IWeekDayService, WeekDayService>();
            if (IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register<ICourseRepository, MockCourseRepository>();
            }
            else
            {
                SimpleIoc.Default.Register<ICourseRepository, MockCourseRepository>();
            }

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<CourseViewModel>();
            SimpleIoc.Default.Register<LectureViewModel>();
        }

        public MainViewModel MainViewModel => SimpleIoc.Default.GetInstance<MainViewModel>();
        public CourseViewModel CourseViewModel => SimpleIoc.Default.GetInstance<CourseViewModel>();
        public LectureViewModel LectureViewModel => SimpleIoc.Default.GetInstance<LectureViewModel>();
        public ProgressViewModel ProgressViewModel => SimpleIoc.Default.GetInstance<ISimpleProgressService>() as ProgressViewModel;
    }
}
