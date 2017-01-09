using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Famoser.FrameworkEssentials.Services.Interfaces;
using Famoser.FrameworkEssentials.UniversalWindows.Platform;
using Famoser.Study.Presentation.Universal.Pages;
using Famoser.Study.Presentation.Universal.Platform;
using Famoser.Study.View.Services;
using Famoser.Study.View.Services.Interfaces;
using Famoser.Study.View.ViewModels;
using Famoser.Study.View.ViewModels.Base;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;

namespace Famoser.Study.Presentation.Universal.ViewModels
{
    public class ViewModelLocator : BaseViewModelLocator
    {
        static ViewModelLocator()
        {
            SimpleIoc.Default.Register<IStorageService>(() => new StorageService());
            SimpleIoc.Default.Register<IHistoryNavigationService>(ConstructNavigationService);
            SimpleIoc.Default.Register<IInteractionService, InteractionService>();
        }

        private static HistoryNavigationService ConstructNavigationService()
        {
            var ngs = new HistoryNavigationService();
            ngs.Configure(View.Enum.Pages.Main.ToString(), typeof(MainPage));
            ngs.Configure(View.Enum.Pages.ViewCourse.ToString(), typeof(CoursePage));
            ngs.Configure(View.Enum.Pages.AddEditCourse.ToString(), typeof(EditCoursePage));
            ngs.Configure(View.Enum.Pages.AddEditLecture.ToString(), typeof(EditLecturePage));

            return ngs;
        }
    }
}
