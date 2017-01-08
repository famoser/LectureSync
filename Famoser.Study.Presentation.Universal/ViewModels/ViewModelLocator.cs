using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Famoser.FrameworkEssentials.Services.Interfaces;
using Famoser.FrameworkEssentials.UniversalWindows.Platform;
using Famoser.Study.Presentation.Universal.Platform;
using Famoser.Study.View.Services;
using Famoser.Study.View.ViewModels;
using Famoser.Study.View.ViewModels.Base;
using GalaSoft.MvvmLight.Ioc;

namespace Famoser.Study.Presentation.Universal.ViewModels
{
    public class ViewModelLocator : BaseViewModelLocator
    {
        public ViewModelLocator()
        {
            SimpleIoc.Default.Register<IStorageService>(() => new StorageService());
            SimpleIoc.Default.Register<IInteractionService, InteractionService>();
        }
    }
}
