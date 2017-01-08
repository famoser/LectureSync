using Famoser.FrameworkEssentials.Services.Interfaces;
using Famoser.Study.Business.Repositories;
using Famoser.Study.Business.Repositories.Interfaces;
using Famoser.Study.Business.Services;
using Famoser.Study.Business.Services.Interfaces;
using Famoser.Study.View.Mocks;
using GalaSoft.MvvmLight.Ioc;

namespace Famoser.Study.View.ViewModels.Base
{
    public class BaseViewModelLocator : BaseViewModel
    {
        static BaseViewModelLocator()
        {
            SimpleIoc.Default.Register<IApiService, ApiService>();
            SimpleIoc.Default.Register<ISimpleProgressService, ProgressViewModel>();
            if (IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register<ICourseRepository, MockCourseRepository>();
            }
            else
            {
                SimpleIoc.Default.Register<ICourseRepository, CourseRepository>();
            }

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<CourseViewModel>();
        }

        public MainViewModel MainViewModel => SimpleIoc.Default.GetInstance<MainViewModel>();
        public CourseViewModel CourseViewModel => SimpleIoc.Default.GetInstance<CourseViewModel>();
        public ProgressViewModel ProgressViewModel => SimpleIoc.Default.GetInstance<ISimpleProgressService>() as ProgressViewModel;
    }
}
